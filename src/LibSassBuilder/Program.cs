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
			await Parser.Default.ParseArguments<Options>(args)
				.WithNotParsed(e => Environment.Exit(1))
				.WithParsedAsync(async o =>
				{
					Console.WriteLine($"Sass compile directory: {o.Directory}");

					await CompileDirectoriesAsync(o.Directory, o.ExcludedDirectories);

					Console.WriteLine("Sass files compiled");
				});
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
