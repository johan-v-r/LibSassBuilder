using System.IO;
using Xunit;

namespace LibSassBuilder.Tests
{
	// This project is configured to run LibSassBuilder in LibSassBuilder.Tests.csproj
	public class FileTests
	{
		[Theory]
		[InlineData("test-new-format.css")]
		[InlineData("test-indented-format.css")]
		public void FileExistsTest(string cssFileName)
		{
			var fileDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
			var cssFilePath = Path.Join(fileDirectory, cssFileName);

			Assert.True(File.Exists(cssFilePath));

			File.Delete(cssFilePath);
		}
	}
}
