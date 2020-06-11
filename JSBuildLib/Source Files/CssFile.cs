using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace JSBuild
{
	class CssFile : SourceFile
	{
		public CssFile(FileInfo file, string pathInfo) : base(file, pathInfo) { }

		public override bool SupportsSourceParsing
		{
			get { return true; }
		}

		public override string Minified
		{
			get
			{
				if (base.minified == null)
				{
					// TODO: Replace with real minimizing code
					base.minified = base.GetSourceNoComments();
				}
				return base.minified;
			}
			set
			{
				base.Minified = value;
			}
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
	}
}
