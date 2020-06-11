using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace JSBuild
{
    class SourceFile
    {
        private FileInfo file;
        private String source;

        public String Source
        {
            get { return source; }
            set { source = value; }
        }
        private String pathInfo;

        public String PathInfo
        {
            get { return pathInfo; }
            set { pathInfo = value; }
        }
        private String minfile;
        private String header;

        public String Header
        {
            get { return header; }
            set { header = value; }
        }
        private String minified;
        private List<string> classes;
        private List<string> requires;

        public FileInfo File
        {
            get { return file; }
            set { file = value; }
        }

        public String Minified
        {
            get 
            {
                if(minified == null)
                {
                    minified = new JSMin().MinifyToString(file.FullName);
                }
                return minified; 
            }
            set { minified = value; }
        }

        public SourceFile(FileInfo file, string pathInfo)
        {
            this.file = file;
            this.pathInfo = pathInfo;
            StreamReader sr = new StreamReader(file.FullName);
            source = sr.ReadToEnd();
            sr.Close();    
        }

        public void CopyTo(string target)
        {
            StreamWriter sw = new StreamWriter(target);
            sw.Write(header + source);
            sw.Close();
        }

        public void MinifyTo(string target)
        {
            this.minfile = target;
            new JSMin().Minify(file.FullName, target);
            StreamReader sr = new StreamReader(target);
            minified = sr.ReadToEnd();
            sr.Close();
            StreamWriter sw = new StreamWriter(target);
            sw.Write(header + minified);
            sw.Close();
        }

        public List<String> GetClasses()
        {
            if(classes == null)
            {
                classes = new List<string>();
                requires = new List<string>();
                Regex re = new Regex("@(className|requires)(\\s+)(\\S*)(\\s*)\n", RegexOptions.Compiled | RegexOptions.ECMAScript);
                MatchCollection ms = re.Matches(source);
                foreach(Match m in ms)
                {
                    if(m.Groups[1].Value.Equals("className"))
                    {
                        classes.Add(m.Groups[3].Value);
                    }
                    else
                    {
                        requires.Add(m.Groups[3].Value);
                    }
                    Console.WriteLine(m.Groups[3].Value);
                }
            }
            return classes;
        }

        public List<string> GetCommentBlocks()
        {
            Regex re = new Regex(@"/\*\*((.|\n)*?)\*/", RegexOptions.Compiled | RegexOptions.ECMAScript);
            MatchCollection mc = re.Matches(source);
            foreach(Match m in mc)
            {
                Console.WriteLine(m.Groups[1].Value);
            }
            return null;
        }

        public List<String> GetRequires()
        {
            if(requires == null)
            {
                GetClasses();
            }
            return requires;
        }
    }
}
