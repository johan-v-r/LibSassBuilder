using CommandLine;
using System.Collections.Generic;

namespace LibSassBuilder
{
	[Verb("files")]
	public class FilesOptions : GenericOptions
	{
		[Value(0, Required = true, HelpText = "Directory in which to run. Defaults to current directory.")]
		public IEnumerable<string> Files { get; set; } 

		[Option('e', "exclude", Required = false, HelpText = "Specify explicit directories to exclude. Overrides the default.", Default = new[] { "bin", "obj", "logs", "node_modules" })]
		public IEnumerable<string> ExcludedDirectories { get; set; }
	}
}
