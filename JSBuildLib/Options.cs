using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Configuration;
using System.Collections;
//using System.Windows.Forms;

namespace JSBuild
{
    public class Options
    {
		private const string defaultOutputSuffix = "-min";
		private const string defaultFilter = "$output;CVS;SCCS;RCS;rcs;";
		private const string defaultFiles = "*.js";
		private const string defaultJSDocPath = @"c:\jsdoc\jsdoc.pl";
		private const string defaultJSDocArgs = "-d $docPath $files";
		private const bool defaultReopen = true;
		private const bool defaultAutoSave = true;
		private const bool defaultAutoCalc = false;
        private const bool defaultClearOutputDir = false;
        private const int maxRecentProjects = 10;

		private static Options instance = new Options();

		private Options() {}

		public static Options GetInstance()
        {
            return instance;
        }

		public void Load(string applicationExePath)
        {
            XmlSerializer s = new XmlSerializer(typeof(Options));
			FileInfo fi = new FileInfo(new FileInfo(applicationExePath).Directory.FullName + "\\settings.xml");

            if(fi.Exists)
            {
				TextReader r = new StreamReader(new FileInfo(applicationExePath).Directory.FullName + "\\settings.xml");
                instance = (Options)s.Deserialize(r);
                r.Close();
            }

			Project.GetInstance().FileFilter = this.Files;
        }

		public void Save(string applicationExePath)
        {
            XmlSerializer s = new XmlSerializer(typeof(Options));
			TextWriter w = new StreamWriter(new FileInfo(applicationExePath).Directory.FullName + "\\settings.xml");
            s.Serialize(w, instance);
            w.Close();
        }

		public void ResetDefaults()
		{
			this.OutputSuffix = defaultOutputSuffix;
			this.Filter = defaultFilter;
			this.Files = defaultFiles;
			this.JsdocPath = defaultJSDocPath;
			this.JsdocArgs = defaultJSDocArgs;
			this.Reopen = defaultReopen;
			this.AutoSave = defaultAutoSave;
			this.AutoCalc = defaultAutoCalc;
            this.ClearOutputDir = defaultClearOutputDir;
		}

        private String outputSuffix = defaultOutputSuffix;

        public String OutputSuffix
        {
            get { return outputSuffix; }
            set { outputSuffix = value; }
        }
        private String lastDir;

        public String LastDir
        {
            get { return lastDir; }
            set { lastDir = value; }
        }
        private String lastProject;

        public String LastProject
        {
            get { return lastProject; }
            set { lastProject = value; }
        }

        private string filter = defaultFilter;

        public string Filter
        {
            get { return filter; }
            set { filter = value; }
        }
		private string files = defaultFiles;

        public string Files
        {
            get { return files; }
            set { files = (value.Trim().Length > 0 ? value : defaultFiles); }
        }
        private string jsdocPath = defaultJSDocPath;

        public string JsdocPath
        {
            get { return jsdocPath; }
            set { jsdocPath = value; }
        }
        private string jsdocArgs = defaultJSDocArgs;

        public string JsdocArgs
        {
            get { return jsdocArgs; }
            set { jsdocArgs = value; }
        }
		private bool reopen = defaultReopen;

        public bool Reopen
        {
            get { return reopen; }
            set { reopen = value; }
        }
		private bool autoSave = defaultAutoSave;

        public bool AutoSave
        {
            get { return autoSave; }
            set { autoSave = value; }
        }
		private bool autoCalc = defaultAutoCalc;

        public bool AutoCalc
        {
            get { return autoCalc; }
            set { autoCalc = value; }
        }

        private bool clearOutputDir = defaultClearOutputDir;

        public bool ClearOutputDir
        {
            get { return clearOutputDir; }
            set { clearOutputDir = value; }
        }

        private ArrayList recentProjects = new ArrayList(maxRecentProjects);
        public ArrayList RecentProjects
        {
            get {   return recentProjects; }
            set { recentProjects = value; }
        }

        public void AddRecentProject(object value)
        {
            if (!RecentProjects.Contains(value))
            {
                if (RecentProjects.Count == maxRecentProjects)
                {
                    //recentProjects.RemoveAt(maxRecentProjects);
                    ArrayList tempRecentProjects = RecentProjects.GetRange(0, maxRecentProjects - 1);
                    RecentProjects = new ArrayList();
                    RecentProjects.AddRange(tempRecentProjects);
                }
            }
            else
            {
                RecentProjects.Remove(value);
            }
            RecentProjects.Insert(0, value);
        }
    }
}
