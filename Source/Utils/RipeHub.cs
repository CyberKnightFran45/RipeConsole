using System;
using System.Runtime.InteropServices;
using RipeLib;

namespace RipeConsole
{
// Additional funcs for RIPE

internal static class RipeHub
{
// About

public static void About()
{
ConsoleWriter.WriteBanner("About RIPE", ConsoleColor.Blue);

Console.WriteLine($"App Name     : {RipeInfo.GetTitle()}");
Console.WriteLine($"Type         : {RipeInfo.GetAppType()}");
Console.WriteLine($"Version      : {RipeInfo.GetVersion()}");
Console.WriteLine($"Description  : {RipeInfo.GetDescription()}");
Console.WriteLine($"Author       : {RipeInfo.GetAuthorName()}");
Console.WriteLine($"Copyright    : {RipeInfo.GetCopyright()}");
Console.WriteLine($"License      : {RipeInfo.GetLicense()}\n");
}

// Next page

private static void NextPage(ref int page)
{
ContinueDialog.Display($"Press ENTER or any key to continue (Page {page}/4)");

page++;
}

// Show user manual

private static void UserManual(ref int page)
{
ConsoleWriter.WriteHeader("RIPE: User manual", ConsoleColor.DarkYellow);

string brief = "RIPE is a console application designed to run multiple file-processing tools, "
             + "specifically tailored for PopCap games.\n";

Console.WriteLine(brief);
	 
string brief2 = "Supports various execution modes, catering to both interactive users "
              + "and script-based automation.\n";

Console.WriteLine(brief2);

Console.WriteLine("Execution modes:\n");

ConsoleWriter.WriteColored("1. Interactive Mode", ConsoleColor.Magenta);
ConsoleWriter.WriteColored("2. Fast Mode (Drag & Drop)", ConsoleColor.Magenta);
ConsoleWriter.WriteColored("3. CLI Mode (Command Line Interface)\n", ConsoleColor.Magenta);

NextPage(ref page);
}

// Mode description: interactive

private static void ModeDesc_Interactive(ref int page)
{
ConsoleWriter.WriteBanner("INTERACTIVE MODE", ConsoleColor.Magenta);

string desc = "Default mode. You must navigate options through a menu. Here's a step-by-step:\n";
Console.WriteLine(desc);

string step1 = "1. Category selection: enter the number in front of the category for selecting it.\n";
string step2 = "2. Function selection: enter the number in front of the function for selecting it.\n";
string step3 = "3. Input prompt: fill the requested parameters before proceed.\n";

ConsoleWriter.WriteColored(step1, ConsoleColor.DarkYellow);
ConsoleWriter.WriteColored(step2, ConsoleColor.DarkYellow);
ConsoleWriter.WriteColored(step3, ConsoleColor.DarkYellow);

NextPage(ref page);
}

// Mode description: fast

private static void ModeDesc_Fast(ref int page)
{
ConsoleWriter.WriteBanner("FAST MODE", ConsoleColor.Magenta);

string desc = "Activated when passing a file or folder to the program as an argument (Drag & Drop).";
string desc2 = "In this mode, options are filtered according to file type, making menu simplier.\n";

Console.WriteLine(desc);
Console.WriteLine(desc2);

Console.WriteLine("Here's a step-by-step:\n");

var step1 = "1. Operation selection: enter the number in front of the category/function for selecting it.\n";
var step2 = "2. Input prompt: fill the requested parameters before proceed.\n";

ConsoleWriter.WriteColored(step1, ConsoleColor.DarkYellow);
ConsoleWriter.WriteColored(step2, ConsoleColor.DarkYellow);

NextPage(ref page);
}

// Mode description: CLI

private static void ModeDesc_CLI(ref int page)
{
ConsoleWriter.WriteBanner("CLI MODE", ConsoleColor.Magenta);

var desc = "Command Line Interface. Allows you to execute actions directly without user interaction.\n";
Console.WriteLine(desc);

ConsoleWriter.WriteColored("Sintax: program.exe <input> [output] @<id>\n", ConsoleColor.DarkYellow);

ConsoleWriter.WriteBanner("RULES", ConsoleColor.Red);

string ruleA = "- <input>: Input path (file or folder)";
string ruleB = "- [output]: Output path (optional, depends on the action)";
string ruleC = "- <args>: Additional arguments (depends on the action)";
string ruleD = "- <id>: Identifier of the action to be executed (required for CLI)\n";

ConsoleWriter.WriteColored(ruleA, ConsoleColor.DarkYellow);
ConsoleWriter.WriteColored(ruleB, ConsoleColor.DarkYellow);
ConsoleWriter.WriteColored(ruleC, ConsoleColor.DarkYellow);
ConsoleWriter.WriteColored(ruleD, ConsoleColor.DarkYellow);

ConsoleWriter.WriteBanner("EXAMPLE", ConsoleColor.Red);

string example = @"program.exe “C:\file.txt” “C:\output.txt” false @160";
ConsoleWriter.WriteColored(example, ConsoleColor.DarkGreen);

Console.WriteLine();

string explain = "Explanation: the following command opens RIPE and encodes the provided file with base64.";
string explain2 = "Here's an overview of the arguments passed:\n";

Console.WriteLine(explain);
Console.WriteLine(explain2);

string exDetailsA = "- <input>: C:/file.txt";
string exDetailsB = "- [output]: C:/output.txt";
string exDetailsC = "- <args>: false (Use Web-safe Base64)";
string exDetailsD = "- <id>: 160 (Base64 Parser - Encode)\n";

ConsoleWriter.WriteColored(exDetailsA, ConsoleColor.DarkGreen);
ConsoleWriter.WriteColored(exDetailsB, ConsoleColor.DarkGreen);
ConsoleWriter.WriteColored(exDetailsC, ConsoleColor.DarkGreen);
ConsoleWriter.WriteColored(exDetailsD, ConsoleColor.DarkGreen);

string tip = "Tip: you can use PowerShell to automate function calls from RIPE\n";

ConsoleWriter.WriteColored(tip, ConsoleColor.DarkYellow);

NextPage(ref page);
}

// Full help

private static void FullHelp()
{
int page = 1;

UserManual(ref page);

ModeDesc_Interactive(ref page);
ModeDesc_Fast(ref page);
ModeDesc_CLI(ref page);
}

// Quick help

private static void QuickHelp()
{
ConsoleWriter.WriteHeader("RIPE: Quick Help", ConsoleColor.DarkYellow);

Console.WriteLine("You launched RIPE with a file or folder as argument.\n");

ConsoleWriter.WriteBanner("How it works", ConsoleColor.Magenta);

Console.WriteLine("1. Select an operation from the menu.");
Console.WriteLine("2. Fill in any additional parameters if prompted.");
Console.WriteLine("3. Done — output is generated automatically.\n");

ConsoleWriter.WriteBanner("Tips", ConsoleColor.Magenta);

Console.WriteLine("- Only compatible operations with your file type are shown.");

Console.WriteLine("- For full help and CLI usage, run RIPE without arguments.\n");

ContinueDialog.Display();
}

// Show help

public static void ShowHelp(string[] args)
{
Console.Clear();

if(args.Length > 0)
QuickHelp();

else
FullHelp();

}

// Get architecture flags

private static string GetArchitecture()
{
Architecture osArch = RuntimeInformation.OSArchitecture;
Architecture processArch = RuntimeInformation.ProcessArchitecture;

if(osArch == processArch)
return osArch.ToString();

return $"{osArch} (Process is {processArch})";
}

// Display runtime info (short)

public static void RuntimeInfo()
{
ConsoleWriter.WriteBanner("Runtime info", ConsoleColor.Blue);

Console.WriteLine($"Modules loaded    : {PerformanceInfo.ModulesLoaded}");
Console.WriteLine($"OS                : {Environment.OSVersion}");
Console.WriteLine($"Architecture      : {GetArchitecture()}");
Console.WriteLine($"Is 64-bit         : {Environment.Is64BitProcess}\n");
}

// Display runtime info

public static void RuntimeInfoFull()
{
ConsoleWriter.WriteBanner("Runtime info", ConsoleColor.Blue);

Console.WriteLine($"PID               : {Environment.ProcessId}");
Console.WriteLine($"Start Time        : {PerformanceInfo.ProcessStartTime}");
Console.WriteLine($"Running as admin  : {Environment.IsPrivilegedProcess}");
Console.WriteLine($"Modules loaded    : {PerformanceInfo.ModulesLoaded}");
Console.WriteLine($"OS                : {Environment.OSVersion}");
Console.WriteLine($"Architecture      : {GetArchitecture()}");
Console.WriteLine($"Is 64-bit         : {Environment.Is64BitProcess}");
Console.WriteLine($"Processors count  : {Environment.ProcessorCount}\n");
}

// Get process working set

private static string GetAppWorkSet()
{
var memoryUsage = SizeT.FormatSize(PerformanceInfo.MemoryUsage);
var peakUsage = SizeT.FormatSize(PerformanceInfo.PeakMemoryUsage);

return $"Current: {memoryUsage} | Peak: {peakUsage}";
}

// Show App performance

public static void ShowPerformance()
{
ConsoleWriter.WriteBanner("App performance", ConsoleColor.Blue);

var cpuTime = PerformanceInfo.ProcessorTime;

Console.WriteLine($"Threads running    : {PerformanceInfo.ThreadsCount}");
Console.WriteLine($"Memory Usage       : {GetAppWorkSet()}");
Console.WriteLine($"CPU Time           : {cpuTime.GetExactTime()}\n");
}

// Display Build info

public static void BuildInfo()
{
ConsoleWriter.WriteBanner("Build info", ConsoleColor.Blue);

Console.WriteLine($"Package ID       : {RipeInfo.GetPackageId()}");
Console.WriteLine($"Compilation Time : {RipeInfo.GetBuildDate()}");
Console.WriteLine($"Configuration    : {RipeInfo.GetConfiguration()}");
Console.WriteLine($"Build version    : {RipeInfo.GetBuildVersion()}");
Console.WriteLine($"Target framework : {AppContext.TargetFrameworkName}");
}

}

}