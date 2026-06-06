using System;
using RipeLib;

namespace RipeConsole
{
// Type to reset dialog

internal static class TypeDialog
{
// Display

public static bool Display(string keyword = "RESET")
{
string text = ConsoleReader.ReadString($"Type '{keyword}' to continue", true);

return string.Equals(text, keyword, StringComparison.OrdinalIgnoreCase);
}

}

}