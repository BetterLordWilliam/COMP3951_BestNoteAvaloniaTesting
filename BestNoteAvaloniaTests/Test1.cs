using BestNoteAvalonia.Services;
using System.Diagnostics;

namespace BestNoteAvaloniaTests
{
    [TestClass]
    public sealed class Test1
    {
        public BestNoteFileManagerService bs = new BestNoteFileManagerService();

        /// <summary>
        /// Test for adding a folder to the file system.
        /// </summary>
        [TestMethod]
        public void TestRootDirectory()
        {
            // Get the root contents of the parent file
            DirectoryInfo output = bs.GetRootContents();
            Assert.IsNotNull(output);
            Debug.WriteLine($"Best note app data directory {output.FullName}");
        }

        /// <summary>
        /// Test for validatitng the root directory was created.
        /// </summary>
        [TestMethod]
        public void TestNoteDirectory()
        {
            // Get the root contents of the parent file
            TestRootDirectory();
            DirectoryInfo output = bs.GetNotesContents();
            Assert.IsNotNull(output);
            Debug.WriteLine($"Best note notes directory {output.FullName}");
        }

        /// <summary>
        /// Test for adding folders to the file system.
        /// </summary>
        [TestMethod]
        public void TestAddFolder()
        {
            TestNoteDirectory();
            DirectoryInfo output = bs.AddFolder("Will Testing Notes");
            Assert.IsNotNull(output);
            Debug.WriteLine($"Best note new folder directory {output.FullName}\nBest note new folder name {output.Name}");
        }
    }
}
