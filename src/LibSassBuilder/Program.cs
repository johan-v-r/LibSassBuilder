using LibSassHost;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace LibSassBuilder
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var searchDirectory = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();
			Console.WriteLine($"Sass compile directory: {searchDirectory}");

			var scssFiles = Directory.GetFiles(searchDirectory, "*.scss", SearchOption.AllDirectories);
			var sassFiles = Directory.GetFiles(searchDirectory, "*.sass", SearchOption.AllDirectories);

			await CompileFilesAsync(scssFiles);
			await CompileFilesAsync(sassFiles);

			Console.WriteLine("Sass files compiled");
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
