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
		private static readonly List<string> _excludedDirectories = new List<string>
		{
			"bin",
			"obj",
			"logs",
			"node_modules"
		};

		static async Task Main(string[] args)
		{
			var searchDirectory = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();
			Console.WriteLine($"Sass compile directory: {searchDirectory}");

			await CompileDirectoriesAsync(searchDirectory);

			Console.WriteLine("Sass files compiled");
		}

		static async Task CompileDirectoriesAsync(string directory)
		{
			var sassFiles = Directory.EnumerateFiles(directory)
				.Where(file => file.EndsWith(".scss", StringComparison.OrdinalIgnoreCase) || file.EndsWith(".sass", StringComparison.OrdinalIgnoreCase));

			await CompileFilesAsync(sassFiles);

			var subDirectories = Directory.EnumerateDirectories(directory);
			foreach (var subDirectory in subDirectories)
			{
				if (_excludedDirectories.Any(dir => subDirectory.EndsWith(dir, StringComparison.OrdinalIgnoreCase)))
					continue;

				await CompileDirectoriesAsync(subDirectory);
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
