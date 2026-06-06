using System;
using System.IO;
using RipeLib;

namespace RipeConsole
{
// RIPE Settings handler

public static class SettingsManager
{
// File name

private const string FILE_NAME = "AppSettings.json";

// Current instance

public static RipeSettings Current{ get; private set; } = new();

// Get settings path

private static string GetSettingsPath() => Path.Combine(AppContext.BaseDirectory, FILE_NAME);

// Open settings menu

public static void Open()
{
ISettingsEditor editor;

#if WINDOWS

if(Current.UseGuiSettings)
editor = new WinFormsSettingsEditor();

else
#endif

editor = new SettingsConsoleEditor();
 
if(editor.Edit(Current) )
Save();

}

// Reset settings

public static void Reset()
{
bool shouldReset = TypeDialog.Display();

if(!shouldReset)
{
ConsoleWriter.WriteWarn("Operation cancelled: Reset App Settings.\n");

return;
}

Current = new();

Save();
}

// Load settings

public static void Load()
{

try
{
string path = GetSettingsPath();

if(!File.Exists(path) )
{
Current = new();

Save();

return;
}

using var reader = FileManager.OpenRead(path);
var settings = JsonSerializer.DeserializeObject<RipeSettings>(reader, RipeSettings.Context);

Current = settings ?? new();
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

// Save json

public static void Save()
{
string path = GetSettingsPath();

using var writer = File.Create(path);
JsonSerializer.SerializeObject(Current, writer, RipeSettings.Context);
}

}

}