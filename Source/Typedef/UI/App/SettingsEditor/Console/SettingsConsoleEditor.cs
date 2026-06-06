using System;
using RipeLib;

namespace RipeConsole
{
// Settings editor through console

internal sealed class SettingsConsoleEditor : ISettingsEditor
{
// Apply changes

private static void Apply(RipeSettings src, RipeSettings dest)
{
dest.ShowWelcomeScreen = src.ShowWelcomeScreen;
dest.LogLevel = src.LogLevel;

dest.ExitAction = src.ExitAction;
dest.GenerateOutputPaths = src.GenerateOutputPaths;

dest.AutoFillArgs = src.AutoFillArgs;
dest.UseNativeFilePicker = src.UseNativeFilePicker;

dest.ShowExitOption = src.ShowExitOption;
dest.ShowDebugInfo = src.ShowDebugInfo;

dest.DisplayArgs = src.DisplayArgs;
dest.UseGuiSettings = src.UseGuiSettings;

dest.UseGuiArgsEditor = src.UseGuiArgsEditor;
dest.NotifyTaskCompletion = src.NotifyTaskCompletion;

dest.ShowExecutionTime = src.ShowExecutionTime;
}

// Show options

private static void ShowOptions(RipeSettings settings)
{
ConsoleWriter.WriteHeader("RIPE Settings", ConsoleColor.DarkYellow);

MenuHelper.PrintOption(0, "Exit");
MenuHelper.PrintOption(1, "Show welcome screen", settings.ShowWelcomeScreen);
MenuHelper.PrintOption(2, "Log level", settings.LogLevel);
MenuHelper.PrintOption(3, "Exit action", settings.ExitAction);
MenuHelper.PrintOption(4, "Generate output paths", settings.GenerateOutputPaths);
MenuHelper.PrintOption(5, "Auto-fill args", settings.AutoFillArgs);
MenuHelper.PrintOption(6, "Use native file picker", settings.UseNativeFilePicker);
MenuHelper.PrintOption(7, "Show exit option", settings.ShowExitOption);
MenuHelper.PrintOption(8, "Show debug info", settings.ShowDebugInfo);
MenuHelper.PrintOption(9, "Display args", settings.DisplayArgs);
MenuHelper.PrintOption(10, "Use GUI settings editor", settings.UseGuiSettings);
MenuHelper.PrintOption(11, "Use GUI arguments editor", settings.UseGuiArgsEditor);
MenuHelper.PrintOption(12, "Notify task completion", settings.NotifyTaskCompletion);
MenuHelper.PrintOption(13, "Show task execution time", settings.ShowExecutionTime);
MenuHelper.PrintOption(14, "Save & Exit");

Console.WriteLine();
}

// Prompt

public bool Edit(RipeSettings settings)
{
RipeSettings temp = new(settings);

while(true)
{
Console.Clear();

ShowOptions(temp);

int option = ConsoleReader.ReadInt("Select option");

switch(option)
{
case 0:
Console.Clear();
return false; 

case 1:
temp.ShowWelcomeScreen = ConsoleReader.ReadBool("Show Welcome Screen");
break;

case 2:
temp.LogLevel = ConsoleReader.ReadEnum<LoggerLevel>("Select Log Level");
break;

case 3:
temp.ExitAction = ConsoleReader.ReadEnum<ProgramExitAction>("Select Exit Action");
break;

case 4:
temp.GenerateOutputPaths = ConsoleReader.ReadBool("Generate Output Paths");
break;

case 5:
temp.AutoFillArgs = ConsoleReader.ReadBool("Auto Fill Args");
break;

case 6:
temp.UseNativeFilePicker = ConsoleReader.ReadBool("Use Native File Picker");
break;

case 7:
temp.ShowExitOption = ConsoleReader.ReadBool("Show Exit Option");
break;

case 8:
temp.ShowDebugInfo = ConsoleReader.ReadBool("Show Debug Info");
break;

case 9:
temp.DisplayArgs = ConsoleReader.ReadBool("Display Args");
break;

case 10:
temp.UseGuiSettings = ConsoleReader.ReadBool("Use GUI Settings");
break;

case 11:
temp.UseGuiArgsEditor = ConsoleReader.ReadBool("Use GUI Args Editor");
break;

case 12:
temp.NotifyTaskCompletion = ConsoleReader.ReadEnum<NotificationMode>("Select Notifications Mode");
break;

case 13:
temp.ShowExecutionTime = ConsoleReader.ReadBool("Show Execution Time");
break;

case 14:
Apply(temp, settings);

Console.Clear();
return true;

default:
ConsoleWriter.WriteError("Invalid option");
break;
}

Console.WriteLine();
}

}

}

}