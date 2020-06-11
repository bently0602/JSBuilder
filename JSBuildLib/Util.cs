using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Win32;

namespace JSBuild
{
    public class Util
    {
        public static void RegisterExtension(string applicationExePath)
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
                //rkNew.SetValue("", Application.ExecutablePath + " %1");
				rkNew.SetValue("", applicationExePath + " %1");

                // Assign a default icon
                rkNew = rkInfo.CreateSubKey("DefaultIcon");
                //rkNew.SetValue("", Application.ExecutablePath +",0");
				rkNew.SetValue("", applicationExePath + ",0");
            }
        }

		public static string FixPath(string path)
		{
			if (!path.EndsWith("\\"))
			{
				path += "\\";
			}
			return path;
		}

		public static string ApplyVars(string val, string outputDir, Project project)
		{
			val = val.Replace("$author", project.Author);
			val = val.Replace("$version", project.Version);
			val = val.Replace("$output", outputDir);
			val = val.Replace("$projectName", project.Name);
			val = val.Replace("$projectDir", project.ProjectDir.FullName);
			//val.Replace("$fileName", fileName);
			return val;
		}

        public static void ClearOutputDirectory(string outputDir){
            try
            {
                if (outputDir != null && outputDir != string.Empty)
                {
                    DirectoryInfo outDirInfo = new DirectoryInfo(outputDir);
                    DirectoryInfo[] dirInfos = outDirInfo.GetDirectories();
                    foreach (DirectoryInfo dirInfo in dirInfos)
                    {
                        dirInfo.Delete(true);
                    }

                    FileInfo[] fileInfos = outDirInfo.GetFiles();
                    foreach (FileInfo fileInfo in fileInfos)
                    {
                        fileInfo.Delete();
                    }
                }
            }
            catch (Exception)
            { }
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
				//NOTE: If you add a new arg here, add it to IsArgNameValid also

				public const string INVALID = "invalid";
				public const string ProjectPath = "path";
				public const string VerboseOutput = "verbose";
				public const string DisplayHelp = "help";
				public const string DisplayHelpShort = "?";
                public const string CleanOutputDirectory = "clean";
                public const string OutputTarget = "output";
			}

			public static bool IsArgNameValid(string argName)
			{
				return (argName == AvailableArgs.ProjectPath
					|| argName == AvailableArgs.VerboseOutput
					|| argName == AvailableArgs.DisplayHelp
					|| argName == AvailableArgs.DisplayHelpShort
                    || argName == AvailableArgs.CleanOutputDirectory
                    || argName == AvailableArgs.OutputTarget);
			}

			public static Arg ParseArg(string argString)
			{
				Arg arg = new Arg();
				char[] delim = {'='};
				string[] parts = argString.Split(delim, 2);

				if (parts.Length > 0)
				{
					// A valid param name was supplied
					string name = parts[0];
					if (name.StartsWith("/") || name.StartsWith("-"))
					{
						name = name.Substring(1, name.Length - 1);
					}

					if (IsArgNameValid(name))
					{
						arg.Name = name;
						arg.Value = (parts.Length == 2 ? parts[1] : "");

						if (arg.Name == AvailableArgs.ProjectPath)
						{
							// Make sure the project path is valid
							arg = GetProjectPathArg(arg.Value);
						}
					}
					else
					{
						if (parts.Length == 1)
						{
							// There is only one part, so test to see if it is a path
							// specified with no arg name -- this will be the case for 
							// shortcuts that store the project path
							arg = GetProjectPathArg(parts[0]);
						}
						else
						{
							// An invalid param name was supplied
							arg.Name = AvailableArgs.INVALID;
							arg.Value = "Unrecognized argument: " + argString[0];
						}
					}
				}
				return arg;
			}

			private static Arg GetProjectPathArg(string pathValue)
			{
				Arg arg = new Arg();

				if (File.Exists(pathValue))
				{
					arg.Name = AvailableArgs.ProjectPath;
					arg.Value = pathValue;
				}
				else
				{
					arg.Name = AvailableArgs.INVALID;
					arg.Value = "Unrecognized argument: '" + pathValue + "'";
				}
				return arg;
			}
        }
    }
}
