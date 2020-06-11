using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace JSBuild
{
	#region Supporting classes / delegates

	#region ProgressInfo
	public class ProgressInfo
	{
		public int Percent = 0;
		public string Message = String.Empty;

		public ProgressInfo(int percent, string message)
		{
			this.Percent = percent;
			this.Message = message;
		}
	}

	public delegate void ProgressDelegate(ProgressInfo progressInfo);

	#endregion

	#region Message
	public enum MessageTypes
	{
		NotSet = 0,
		Info = 1,
		Error = 2,
		Status = 3
	}

	public class Message
	{
		public MessageTypes Type = MessageTypes.NotSet;
		public string Text = String.Empty;

		public Message(MessageTypes type, string text)
		{
			this.Type = type;
			this.Text = text;
		}
	}

	public delegate void MessageDelegate(Message message);

	#endregion

	#region BuildComplete

	public delegate void BuildCompleteDelegate();

	#endregion

	#endregion

	#region ProjectBuilder class
	public static class ProjectBuilder
	{
		public static event ProgressDelegate ProgressUpdate;
		public static event MessageDelegate MessageAvailable;
		public static event BuildCompleteDelegate BuildComplete;

        static public void Build(Project project)
        {
            Build(project, null);
        }
		static public void Build(Project project, string outputDir)
		{
			// NOTE: Make sure that we DO throw any errors that might occur here
			// and defer handling to the caller.  The console app must be allowed
			// to catch errors so that it can exit unsuccessfully.

			SetProgress(1, "Initializing...");
			string projectDir = Util.FixPath(project.ProjectDir.FullName);
			outputDir = outputDir != null ? Util.FixPath(outputDir) : Util.FixPath(project.Output);
			
			//Fix for default '$project\build' getting rendered literally:
			outputDir = outputDir.Replace("$project", projectDir);
			RaiseMessage(MessageTypes.Status, "Output path = " + outputDir);

            //rrs - option of clearing the output dir
            if (Options.GetInstance().ClearOutputDir)
            {
				RaiseMessage(MessageTypes.Status, "Clearing existing output...");
                Util.ClearOutputDirectory(outputDir);
            }
            //rrs
			string header = Util.ApplyVars(project.Copyright, outputDir, project);
			if (header.Length > 0)
			{
				header = "/*\r\n * " + header.Replace("\n", "\n * ") + "\r\n */\r\n\r\n";
			}
			string build = Util.FixPath(Util.ApplyVars(project.MinDir, outputDir, project));
			string src = Util.FixPath(Util.ApplyVars(project.SourceDir, outputDir, project));
			string doc = Util.FixPath(Util.ApplyVars(project.DocDir, outputDir, project));

			SetProgress(10, "Loading source files...");
			Dictionary<string, SourceFile> files = project.LoadSourceFiles();
			float fileValue = 60.0f / (files.Count > 0 ? files.Count : 1); 
			int fileNumber = 0;

			foreach (SourceFile file in files.Values)
			{
				int pct = (int)(fileValue * ++fileNumber);
				SetProgress(10 + pct, "Building file " + (fileNumber) + " of " + files.Count);
				RaiseMessage(MessageTypes.Status, "Processing " + file.File.FullName + "...");

				file.Header = header;
				if (project.Source)
				{
					//Copy original source files to source output path
					DirectoryInfo dir = getDirectory(src + file.PathInfo);
					file.CopyTo(Util.FixPath(dir.FullName) + file.File.Name);
				}

				if (project.Minify && file.SupportsSourceParsing)
				{
					//Minify files and copy to build output path
					DirectoryInfo dir = getDirectory(build + file.PathInfo);
					file.MinifyTo(Util.FixPath(dir.FullName) + file.OutputFilename);
				}

				//file.GetCommentBlocks();
			}

			bool jsdocSkipped = false;
			if (project.Doc)
			{
				if (Options.GetInstance().JsdocPath.Length < 1 || !new FileInfo(Options.GetInstance().JsdocPath).Exists)
				{
					jsdocSkipped = true;
				}
				else
				{
					SetProgress(75, "Creating JSDoc output...");

					string fileList = "";
					foreach (SourceFile f in files.Values)
					{
						if (f.SupportsSourceParsing) { fileList += f.File.FullName + " "; }
					}
					DirectoryInfo outDir = getDirectory(doc);

					string args = GetJsdocPath() + Options.GetInstance().JsdocArgs.Replace("$docPath", outDir.FullName);
					args = args.Replace("$files", fileList);

					Process p = new Process();
					p.EnableRaisingEvents = false;
					ProcessStartInfo info = new ProcessStartInfo("perl.exe", args);
					info.CreateNoWindow = true;
					info.UseShellExecute = false;
					p.StartInfo = info;
					try
					{
						p.Start();
						p.WaitForExit();
					}
					catch (Exception)
					{
						jsdocSkipped = true;
					}
				}
			}

			SetProgress(85, "Loading build targets...");
			List<Target> targets = project.GetTargets(true);
			bool targetsSkipped = false;

			if (targets.Count > 0)
			{
				float targetValue = 10.0f / (targets.Count > 0 ? targets.Count : 1);
				int targetNumber = 0;

				foreach (Target target in targets)
				{
					if (target.Includes == null)
					{
						targetsSkipped = true;
						continue;
					}

					int pct = (int)(targetValue * ++targetNumber);
					SetProgress(85 + pct, "Building target " + (targetNumber) + " of " + targets.Count);
					FileInfo fi = new FileInfo(Util.ApplyVars(target.File, outputDir, project));
					fi.Directory.Create();
					StreamWriter sw = new StreamWriter(fi.FullName);
					sw.Write(header);
					if (!target.Shorthand)
					{
						foreach (string f in target.Includes)
						{
							sw.Write(files[f].Minified + "\n");
						}
					}
					else
					{
						string[] sh = target.ParseList();
						StringBuilder fcn = new StringBuilder();
						fcn.Append("(function(){");
						int index = 0;
						foreach (string s in sh)
						{
							fcn.AppendFormat("var _{0} = {1};", ++index, s);
						}
						sw.Write(fcn.Append("\n"));
						foreach (string f in target.Includes)
						{
							string min = files[f].Minified;
							index = 0;
							foreach (string s in sh)
							{
								min = min.Replace(s, "_" + index);
							}
							sw.Write(min + "\n");
						}
						sw.Write("})();");
					}
					sw.Close();
					if (target.Debug)
					{
						string filename = fi.FullName;
						if (fi.Extension == ".js")
						{
							//Only rename to -debug for javascript files
							filename = fi.FullName.Substring(0, fi.FullName.Length - 3) + "-debug.js";
						}
						StreamWriter dsw = new StreamWriter(filename);
						dsw.Write(header);
						foreach (string f in target.Includes)
						{
							//dsw.Write("\r\n/*\r\n------------------------------------------------------------------\r\n");
							//dsw.Write("// File: " + files[f].PathInfo + "\\" + files[f].File.Name + "\r\n");
							//dsw.Write("------------------------------------------------------------------\r\n*/\r\n");
							dsw.Write(files[f].GetSourceNoComments() + "\n");
						}
						dsw.Close();
					}
				}
			}

			if (targetsSkipped)
			{
				RaiseMessage(MessageTypes.Info, "One or more build targets referenced files that are no longer included in the build project, so they were skipped.");
			}
			if (jsdocSkipped)
			{
				RaiseMessage(MessageTypes.Info, "JSDoc was skipped because the path to JSDoc (" + Options.GetInstance().JsdocPath +
					") is invalid or perl.exe was not found.\nYou can change the path by selecting Build->Options and entering a new path.");
			}

			SetProgress(100, "Done");

			if (BuildComplete != null)
			{
				BuildComplete();
			}
		}

		/// <summary>
		/// JSDoc does not handle unquoted spaces in paths, so we need to double-quote the path if necessary.
		/// </summary>
		private static string GetJsdocPath()
		{
			string path = Options.GetInstance().JsdocPath;
			if (!path.StartsWith("\"")) path = "\"" + path;
			if (!path.EndsWith("\"")) path += "\"";
			path += " ";
			
			return path;
		}

		#region Raise events
		private static void SetProgress(int percent, string message)
		{
			if (ProgressUpdate != null)
			{
				ProgressUpdate(new ProgressInfo(percent, message));
			}
		}

		private static void RaiseMessage(MessageTypes type, string text)
		{
			if (MessageAvailable != null)
			{
				MessageAvailable(new Message(type, text));
			}
		}
		#endregion

		#region Private utility methods
		private static DirectoryInfo getDirectory(string path)
		{
			DirectoryInfo d = new DirectoryInfo(Util.FixPath(path));
			if (!d.Exists)
			{
				d.Create();
			}
			return d;
		}
		#endregion
	}
	#endregion
}
