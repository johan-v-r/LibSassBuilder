using System.IO;
using Xunit;

namespace LibSassBuilder.ExcludeTests
{
	// This project is configured to run LibSassBuilder in LibSassBuilder.DirectoryTests.csproj excluding foo & bar directories
	public class ExcludeTests
	{
		private readonly string _fileDirectory;

		public ExcludeTests()
		{
			_fileDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
		}

		[Fact]
		public void ExcludeFooFilesTest()
		{
			var fooFile = Path.Join(_fileDirectory, "foo/foo.css");
			var barFile = Path.Join(_fileDirectory, "bar/bar.css");
			var testFile = Path.Join(_fileDirectory, "test.css");

			Assert.False(File.Exists(fooFile)); // excluded foo
			Assert.False(File.Exists(barFile)); // excluded bar
			Assert.True(File.Exists(testFile));

			File.Delete(testFile);
		}
	}
}
