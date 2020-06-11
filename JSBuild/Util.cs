using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;

namespace JSBuild
{
    class Util
    {
        public static void RegisterExtension()
        {
            // Create a registry key object to represent the HKEY_CLASSES_ROOT registry section
            RegistryKey rkRoot = Registry.ClassesRoot;

            // Attempt to retrieve the registry key for the .blackwasp file type
            RegistryKey rkFileType = rkRoot.OpenSubKey(".jsb");

            if(rkFileType == null)
            {
                RegistryKey rkNew;

                // Create the registry key
                rkNew = rkRoot.CreateSubKey(".jsb");

                // Set the unique file type name
                rkNew.SetValue("", "jsbuilder.project");

                // Create the file type information key
                RegistryKey rkInfo = rkRoot.CreateSubKey("jsbuilder.project");

                // Set the default value to the file type description
                rkInfo.SetValue("", "JS Builder Project File");

                // Create the shell key to contain all verbs
                RegistryKey rkShell = rkInfo.CreateSubKey("shell");

                // Create a subkey for the "Open" verb
                RegistryKey rkOpen = rkShell.CreateSubKey("Open");

                // Set the menu name against the key
                rkOpen.SetValue("", "&Open Document");

                // Create and set the command string
                rkNew = rkOpen.CreateSubKey("command");
                rkNew.SetValue("", Application.ExecutablePath + " %1");

                // Assign a default icon
                rkNew = rkInfo.CreateSubKey("DefaultIcon");
                rkNew.SetValue("", Application.ExecutablePath +",0");
            }
        }

		public static string FixName(string path)
		{
			if (!path.EndsWith("\\"))
			{
				path += "\\";
			}
			return path;
		}

		public static string applyVars(string val, string outputDir, Project project)
		{
			val = val.Replace("$author", project.Author);
			val = val.Replace("$version", project.Version);
			val = val.Replace("$output", outputDir);
			val = val.Replace("$projectName", project.Name);
			val = val.Replace("$projectDir", project.ProjectDir.FullName);
			//val.Replace("$fileName", fileName);
			return val;
		}
        
        public static class CommandLine
        {
			public struct Arg
			{
				public string Name;
				public string Value;
			}

			public struct AvailableArgs
			{
				public const string StartProject = "startproject";
				public const string SilentMode = "silent";
			}

			public static Arg ParseArg(string argString)
			{
				Arg arg = new Arg();
				char[] delim = { ':', '=' };
				string[] parts = argString.Split(delim, 2);

				if (parts.Length > 0)
				{
					string name = parts[0];
					if (name.StartsWith("/") || name.StartsWith("-"))
					{
						name = name.Substring(1, name.Length - 1);
					}
					arg.Name = name;
					arg.Value = (parts.Length == 2 ? parts[1] : "");
				}
				return arg;
			}
        }

		public static class DataTypeHelper
		{
			public static bool BoolFromString(string value)
			{
				bool returnValue = false;
				if (value == null) return returnValue;

				try { returnValue = Convert.ToBoolean(value); }
				catch { }

				return returnValue;
			}

			public static int IntFromString(string value)
			{
				int returnValue = int.MinValue;
				if (value == null) return returnValue;

				try { returnValue = Convert.ToInt32(value); }
				catch { }

				return returnValue;
			}

			public static byte ByteFromString(string value)
			{
				byte returnValue = byte.MinValue;
				if (value == null) return returnValue;

				try { returnValue = Convert.ToByte(value); }
				catch { }

				return returnValue;
			}

			public static DateTime DateFromString(string value)
			{
				DateTime returnValue = DateTime.MinValue;
				if (value == null) return returnValue;

				try { returnValue = Convert.ToDateTime(value); }
				catch { }

				return returnValue;
			}
		}
    }
}
