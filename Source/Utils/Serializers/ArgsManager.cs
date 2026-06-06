using System;
using System.IO;
using RipeLib;

namespace RipeConsole
{
// RIPE Arguments handler

public static class ArgsManager
{
// File name

private const string FILE_NAME = "Args.json";

// Current instance

public static RipeArgumentsSet Current{ get; private set; } = new();

// Get file path

private static string GetFilePath() => Path.Combine(AppContext.BaseDirectory, FILE_NAME);

// Open args editor

public static void Open()
{
IArgsEditor editor;

#if WINDOWS

if(SettingsManager.Current.UseGuiArgsEditor)
editor = new WinFormsArgsEditor();

else
#endif

editor = new ArgsConsoleEditor();
 
if(editor.Edit(Current) )
Save();

}

// Reset args

public static void Reset()
{
bool shouldReset = TypeDialog.Display();

if(!shouldReset)
{
ConsoleWriter.WriteWarn("Operation cancelled: Reset Arguments Sheet.\n");

return;
}

Current = new();

Save();
}

// Normalize paths to OS

private static void NormalizePaths()
{
string downloadFolder = Current.DownloadFolder;
PathHelper.NormalizePath(ref downloadFolder);

Current.DownloadFolder = downloadFolder;
}

// Load args

public static void Load()
{

try
{
string path = GetFilePath();

if(!File.Exists(path) )
{
Current = new();

Save();

return;
}

using var reader = FileManager.OpenRead(path);

var args = JsonSerializer.DeserializeObject<RipeArgumentsSet>(reader, RipeArgumentsSet.Context);
Current = args ?? new();

NormalizePaths();
}

catch
{
Current = new();

try
{
Save();
}

catch
{
// Ignore secondary failure
}

}

}

// Format paths to json

private static void FormatPaths()
{
string downloadFolder = Current.DownloadFolder;
PathHelper.DenormalizePath(ref downloadFolder);

Current.DownloadFolder = downloadFolder;
}

// Save json

public static void Save()
{
FormatPaths();

string path = GetFilePath();

using var writer = File.Create(path);
JsonSerializer.SerializeObject(Current, writer, RipeArgumentsSet.Context);
}

}

}