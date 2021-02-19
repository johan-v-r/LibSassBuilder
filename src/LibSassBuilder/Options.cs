using CommandLine;
using System.Collections.Generic;

namespace LibSassBuilder
{
	public class Options
	{
		[Value(0, Required = false, HelpText = "Directory in which to run. Defaults to current directory.")]
		public string Directory { get; set; } = System.IO.Directory.GetCurrentDirectory();

		[Option('e', "exclude", Required = false, HelpText = "Specify explicit directories to exclude. Overrides the default.", Default = new[] { "bin", "obj", "logs", "node_modules" })]
		public IEnumerable<string> ExcludedDirectories { get; set; }
	}
}
