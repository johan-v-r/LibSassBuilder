using CommandLine;
using System.Collections.Generic;

namespace LibSassBuilder
{
	[Verb("files")]
	public class FilesOptions : GenericOptions
	{
		[Value(0, Required = true, HelpText = "File(s) to process")]
		public IEnumerable<string> Files { get; set; } 
	}
}
