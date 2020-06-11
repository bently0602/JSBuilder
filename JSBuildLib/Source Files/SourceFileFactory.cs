using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace JSBuild
{
	static class SourceFileFactory
	{
		public static SourceFile GetSourceFile(FileInfo file, string pathInfo)
		{
			switch (file.Extension.ToLower())
			{
				case ".js":
					return new JavascriptFile(file, pathInfo);

				case ".css":
					return new CssFile(file, pathInfo);

				default:
					return new SourceFile(file, pathInfo);
			}
		}
	}
}
