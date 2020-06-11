using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Configuration;
using System.Windows.Forms;

namespace JSBuild
{
    public class Options
    {
        public static Options Instance = new Options();

        public static void Load()
        {
            XmlSerializer s = new XmlSerializer(typeof(Options));
            FileInfo fi = new FileInfo(new FileInfo(Application.ExecutablePath).Directory.FullName + "\\settings.xml");
            if(fi.Exists)
            {
                TextReader r = new StreamReader(new FileInfo(Application.ExecutablePath).Directory.FullName + "\\settings.xml");
                Instance = (Options)s.Deserialize(r);
                r.Close();
            }
        }

        public static void Save()
        {
            XmlSerializer s = new XmlSerializer(typeof(Options));
            TextWriter w = new StreamWriter(new FileInfo(Application.ExecutablePath).Directory.FullName + "\\settings.xml");
            s.Serialize(w, Instance);
            w.Close();
        }

        private String outputSuffix = "-min";

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

        private string filter = "$output;CVS;SCCS;RCS;rcs;";

        public string Filter
        {
            get { return filter; }
            set { filter = value; }
        }
        private string files = "*.js";

        public string Files
        {
            get { return files; }
            set { files = value; }
        }
        private string jsdocPath = @"c:\jsdoc\jsdoc.pl";

        public string JsdocPath
        {
            get { return jsdocPath; }
            set { jsdocPath = value; }
        }
        private string jsdocArgs = "-d $docPath $files";

        public string JsdocArgs
        {
            get { return jsdocArgs; }
            set { jsdocArgs = value; }
        }
        private bool reopen = true;

        public bool Reopen
        {
            get { return reopen; }
            set { reopen = value; }
        }
        private bool autoSave = true;

        public bool AutoSave
        {
            get { return autoSave; }
            set { autoSave = value; }
        }
        private bool autoCalc = false;

        public bool AutoCalc
        {
            get { return autoCalc; }
            set { autoCalc = value; }
        }
    }
}
