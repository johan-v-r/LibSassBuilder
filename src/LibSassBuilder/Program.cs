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
			var locations = args.Length == 0
				? new[] // When no argument is given, start at current directory
				{
					Directory.GetCurrentDirectory()
				}
				: args;

			foreach (var location in locations) 
			{
				if (File.Exists(location))
				{
					if (location.EndsWith(".sass-list", StringComparison.OrdinalIgnoreCase))
					{
						Console.WriteLine($"Sass compile file-list: {location}");
						var files = await File.ReadAllLinesAsync(location);
						await CompileFilesAsync(files
							.Where(l => !string.IsNullOrWhiteSpace(l))
							.Select(l => l.Trim()));
					}
					else
					{
						Console.WriteLine($"Sass compile file: {location}");
						await CompileFileAsync(new FileInfo(location));
					}
				}
				else
				{
					Console.WriteLine($"Sass compile directory: {location}");

					await CompileDirectoriesAsync(location);
				}
			}

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
				await CompileFileAsync(fileInfo);
			}
		}

		static async Task CompileFileAsync(FileInfo file)
		{
			if (file.Name.StartsWith("_")) 
			{
				return;
			}

			var result = SassCompiler.CompileFile(file.FullName, options: new CompilationOptions { OutputStyle = OutputStyle.Compressed });

			var newFile = Path.ChangeExtension(file.FullName, ".css");

			if (!File.Exists(newFile) ||
				result.CompiledContent != await File.ReadAllTextAsync(newFile))
			{
				await File.WriteAllTextAsync(newFile, result.CompiledContent);
			}
		}
	}
}
