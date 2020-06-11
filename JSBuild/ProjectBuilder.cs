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
		MessageBoxInfo = 1,
		MessageBoxError = 2,
		StatusBar = 3
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

	#endregion

	#region ProjectBuilder class
	static class ProjectBuilder
	{
		public static event ProgressDelegate ProgressUpdate;

		public static event MessageDelegate MessageAvailable;

		static public void Build(Project project)
		{
			try
			{
				SetProgress(1, "Initializing...");
				string projectDir = Util.FixName(project.ProjectDir.FullName);
				string outputDir = Util.FixName(project.Output);
				string header = Util.applyVars(project.Copyright, outputDir, project);
				if (header.Length > 0)
				{
					header = "/*\r\n * " + header.Replace("\n", "\n * ") + "\r\n */\r\n\r\n";
				}
				string build = Util.FixName(Util.applyVars(project.MinDir, outputDir, project));
				string src = Util.FixName(Util.applyVars(project.SourceDir, outputDir, project));
				string doc = Util.FixName(Util.applyVars(project.DocDir, outputDir, project));

				SetProgress(10, "Loading source files...");
				Dictionary<string, SourceFile> files = project.LoadSourceFiles();
				int fileValue = 40 / files.Count, fileNumber = 0;
				foreach (SourceFile file in files.Values)
				{
					SetProgress(10 + (fileValue * ++fileNumber), "Compressing file " + (fileNumber) + " of " + files.Count);
					RaiseMessage(MessageTypes.StatusBar, "Processing " + file.File.FullName + "...");

					file.Header = header;
					if (project.Source)
					{
						DirectoryInfo dir = getDirectory(src + file.PathInfo);
						file.CopyTo(Util.FixName(dir.FullName) + file.File.Name);
					}
					if (project.Minify)
					{
						DirectoryInfo buildDir = getDirectory(build + file.PathInfo);
						file.MinifyTo(Util.FixName(buildDir.FullName) + file.File.Name.Replace(".js", Options.Instance.OutputSuffix + ".js"));
					}

					//file.GetCommentBlocks();
				}
				bool jsdocSkipped = false;
				if (project.Doc)
				{
					if (Options.Instance.JsdocPath.Length < 1 || !new FileInfo(Options.Instance.JsdocPath).Exists)
					{
						jsdocSkipped = true;
					}
					else
					{
						SetProgress(65, "Running JSDoc...");

						string fileList = "";
						foreach (SourceFile f in files.Values)
						{
							fileList += f.File.FullName + " ";
						}
						DirectoryInfo outDir = getDirectory(doc);

						string args = Options.Instance.JsdocPath + " " + Options.Instance.JsdocArgs.Replace("$docPath", outDir.FullName);
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
						catch (Exception e)
						{
							jsdocSkipped = true;
						}
					}
				}
				SetProgress(70, "Loading build targets...");
				List<Target> targets = project.GetTargets(true);
				if (targets.Count > 0)
				{
					int targetValue = 30 / targets.Count, targetNumber = 0;
					foreach (Target target in targets)
					{
						SetProgress(70 + (targetValue * ++targetNumber), "Building target " + (targetNumber) + " of " + targets.Count);
						FileInfo fi = new FileInfo(Util.applyVars(target.File, outputDir, project));
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
							StreamWriter dsw = new StreamWriter(fi.FullName.Substring(0, fi.FullName.Length - 3) + "-debug.js");
							dsw.Write(header);
							foreach (string f in target.Includes)
							{
								dsw.Write("\r\n/*\r\n------------------------------------------------------------------\r\n");
								dsw.Write("// File: " + files[f].PathInfo + "\\" + files[f].File.Name + "\r\n");
								dsw.Write("------------------------------------------------------------------\r\n*/\r\n");
								dsw.Write(files[f].Source + "\n");
							}
							dsw.Close();
						}
					}
				}
				if (jsdocSkipped)
				{
					RaiseMessage(MessageTypes.MessageBoxInfo, "JSDoc was skipped because the path to JSDoc (" + Options.Instance.JsdocPath +
						") is invalid or perl.exe was not found. You can\nchange the path by selecting Build->Options and entering a new path.");
				}

				RaiseMessage(MessageTypes.StatusBar, "Build Complete.");
				SetProgress(100, "Done");
			}
			catch (Exception ex)
			{
				RaiseMessage(MessageTypes.MessageBoxError, "The build has failed due to the following error:\n" + ex.Message);
			}
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
			DirectoryInfo d = new DirectoryInfo(Util.FixName(path));
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
