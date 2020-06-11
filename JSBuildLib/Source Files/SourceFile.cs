using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace JSBuild
{
	class SourceFile
	{
		#region Protected variables
		protected FileInfo file;
		protected String source;
		protected String pathInfo;
		protected String minfile;
		protected String header;
		protected String minified;
		//protected List<string> classes;
		//protected List<string> requires;
		//protected bool binary;
		#endregion

		#region Constructor
		public SourceFile(FileInfo file, string pathInfo)
		{
			this.file = file;
			this.pathInfo = pathInfo;

			if (this.SupportsSourceParsing)
			{
				using (StreamReader sr = new StreamReader(this.file.FullName))
				{
					this.source = sr.ReadToEnd();
					sr.Close();
				}
			}
		}
		#endregion

		#region Base properties / methods
		public String Source
		{
			get { return source; }
			set { source = value; }
		}
		public String PathInfo
		{
			get { return pathInfo; }
			set { pathInfo = value; }
		}
		public String Header
		{
			get { return header; }
			set { header = value; }
		}
		public FileInfo File
		{
			get { return file; }
			set { file = value; }
		}

		public string GetSourceNoComments()
		{
			if (this.SupportsSourceParsing && this.source.Length > 0)
			{
				//BPM: changed to resolve the unix CRLF / url double-slash issue that kills JSB
				//Regex re = new Regex(@"(/\*((.|[\r\n])*?)\*/)|(\/\/.*)", RegexOptions.Compiled | RegexOptions.ECMAScript);
				Regex re = new Regex(@"(/\*((.|[\r\n])*?)\*/)", RegexOptions.Compiled | RegexOptions.ECMAScript);
				return re.Replace(this.source, "");
			}
			return "";
		}

		public void CopyTo(string target)
		{
			if (this.SupportsSourceParsing)
			{
				using (StreamWriter sw = new StreamWriter(target))
				{
					sw.Write(this.header + this.source);
					sw.Close();
				}
			}
			else
			{
				this.file.CopyTo(target, true);
			}
		}
		#endregion

		#region Virtual properties / methods

		//Note: These virtual functions provide a default implementation
		//that does NOT support source parsing or minification.  Any file
		//types that do support parsing must override these.

		public virtual bool SupportsSourceParsing
		{
			get { return false; }
		}

		public virtual string OutputFilename
		{
			get
			{
				return (this.SupportsSourceParsing ? this.file.Name.Replace(this.file.Extension,
					Options.GetInstance().OutputSuffix + this.file.Extension) : this.file.Name);
			}
		}

		public virtual string Minified
		{
			get { return ""; }
			set { }
		}

		public virtual void MinifyTo(string target) { }

		#endregion
	}
}
