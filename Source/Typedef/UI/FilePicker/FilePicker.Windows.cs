#if WINDOWS

using System;
using System.Windows.Forms;
using RipeLib;

namespace RipeConsole
{
// Native Windows file dialogs

internal static partial class FilePicker
{
// Open file dialog

public static string OpenFile(string title, string filter = "All files (*.*)|*.*")
{

using OpenFileDialog dialog = new()
{
Title = title,
Filter = filter,
CheckFileExists = true,
RestoreDirectory = true,
Multiselect = false
};

ConsoleWriter.WriteInfo("Opening file dialog...");

if(dialog.ShowDialog() == DialogResult.OK)
return dialog.FileName;

ConsoleWriter.WriteWarn("No file selected. Switching to manual input...\n");

return null;
}

// Save file dialog

public static string SaveFile(string title, string filter = "All files (*.*)|*.*",
                              string fileName = null)
{

using SaveFileDialog dialog = new()
{
Title = title,
Filter = filter,
RestoreDirectory = true,
FileName = fileName,
};

ConsoleWriter.WriteInfo("Opening save dialog...");

if(dialog.ShowDialog() == DialogResult.OK)
return dialog.FileName;

ConsoleWriter.WriteWarn("No file selected. Switching to manual input...\n");

return null;
}

// Open folder dialog

public static string OpenFolder(string description = "Select a folder", string initialDir = null)
{

using FolderBrowserDialog dialog = new()
{
Description = description,
UseDescriptionForTitle = true
};

if(!string.IsNullOrWhiteSpace(initialDir) )
dialog.InitialDirectory = initialDir;

ConsoleWriter.WriteInfo("Opening folder picker...");

if(dialog.ShowDialog() == DialogResult.OK)
return dialog.SelectedPath;

ConsoleWriter.WriteWarn("No folder selected. Switching to manual input...\n");

return null;
}

}

}

#endif