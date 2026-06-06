using System;
using RipeLib;

namespace RipeConsole
{
// Continue dialog

internal static class ContinueDialog
{
// Display

public static void Display(string msg = "Press ENTER or any key to continue")
{
ConsoleWriter.WritePause(msg);

Console.Clear();
}

}

}