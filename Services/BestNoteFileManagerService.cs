using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestNoteAvalonia.Services;

/*
 Directory structure outline.

# Windows
C:\..\AppData\Roaming\
# Linux
tbd

# Application structure
BestNote (Root)
| Notes
  | UserFolder
  | UserFolder1
  | NoteFile.md

etc.

 */

public class BestNoteFileManagerService
{
    private DirectoryInfo AppDirectory;                // Application data directory

    private DirectoryInfo BestNoteDirectory;           // Notes directory

    /// <summary>
    /// Service constructor. Use with dependency injection.
    /// </summary>
    public BestNoteFileManagerService()
    {
        // Define the directory, possible configureable, for now ..\OS_Data\BestNote\...
        string appDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BestNote");
        // Define the notes directory, possible configureable, for now notes
        string bestNoteDirectory = Path.Combine(appDirectory, "Notes");

        if (!Directory.Exists(appDirectory))
        {
            // Create directory information objects
            Directory.CreateDirectory(appDirectory);
        }
        AppDirectory = new DirectoryInfo(appDirectory);

        if (!Directory.Exists (bestNoteDirectory))
        {
            // Create directory information objects
            Directory.CreateDirectory(bestNoteDirectory);
        }
        BestNoteDirectory = new DirectoryInfo(bestNoteDirectory);
    }

    /// <summary>
    /// Returns the contents of BestNote root directory.
    /// </summary>
    /// <returns></returns>
    public DirectoryInfo GetRootContents()
    {        
        // Testing output
        return AppDirectory;
    }

    /// <summary>
    /// Returns the contents of the Bestnote Notes directory.
    /// </summary>
    /// <returns></returns>
    public DirectoryInfo GetNotesContents()
    {
        // Testing output
        return BestNoteDirectory;
    }

    /// <summary>
    /// Create a folder in the file system. Parent folder path is not required.
    /// </summary>
    /// <param name="ParentPath"></param>
    /// <param name="folderName"></param>
    /// <returns></returns>
    public DirectoryInfo AddFolder(string folderName, string parentPath = "")
    {
        // Create the directory if is does not exist
        string combinedPath = Path.Combine(BestNoteDirectory.FullName, parentPath, folderName);
        if (Directory.Exists(combinedPath))
            return new DirectoryInfo(combinedPath);
        return Directory.CreateDirectory(combinedPath);
    }

    /// <summary>
    /// Creates a file in inside of the parent directory optionally within a specified parent.
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="fileExtension"></param>
    /// <param name="parentPath"></param>
    /// <returns></returns>
    public async Task AddFileToDirectory(string fileName, string fileExtension, string parentPath = "")
    {
        // Create the directory if it does not exist
        //Directory.CreateDirectory(notesDirectory);
    }
}
