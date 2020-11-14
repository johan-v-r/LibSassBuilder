using System.IO;
using Xunit;

namespace LibSassBuilder.Tests
{
	// This project is configured to run LibSassBuilder in LibSassBuilder.Tests.csproj
	public class FileTests
	{
		[Fact]
		public void FileExistsTest()
		{
			var fileDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
			var cssFilePath = Path.Join(fileDirectory, "test.css");

			Assert.True(File.Exists(cssFilePath));

			File.Delete(cssFilePath);
		}
	}
}
