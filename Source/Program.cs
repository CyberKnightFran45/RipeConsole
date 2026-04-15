using System;
using System.Reflection;
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

// Current assembly

private static readonly Assembly appAssembly = Assembly.GetExecutingAssembly();

// Check for CLI mode

private static bool IsCliMode(string[] args, out int choice, out string warnMsg)
{
choice = -1;
warnMsg = null;

if(args.Length <= 1)
return false;

string lastArg = args[^1];

if(!lastArg.StartsWith("@"))
return false;

if(!int.TryParse(lastArg[1..], out int parsed) )
return false;

if(!Menu.FunctionExists(parsed) )
{
warnMsg = $"Function not found: '{parsed}'. Switching to Fast mode.\n";

return false;
}

choice = parsed;

return true;
}

// Get program version

private static string GetVersion()
{
return appAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
}

// Setup console

private static void SetupConsole(bool isCli)
{
TraceLogger.Init();

string title = isCli ? "Ripe CLI" : "RIPE Console";
Console.Title = $"{title} v{GetVersion()}";

Console.OutputEncoding = Encoding.UTF8;

var outConsole = Console.OpenStandardOutput();
TraceLogger.SetOutputStream(outConsole);
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

// Write logo (ASCII ART)

private static void PrintLogo()
{
ConsoleWriter.WriteColored(LOGO, ConsoleColor.DarkYellow);

Console.WriteLine();
}

// Continue dialog

private static void Continue(bool isCli)
{

if(isCli)
return;

ConsoleWriter.WritePause("Press ENTER or any key to continue");

Console.Clear();
}

// Welcome screen

private static void WelcomeScreen(bool isCli)
{

if(isCli)
return;

ConsoleWriter.WriteHeader("Welcome to RipeConsole!", ConsoleColor.DarkGreen);

PrintLogo();

string desc = "RIPE is a tool that handles several kind of files from PopCap Games.";
ConsoleWriter.WriteColored(desc, ConsoleColor.Magenta);

string desc2 = "You can use it for parsing files from most of their titles and create your own MODS.\n";
ConsoleWriter.WriteColored(desc2, ConsoleColor.Magenta);

ConsoleWriter.WriteColored("Made with <3 by FranZ, enjoy!\n", ConsoleColor.DarkRed);
}

// Show Welcome screen

private static void ShowWelcome(bool isCli, string[] args, string warnMsg)
{
WelcomeScreen(isCli);

if(args.Length > 0)
PrintArgs(args, isCli);

if(warnMsg != null)
ConsoleWriter.WriteWarn(warnMsg);

Continue(isCli);
}

// Logic executor

private static int Run(string[] args, string inputPath, int? choice, bool isCli)
{
int exitCode = 0;

try
{
var action = Menu.Display(inputPath, choice);

if(isCli)
TraceLogger.WriteLine($"[CLI] Function call: {action.Name} ({choice})\n");

ConsoleWriter.WriteHeader(action.Name, ConsoleColor.DarkYellow);
ConsoleWriter.WriteColored("Execution started:\n", ConsoleColor.Magenta);

action.Execute(args);

Console.WriteLine("\n");
ConsoleWriter.WriteColored("Execution complete!\n", ConsoleColor.Magenta);
}

catch(Exception error)
{
ConsoleWriter.WriteError(error);

exitCode = 1;
}

finally
{
TraceLogger.SaveLogs();

TraceLogger.ClearOutputStream();
}

return exitCode;
}

// Exit program

private static void Exit(bool isCli)
{

if(!isCli)
ConsoleWriter.WritePause("Press ENTER or any key to exit");

}

// App Launcher

public static int Main(string[] args)
{
string inputPath = args.Length > 0 ? args[0] : null;

bool isCli = IsCliMode(args, out int parsedChoice, out string warnMsg);
int? choice = isCli ? parsedChoice : null;

SetupConsole(isCli);
ShowWelcome(isCli, args, warnMsg);

int exitCode = Run(args, inputPath, choice, isCli);

Exit(isCli);

return exitCode;
}

}

}