using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace JSBuild
{
    public class Target
    {
        public Target(string name, string file, List<string> includes)
        {
            this.name = name;
            this.file = file;
            this.includes = includes;
        }

        public void Add(string file)
        {
            if(includes == null)
            {
                this.includes = new List<string>();
            }
            includes.Add(file);
        }
        private bool debug;

        public bool Debug
        {
            get { return debug; }
            set { debug = value; }
        }


        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string file;

        public string File
        {
            get { return file; }
            set { file = value; }
        }
        private List<string> includes;

        public List<string> Includes
        {
            get { return includes; }
            set { includes = value; }
        }

        private bool shorthand = false;

        public string[] ParseList()
        {
            string[] s = shorthandList.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            return s;
        }

        public bool Shorthand
        {
            get { return shorthand; }
            set { shorthand = value; }
        }
        private string shorthandList;

        public string ShorthandList
        {
            get { return shorthandList; }
            set { shorthandList = value; }
        }
    }
}
