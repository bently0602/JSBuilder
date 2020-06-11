using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace JSBuild
{
	class JavascriptFile : SourceFile
	{
		public JavascriptFile(FileInfo file, string pathInfo) : base(file, pathInfo) { }

		public override bool SupportsSourceParsing
		{
			get { return true; }
		}

		public override String Minified
		{
			get
			{
				if (base.minified == null)
				{
					base.minified = new JSMin().MinifyToString(base.file.FullName);
				}
				return base.minified;
			}
			set { base.minified = value; }
		}

		public override void MinifyTo(string target)
		{
			base.minfile = target;
			using (StreamWriter sw = new StreamWriter(target))
			{
				sw.Write(base.header + this.Minified);
				sw.Close();
			}
		}

		//
		// Are these still needed?
		//===========================================

		//public List<String> GetClasses()
		//{
		//    if (classes == null)
		//    {
		//        classes = new List<string>();
		//        requires = new List<string>();
		//        Regex re = new Regex("@(className|requires)(\\s+)(\\S*)(\\s*)\n", RegexOptions.Compiled | RegexOptions.ECMAScript);
		//        MatchCollection ms = re.Matches(source);
		//        foreach (Match m in ms)
		//        {
		//            if (m.Groups[1].Value.Equals("className"))
		//            {
		//                classes.Add(m.Groups[3].Value);
		//            }
		//            else
		//            {
		//                requires.Add(m.Groups[3].Value);
		//            }
		//            Console.WriteLine(m.Groups[3].Value);
		//        }
		//    }
		//    return classes;
		//}

		//public List<string> GetCommentBlocks()
		//{
		//    Regex re = new Regex(@"/\*\*((.|\n)*?)\*/", RegexOptions.Compiled | RegexOptions.ECMAScript);
		//    MatchCollection mc = re.Matches(source);
		//    foreach (Match m in mc)
		//    {
		//        Console.WriteLine(m.Groups[1].Value);
		//    }
		//    return null;
		//}

		//public List<String> GetRequires()
		//{
		//    if (requires == null)
		//    {
		//        GetClasses();
		//    }
		//    return requires;
		//}
	}
}
