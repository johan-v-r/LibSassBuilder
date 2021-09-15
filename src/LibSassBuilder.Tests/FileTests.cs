using System.IO;
using Xunit;

namespace LibSassBuilder.Tests
{
	// This project is configured to run LibSassBuilder in LibSassBuilder.Tests.csproj
	public class FileTests
	{
		private readonly string _fileDirectory;

		public FileTests()
		{
			_fileDirectory = Path.Join(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "test-files");
		}

		[Theory]
		[InlineData("test-new-format.css")]
		[InlineData("test-indented-format.css")]
		[InlineData("test-dart-format.css")]
		public void FileExistsTest(string cssFileName)
		{
			var cssFilePath = Path.Join(_fileDirectory, cssFileName);

			Assert.True(File.Exists(cssFilePath));

			File.Delete(cssFilePath);
		}

		[Theory]
		[InlineData("", "_ignored.css")]
		[InlineData("bin", "bin-file.css")]
		[InlineData("logs", "logs-file.css")]
		[InlineData("node_modules", "app.css")]
		[InlineData("obj", "obj-file.css")]
		public void ExcludedFilesTest(string subFolder, string cssFileName)
		{
			var cssFilePath = Path.Join(_fileDirectory, subFolder, cssFileName);

			Assert.False(File.Exists(cssFilePath));
		}
	}
}
