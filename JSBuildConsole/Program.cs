using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace JSBuild
{
	class Program
	{
		static bool verbose = false;
		static bool? cleanOutputDir = null;

		static void Main(string[] args)
		{
			String projectPath = null, outputPath = null;
			bool displayHelp = false;
			string invalidArg = "";

			for (int i = 0; i < args.Length; i++)
			{
				Util.CommandLine.Arg arg = Util.CommandLine.ParseArg(args[i]);

				//Note: If you add a new arg, please add the appropriate help text in DisplayHelp()

				switch (arg.Name)
				{
					case Util.CommandLine.AvailableArgs.INVALID:
						invalidArg = arg.Value;
						break;

					case Util.CommandLine.AvailableArgs.ProjectPath:
						projectPath = arg.Value;
						break;

					case Util.CommandLine.AvailableArgs.VerboseOutput:
						verbose = true;
						break;

					case Util.CommandLine.AvailableArgs.DisplayHelp:
					case Util.CommandLine.AvailableArgs.DisplayHelpShort:
						displayHelp = true;
						break;

					case Util.CommandLine.AvailableArgs.CleanOutputDirectory:
						cleanOutputDir = true;
						break;

					case Util.CommandLine.AvailableArgs.OutputTarget:
						outputPath = arg.Value;
						break;
				}
			}

			if (args.Length == 0 || displayHelp)
			{
				// If the help param was supplied, ignore other params
				DisplayHelp();
			}
			else if (invalidArg.Length > 0)
			{
				DisplayInvalidArgMsg(invalidArg);
			}
			else if (projectPath != null && projectPath.Length > 0)
			{
				try
				{
					Build(projectPath, outputPath);
				}
				catch (Exception ex)
				{
					Console.Out.WriteLine("\nBUILD FAILED!\n" + ex.ToString());
					Wait();

					// Exit with a negative return code so that external apps like NAnt 
					// can interpret the build as unsuccessful
					Environment.Exit(-99);
				}
			}
			else
			{
				// No valid params were supplied, so show the help
				DisplayHelp();
			}
		}

		static void Build(string projectPath, string outputPath)
		{
			Console.Out.WriteLine("\nBuilding: " + projectPath);
			Console.Out.WriteLine();

			string appExePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
			System.IO.FileInfo fi = new System.IO.FileInfo(appExePath);
			appExePath = Util.FixPath(fi.DirectoryName);

			//NOTE: In order to load an existing settings.xml file for debugging, you must first
			//create one using the GUI then copy it into the directory from which this assembly
			//is running (normally jsbuildconsole\bin\debug).  Otherwise it will simply use defaults.
			Options.GetInstance().Load(appExePath);

			if (cleanOutputDir != null)
			{
				//If the clean flag was specified as a param, override the project setting
				Options.GetInstance().ClearOutputDir = (bool)cleanOutputDir;
			}
			ProjectBuilder.MessageAvailable += new MessageDelegate(ProjectBuilder_MessageAvailable);
			ProjectBuilder.ProgressUpdate += new ProgressDelegate(ProjectBuilder_ProgressUpdate);
			ProjectBuilder.BuildComplete += new BuildCompleteDelegate(ProjectBuilder_BuildComplete);

			Project project = Project.GetInstance();
			project.Load(appExePath, projectPath);

			ProjectBuilder.Build(project, outputPath);

			Wait();
		}

		static void ProjectBuilder_BuildComplete()
		{
			Console.Out.WriteLine("\nBuild completed successfully!");
		}

		static void ProjectBuilder_ProgressUpdate(ProgressInfo progressInfo)
		{
			if (verbose) Console.Out.WriteLine(progressInfo.Message);
		}

		static void ProjectBuilder_MessageAvailable(Message message)
		{
			switch (message.Type)
			{
				case MessageTypes.Info:
					if (verbose) Console.Out.WriteLine("INFO: " + message.Text);
					break;

				case MessageTypes.Error:
					// Always write errors even if verbose = false
					Console.Out.WriteLine("\nBUILD FAILED!\n" + message.Text);
					break;

				case MessageTypes.Status:
					if (verbose) Console.Out.WriteLine(message.Text);
					break;
			}
		}

		static void DisplayHelp()
		{
			Console.Out.WriteLine("\nJS Builder Console " + 
				System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() +
				"\nby Jack Slocum (http://www.extjs.com/)");

			Console.Out.WriteLine("\nThe JS Builder Console performs command line builds of JS Builder");
			Console.Out.WriteLine("project files.  You must supply the path to an existing .jsb file");
			Console.Out.WriteLine("created with the JS Builder GUI application (JSBuilder.exe).");
			Console.Out.WriteLine("\nUsage   :  JSBuildConsole /path=<.jsb file path> [options]");
			Console.Out.WriteLine("Options :");
			Console.Out.WriteLine("\n   /verbose        Display informational logging during build.");
			Console.Out.WriteLine("                   If omitted, errors will still be displayed.");
			Console.Out.WriteLine("\n   /output=<path>  Override the build output path specified in");
			Console.Out.WriteLine("                   the project file with a new path.");
			Console.Out.WriteLine("\n   /clean          Delete any existing output files and folders");
			Console.Out.WriteLine("                   prior to building.");
			Console.Out.WriteLine("\n   /?              Display this help message.");
			Console.Out.WriteLine("\nExample : JSBuildConsole /path=C:\\projectdir\\myproject.jsb /verbose");
			Wait();
			Environment.Exit(-99);
		}

		static void DisplayInvalidArgMsg(string msg)
		{
			Console.Out.WriteLine("\nJS Builder Console could not start:\n\n" + msg);
			Console.Out.WriteLine("\nUse the /? parameter for additional help.");
			Wait();
			Environment.Exit(-99);
		}

		static void Wait()
		{
            // Pause here so we can verify the output.  This hard-coded flag should be set to
            // true when debugging in Visual Studio, otherwise leave it false.  Originally I had this
            // as a #DEBUG conditional, but we commonly release Debug builds right now, and we don't want
            // this code executing for someone who's not actively debugging the console.
            Console.Out.WriteLine("\nPress ENTER to continue...");
            Console.ReadLine();
        }
	}
}
