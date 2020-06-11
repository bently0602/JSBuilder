using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.IO;
//using System.Windows.Forms;
using System.Configuration;

namespace JSBuild
{
    public class Project
    {
        private XmlDocument doc;
        private XmlElement root;
        private string fileName;
        private string origXml;
		private string fileFilter;
        private DirectoryInfo projectDir;
        private static readonly Project instance = new Project();

        public DirectoryInfo ProjectDir
        {
            get { return projectDir; }
            set { projectDir = value; }
        }

		public string FileFilter
		{
			//This is used to compare against Options.Files after an Options update so
			//that we know which files to remove from the tree based on the new filter.
			get { return fileFilter; }
			set { fileFilter = value; }
		}

        private Project()
        {

        }

        public static Project GetInstance()
        {
            return instance;
        }



        public void Load(string filePath, string fileName)
        {
            this.fileName = fileName;
            this.projectDir = new FileInfo(fileName).Directory;
            if(fileName != null && File.Exists(fileName))
            {
                doc = new XmlDocument();
                doc.Load(fileName);
            }
            else
            {
                doc = new XmlDocument();
                //doc.Load(new FileInfo(Application.ExecutablePath).Directory.FullName + "\\project.xml");
				doc.Load(new FileInfo(filePath).Directory.FullName + "\\project.xml");
            }
            doc.Save(fileName);
            origXml = doc.InnerXml;
            root = (XmlElement)doc.GetElementsByTagName("project")[0];
            OnNameChanged();
            OnAuthorChanged();
            OnVersionChanged();
            OnCopyrightChanged();
            OnOutputChanged();
            OnSourceChanged();
            OnSourceDirChanged();
            OnMinifyChanged();
            OnMinDirChanged();
            OnDocChanged();
            OnDocDirChanged();
        }

        public Boolean IsChanged()
        {
            return !doc.InnerXml.Equals(origXml);
        }

        public void AddFile(string file, string pathInfo)
        {
            if(root.SelectSingleNode("file[@name='" + file + "']") == null)
            {
                XmlElement el = doc.CreateElement("file");
                el.SetAttribute("name", file);
                el.SetAttribute("path", pathInfo);
                root.AppendChild(el);
            }
        }

        public void RemoveFile(string path)
        {
            XmlNode node = root.SelectSingleNode("file[@name='" + path + "']");
            if(node != null)
            {
                root.RemoveChild(node);
            }
        }

        public void AddDirectory(string path)
        {
            if(root.SelectSingleNode("directory[@name='" + path + "']") == null)
            {
                XmlElement el = doc.CreateElement("directory");
                el.SetAttribute("name", path);
                root.AppendChild(el);
            }
        }

        public void RemoveDirectory(string path)
        {
            XmlNode node = root.SelectSingleNode("directory[@name='" + path + "']");
            if(node != null)
            {
                root.RemoveChild(node);
            }
        }

        public bool AddTarget(Target t, string originalName)
        {
            XmlElement node = (XmlElement)root.SelectSingleNode("target[@name='" + originalName + "']");
            if(node == null)
            {
                XmlElement el = doc.CreateElement("target");
                el.SetAttribute("name", t.Name);
                el.SetAttribute("file", t.File);
                el.SetAttribute("debug", t.Debug.ToString());
                el.SetAttribute("shorthand", t.Shorthand.ToString());
                el.SetAttribute("shorthand-list", t.ShorthandList);
                root.AppendChild(el);
                foreach(string f in t.Includes)
                {
                    XmlElement fe = doc.CreateElement("include");
                    fe.SetAttribute("name", f);
                    el.AppendChild(fe);
                }
                return true;
            }
            else
            {
                node.RemoveAll();
                node.SetAttribute("name", t.Name);
                node.SetAttribute("file", t.File);
                node.SetAttribute("debug", t.Debug.ToString());
                node.SetAttribute("shorthand", t.Shorthand.ToString());
                node.SetAttribute("shorthand-list", t.ShorthandList);
                foreach(string f in t.Includes)
                {
                    XmlElement fe = doc.CreateElement("include");
                    fe.SetAttribute("name", f);
                    node.AppendChild(fe);
                }
                return true;
            }
        }

        public void RemoveTarget(string name)
        {
            XmlNode node = root.SelectSingleNode("target[@name='" + name + "']");
            if(node != null)
            {
                root.RemoveChild(node);
            }
        }

        public Target GetTarget(string name)
        {
            XmlElement node = (XmlElement)root.SelectSingleNode("target[@name='" + name + "']");
            if(node != null)
            {
                Target t = new Target(node.GetAttribute("name"), node.GetAttribute("file"), null);
                t.Debug = "True".Equals(node.GetAttribute("debug"));
                t.Shorthand = "True".Equals(node.GetAttribute("shorthand"));
                t.ShorthandList = node.GetAttribute("shorthand-list");
                XmlNodeList incs = node.GetElementsByTagName("include");
                foreach(XmlNode inc in incs)
                {
                    string iname = inc.Attributes.GetNamedItem("name").Value;
                    if(IsSelected(iname))
                    {
                        t.Add(iname);
                    }
                }
                return t;
            }
            return null;
        }

        public List<Target> GetTargets(bool loadIncs)
        {
            List<Target> results = new List<Target>();
            XmlNodeList targets = root.GetElementsByTagName("target");
            foreach(XmlElement node in targets)
            {
                Target t = new Target(node.GetAttribute("name"), node.GetAttribute("file"), null);
                t.Debug = "True".Equals(node.GetAttribute("debug"));
                t.Shorthand = "True".Equals(node.GetAttribute("shorthand"));
                t.ShorthandList = node.GetAttribute("shorthand-list");
                if(loadIncs)
                {
                    XmlNodeList incs = node.GetElementsByTagName("include");
                    foreach(XmlNode inc in incs)
                    {
                        string iname = inc.Attributes.GetNamedItem("name").Value;
                        if(IsSelected(iname) && FileExists(iname))
                        {
                            t.Add(iname);
                        }
                    }
                }
                results.Add(t);
            }
            return results;
        }

        public string GetPath(string path)
        {
            return Path.RelativePathTo(projectDir.FullName, path);
        }

        public bool IsSelected(string path)
        {
            return (root.SelectSingleNode("file[@name='" + path + "']") != null);
        }

        public bool FileExists(string file)
        {
            string path = projectDir.FullName;
            if(!path.EndsWith("\\")) path += "\\";
            return new FileInfo(path + file).Exists;
        }

        public List<FileInfo> SelectedFiles
        {
            get
            {
                string path = projectDir.FullName;
                if(!path.EndsWith("\\")) path += "\\";
                XmlNodeList nodes = root.GetElementsByTagName("file");
                List<FileInfo> files = new List<FileInfo>();
                for(int i = 0; i < nodes.Count; i++)
                {
                    FileInfo f = new FileInfo(path + ((XmlElement)nodes[i]).GetAttribute("name"));
                    if(f.Exists)
                    {
                        files.Add(f);
                    }
                }
                return files;
            }
        }

        internal Dictionary<string, SourceFile> LoadSourceFiles()
        {
            string path = projectDir.FullName;
            if(!path.EndsWith("\\")) path += "\\";
            XmlNodeList nodes = root.GetElementsByTagName("file");
            Dictionary<string, SourceFile> files = new Dictionary<string, SourceFile>();
            foreach(XmlElement el in nodes)
            {
                FileInfo f = new FileInfo(path + el.GetAttribute("name"));
                if(f.Exists)
                {
                    //files.Add(el.GetAttribute("name"), new SourceFile(f, el.GetAttribute("path")));
					files.Add(el.GetAttribute("name"), SourceFileFactory.GetSourceFile(f, el.GetAttribute("path")));
                }
            }
            return files;
        }

        public List<DirectoryInfo> SelectedDirectories
        {
            get
            {
                string path = projectDir.FullName;
                if(!path.EndsWith("\\")) path += "\\";
                XmlNodeList nodes = root.GetElementsByTagName("directory");
                List<DirectoryInfo> dirs = new List<DirectoryInfo>();
                for(int i = 0; i < nodes.Count; i++)
                {
                    DirectoryInfo d = new DirectoryInfo(path + ((XmlElement)nodes[i]).GetAttribute("name"));
                    if(d.Exists)
                    {
                        dirs.Add(d);
                    }
                }
                return dirs;
            }
        }

        public void Save()
        {
            if(doc != null && fileName != null)
                doc.Save(fileName);
        }

        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
            }
        }

        public event EventHandler NameChanged;
        protected void OnNameChanged()
        {
            if(NameChanged != null)
            {
                NameChanged(this, EventArgs.Empty);
            }
        }
        public string Name
        {
            get
            {
                return root.GetAttribute("name");
            }
            set
            {
                root.SetAttribute("name", value);
                OnNameChanged();
            }
        }

        public event EventHandler AuthorChanged;
        protected void OnAuthorChanged()
        {
            if(AuthorChanged != null)
            {
                AuthorChanged(this, EventArgs.Empty);
            }
        }
        public string Author
        {
            get
            {
                return root.GetAttribute("author");
            }
            set
            {
                root.SetAttribute("author", value);
                OnAuthorChanged();
            }
        }

        public event EventHandler VersionChanged;
        protected void OnVersionChanged()
        {
            if(VersionChanged != null)
            {
                VersionChanged(this, EventArgs.Empty);
            }
        }
        public string Version
        {
            get
            {
                return root.GetAttribute("version");
            }
            set
            {
                root.SetAttribute("version", value);
                OnVersionChanged();
            }
        }

        public event EventHandler CopyrightChanged;
        protected void OnCopyrightChanged()
        {
            if(CopyrightChanged != null)
            {
                CopyrightChanged(this, EventArgs.Empty);
            }
        }
        public string Copyright
        {
            get
            {
                return root.GetAttribute("copyright");
            }
            set
            {
                root.SetAttribute("copyright", value);
                OnCopyrightChanged();
            }
        }

        public event EventHandler OutputChanged;
        protected void OnOutputChanged()
        {
            if(OutputChanged != null)
            {
                OutputChanged(this, EventArgs.Empty);
            }
        }
        public string Output
        {
            get
            {
                if(root.GetAttribute("output").Length < 1)
                {
                    root.SetAttribute("output", projectDir.FullName + (projectDir.FullName.EndsWith("\\") ? "" : "\\") + @"build\");
                }
                return root.GetAttribute("output");
            }
            set
            {
                root.SetAttribute("output", value);
                OnOutputChanged();
            }
        }

        public event EventHandler SourceChanged;
        protected void OnSourceChanged()
        {
            if(SourceChanged != null)
            {
                SourceChanged(this, EventArgs.Empty);
            }
        }
        public bool Source
        {
            get
            {
                return Boolean.Parse(root.GetAttribute("source"));
            }
            set
            {
                root.SetAttribute("source", value.ToString());
                OnSourceChanged();
            }
        }

        public event EventHandler SourceDirChanged;
        protected void OnSourceDirChanged()
        {
            if(SourceDirChanged != null)
            {
                SourceDirChanged(this, EventArgs.Empty);
            }
        }
        public string SourceDir
        {
            get
            {
                return root.GetAttribute("source-dir");
            }
            set
            {
                root.SetAttribute("source-dir", value);
                OnSourceDirChanged();
            }
        }

        public event EventHandler MinifyChanged;
        protected void OnMinifyChanged()
        {
            if(MinifyChanged != null)
            {
                MinifyChanged(this, EventArgs.Empty);
            }
        }
        public bool Minify
        {
            get
            {
                return Boolean.Parse(root.GetAttribute("minify"));
            }
            set
            {
                root.SetAttribute("minify", value.ToString());
                OnMinifyChanged();
            }
        }

        public event EventHandler MinDirChanged;
        protected void OnMinDirChanged()
        {
            if(MinDirChanged != null)
            {
                MinDirChanged(this, EventArgs.Empty);
            }
        }
        public string MinDir
        {
            get
            {
                return root.GetAttribute("min-dir");
            }
            set
            {
                root.SetAttribute("min-dir", value);
                OnMinDirChanged();
            }
        }

        public event EventHandler DocChanged;
        protected void OnDocChanged()
        {
            if(DocChanged != null)
            {
                DocChanged(this, EventArgs.Empty);
            }
        }
        public bool Doc
        {
            get
            {
                return Boolean.Parse(root.GetAttribute("doc"));
            }
            set
            {
                root.SetAttribute("doc", value.ToString());
                OnDocChanged();
            }
        }


        public event EventHandler DocDirChanged;
        protected void OnDocDirChanged()
        {
            if(DocDirChanged != null)
            {
                DocDirChanged(this, EventArgs.Empty);
            }
        }
        public string DocDir
        {
            get
            {
                return root.GetAttribute("doc-dir");
            }
            set
            {
                root.SetAttribute("doc-dir", value);
                OnDocDirChanged();
            }
        }
        
    }
}
