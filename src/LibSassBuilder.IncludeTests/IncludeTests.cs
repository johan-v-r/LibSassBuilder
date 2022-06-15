using System.IO;
using Xunit;

namespace LibSassBuilder.IncludeTests
{
	// This project is configured to run LibSassBuilder in LibSassBuilder.Tests.csproj
	public class IncludeTests
	{
		private readonly string _fileDirectory;

		public IncludeTests()
		{
			_fileDirectory = Path.Join(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "test-files");
		}

		[Theory]
		[InlineData("wwwroot", "someStyle.css")]
		public void FilesTest(string subFolder, string cssFileName)
		{
			var cssFilePath = Path.Join(_fileDirectory, subFolder, cssFileName);

			Assert.True(File.Exists(cssFilePath));

			File.Delete(cssFilePath);
		}

		[Theory]
		[InlineData("vars", "_variables.css")]
		public void ExcludedFilesTest(string subFolder, string cssFileName)
		{
			var cssFilePath = Path.Join(_fileDirectory, subFolder, cssFileName);

			Assert.False(File.Exists(cssFilePath));
		}
	}
}
