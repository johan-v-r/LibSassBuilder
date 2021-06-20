using System.IO;
using Xunit;

namespace LibSassBuilder.DirectoryTests
{
	// This project is configured to run LibSassBuilder in LibSassBuilder.DirectoryTests.csproj within ./logs directory
	public class DirectoryTests
	{
		private readonly string _fileDirectory;

		public DirectoryTests()
		{
			_fileDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
		}

		[Fact]
		public void ExplicitDirectoryTest()
		{
			var barFile = Path.Join(_fileDirectory, "foo/bar.css");
			var binFile = Path.Join(_fileDirectory, "logs/bin/bin-file.css");
			var logsFile = Path.Join(_fileDirectory, "logs/logs-file.css");
			
			Assert.False(File.Exists(barFile)); // not in ./logs directory
			Assert.False(File.Exists(binFile)); // inside ./logs, but excluded by default nested bin folder
			Assert.True(File.Exists(logsFile)); // inside ./logs
			
			File.Delete(logsFile);
		}

		[Fact]
		public void IncludedDirectoryTest()
        {
			var dialogsFile = Path.Join(_fileDirectory, "logs/dialogs/dialog-file.css");

			Assert.True(File.Exists(dialogsFile)); // inside ./logs/dialogs directory, but included as it doesn't explicitly match "logs"

			File.Delete(dialogsFile);
		}
	}
}
