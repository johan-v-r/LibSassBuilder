using LibSassHost;
using System;
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

			var sassFiles = Directory.GetFiles(searchDirectory, "*.scss", SearchOption.AllDirectories);

			foreach (var file in sassFiles)
			{
				var fileInfo = new FileInfo(file);
				if (fileInfo.Name.StartsWith("_")) continue;

				var result = SassCompiler.CompileFile(file, options: new CompilationOptions { OutputStyle = OutputStyle.Compact });

				var newFile = fileInfo.FullName.Replace(fileInfo.Extension, ".css");
				await File.WriteAllTextAsync(newFile, result.CompiledContent);
			}

			Console.WriteLine("Sass files compiled");
		}
	}
}
