using System;
using System.Diagnostics;
using System.Text;
using RipeLib;

namespace RipeConsole
{
// Main program

public class Program
{
// App logo

private const string LOGO = @"
██████╗ ██╗██████╗ ███████╗
██╔══██╗██║██╔══██╗██╔════╝
██████╔╝██║██████╔╝█████╗  
██╔══██╗██║██╔═══╝ ██╔══╝  
██║  ██║██║██║     ███████╗
╚═╝  ╚═╝╚═╝╚═╝     ╚══════╝
";

// Check for CLI mode

private static bool IsCliMode(string[] args, out int choice, out string warnMsg)
{
choice = -1;
warnMsg = null;

if(args.Length <= 1)
return false;

string lastArg = args[^1];

if(!lastArg.StartsWith('@') )
return false;

if(!int.TryParse(lastArg[1 ..], out int parsed) )
return false;

if(!Menu.FunctionExists(parsed) )
{
warnMsg = $"Function not found: '{parsed}'. Switching to Fast mode.\n";

return false;
}

choice = parsed;

return true;
}

// Build console title

private static string MakeTitle(bool isCli)
{
string title = isCli ? "Ripe CLI" : RipeInfo.GetTitle();
string version = " v" + RipeInfo.GetVersion();

string build = RipeInfo.IsDebug() ? " (Debug)" : "";
string adminFlags = Environment.IsPrivilegedProcess ? "admin: " : "";

return adminFlags + title + version + build;
}

// Setup console

private static void SetupConsole(bool isCli)
{
Console.Title = MakeTitle(isCli);
Console.OutputEncoding = Encoding.UTF8;

if(SettingsManager.Current.LogLevel != LoggerLevel.Disabled)
{
TraceLogger.Init();

var outConsole = Console.OpenStandardOutput();
TraceLogger.SetOutputStream(outConsole);
}

}

// Write logo (ASCII ART)

private static void PrintLogo()
{
ConsoleWriter.WriteColored(LOGO, ConsoleColor.DarkYellow);

Console.WriteLine();
}

// Welcome screen

private static void WelcomeScreen()
{
ConsoleWriter.WriteHeader("Welcome to RipeConsole!", ConsoleColor.DarkGreen);

PrintLogo();

Console.WriteLine(RipeInfo.GetCopyright() + "\n");

string desc = "RIPE is a tool that handles several kind of files from PopCap Games.";
string desc2 = "You can use it for parsing files from most of their titles and create your own MODS.\n";

ConsoleWriter.WriteColored(desc, ConsoleColor.Magenta);
ConsoleWriter.WriteColored(desc2, ConsoleColor.Magenta);

ConsoleWriter.WriteColored("Made with <3 by FranZ, enjoy!\n", ConsoleColor.DarkRed);
}

// Print arguments

private static void PrintArgs(string[] args, bool isCli)
{
string displayArgs = string.Join(", ", args);

string text = $"Arguments loaded: {displayArgs}\n";
ConsoleWriter.WriteColored(text, ConsoleColor.DarkYellow);

if(isCli)
TraceLogger.WriteDebug(text);

}

// Show Welcome screen

private static void ShowWelcome(bool isCli, string[] args, string warnMsg)
{
bool showWelcome = SettingsManager.Current.ShowWelcomeScreen && !isCli;
bool debugInfo = SettingsManager.Current.ShowDebugInfo && !isCli;

bool displayArgs = SettingsManager.Current.DisplayArgs && args.Length > 0;
bool showWarn = warnMsg != null;

if(!showWelcome && !debugInfo && !displayArgs && !showWarn)
return;

if(showWelcome)
WelcomeScreen();

if(debugInfo)
RipeHub.RuntimeInfo();

if(displayArgs)
PrintArgs(args, isCli);

if(showWarn)
ConsoleWriter.WriteWarn(warnMsg);

if(!isCli)
ContinueDialog.Display();

}

// Save logs if enabled

private static void SaveLogs(int exitCode)
{
var logMode = SettingsManager.Current.LogLevel;
bool shouldSave = logMode == LoggerLevel.Full || (logMode == LoggerLevel.ErrorsOnly && exitCode != 0);

if(shouldSave)
TraceLogger.SaveLogs();

}

// Notify task completion

private static void NotifyCompletion(int exitCode, string taskName, string elapsed)
{
#if WINDOWS

var mode = SettingsManager.Current.NotifyTaskCompletion;
bool isBackground = WindowHelper.IsConsoleMinimized() || WindowHelper.IsConsoleInBackground();

bool shouldNotify = mode switch
{
NotificationMode.Always => true,
NotificationMode.BackgroundOnly => isBackground,
 _ => false
};

if(shouldNotify)
{
string status = exitCode == 0 ? "ended succesfully!" : "failed.";
string noteContent = $"{taskName} {status}";

if(elapsed != null)
noteContent += $"\n(Elapsed: {elapsed})";

NotificationHelper.ShowToast("Task completed", noteContent);
}

#endif
}

// Logic executor

private static int Run(string[] args, string inputPath, int? choice, bool isCli)
{
int exitCode = 0;

Stopwatch timer = new();
string taskName = "Task";

try
{
var action = Menu.Display(inputPath, choice);
taskName = action.Name;

if(isCli)
TraceLogger.WriteLine($"[CLI] Function call: {taskName} ({choice})\n");

ConsoleWriter.WriteHeader(taskName, ConsoleColor.DarkYellow);

ConsoleWriter.WriteColored("Execution started:\n", ConsoleColor.Magenta);

timer.Start();
action.Execute(args);

Console.WriteLine("\n");
}

catch(Exception error)
{
ConsoleWriter.WriteError(error);

exitCode = 1;
}

finally
{
timer.Stop();

ConsoleWriter.WriteColored("Execution complete!\n", ConsoleColor.Magenta);

bool showElapsed = SettingsManager.Current.ShowExecutionTime;
string elapsed = showElapsed ? timer.GetExactTime() : null;

if(showElapsed)
ConsoleWriter.WriteColored($"Total elapsed: {elapsed}", ConsoleColor.DarkGreen);

NotifyCompletion(exitCode, taskName, elapsed);
}

return exitCode;
}

// Exit program (returns true if should leave app opened, false otherwise)

private static bool Exit(bool isCli)
{

if(isCli)
return false;

switch(SettingsManager.Current.ExitAction)
{
case ProgramExitAction.Exit:
return false;

case ProgramExitAction.Return:
Console.Clear();

return true;

default:
break;
}

Console.WriteLine();

ConsoleWriter.WriteHeader("Exit RIPE", ConsoleColor.DarkYellow);

Console.WriteLine("Press [R] to return to Main menu.");
Console.WriteLine("Enter [any other key] to Exit.\n");

ConsoleWriter.WriteColored("> Select operation: ", ConsoleColor.Cyan, false);
ConsoleKeyInfo keyInfo = Console.ReadKey(false);

Console.Clear();

return keyInfo.Key == ConsoleKey.R;
}

// App Launcher

[STAThread]

public static int Main(string[] args)
{
SettingsManager.Load();
ArgsManager.Load();

string inputPath = args.Length > 0 ? args[0] : null;

bool isCli = IsCliMode(args, out int parsedChoice, out string warnMsg);
int? choice = isCli ? parsedChoice : null;

SetupConsole(isCli);
ShowWelcome(isCli, args, warnMsg);

int exitCode;

do
{
exitCode = Run(args, inputPath, choice, isCli);

if(isCli)
break;

args = [];
inputPath = null;

choice = null;
isCli = false;
}

while(Exit(isCli) );

TraceLogger.ClearOutputStream();

TraceLogger.WriteLine($"[RIPE] Process ended with code: {exitCode}");
SaveLogs(exitCode);

return exitCode;
}

}

}