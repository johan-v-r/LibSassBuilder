using CommandLine;
using System.Collections.Generic;

namespace LibSassBuilder
{
	public class Options
	{
		public static readonly IEnumerable<string> DefaultExcludedDirectories = new List<string>
		{
			"bin",
			"obj",
			"logs",
			"node_modules"
		};

		[Option('d', "directory", Required = false, HelpText = "Directory in which to run. Defaults to current directory.")]
		public string Directory { get; set; } = System.IO.Directory.GetCurrentDirectory();

		[Option('e', "exclude", Required = false, HelpText = "Specify explicit directories to exclude. Overrides the default.")]
		public IEnumerable<string> ExcludedDirectories { get; set; } = DefaultExcludedDirectories;
	}
}
