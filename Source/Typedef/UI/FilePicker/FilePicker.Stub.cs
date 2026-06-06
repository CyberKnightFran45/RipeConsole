#if !WINDOWS

namespace RipeConsole
{
// Stub for File Picker

internal static partial class FilePicker
{
// Open file dialog

public static string OpenFile(string title, string filter = null) => null;

// Save file dialog

public static string SaveFile(string title, string filter = null, string fileName = null) => null;
   
// Open folder dialog   

public static string OpenFolder(string description = null) => null;   
}

}

#endif