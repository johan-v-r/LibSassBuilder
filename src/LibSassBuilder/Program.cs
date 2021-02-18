using CommandLine;
using LibSassHost;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LibSassBuilder
{
	class Program
	{
		static async Task Main(string[] args)
		{
			// default single arg used as directory
			var searchDirectory = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();
			var excludedDirectories = Options.DefaultExcludedDirectories;

			// multiple args require parsing
			if (args.Length > 1)
				Parser.Default.ParseArguments<Options>(args)
					.WithParsed(o =>
					{
						searchDirectory = o.Directory;
						excludedDirectories = o.ExcludedDirectories;
					});

			Console.WriteLine($"Sass compile directory: {searchDirectory}");

			await CompileDirectoriesAsync(searchDirectory, excludedDirectories);

			Console.WriteLine("Sass files compiled");
		}

		static async Task CompileDirectoriesAsync(string directory, IEnumerable<string> excludedDirectories)
		{
			var sassFiles = Directory.EnumerateFiles(directory)
				.Where(file => file.EndsWith(".scss", StringComparison.OrdinalIgnoreCase) || file.EndsWith(".sass", StringComparison.OrdinalIgnoreCase));

			await CompileFilesAsync(sassFiles);

			var subDirectories = Directory.EnumerateDirectories(directory);
			foreach (var subDirectory in subDirectories)
			{
				if (excludedDirectories.Any(dir => subDirectory.EndsWith(dir, StringComparison.OrdinalIgnoreCase)))
					continue;

				await CompileDirectoriesAsync(subDirectory, excludedDirectories);
			}
		}

		static async Task CompileFilesAsync(IEnumerable<string> sassFiles)
		{
			foreach (var file in sassFiles)
			{
				var fileInfo = new FileInfo(file);
				if (fileInfo.Name.StartsWith("_"))
					continue;

				var result = SassCompiler.CompileFile(file, options: new CompilationOptions { OutputStyle = OutputStyle.Compressed });

				var newFile = fileInfo.FullName.Replace(fileInfo.Extension, ".css");

				if (File.Exists(newFile) && result.CompiledContent == await File.ReadAllTextAsync(newFile))
					continue;

				await File.WriteAllTextAsync(newFile, result.CompiledContent);
			}
		}
	}
}
