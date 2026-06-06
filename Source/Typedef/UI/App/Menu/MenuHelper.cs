using System;

namespace RipeConsole
{
// Helper for manual menus

internal static class MenuHelper
{

// Print option

public static void PrintOption(int number, string label, object val = null)
{

if(val is null)
Console.WriteLine($"{number,2}. {label,-30}");

else
Console.WriteLine($"{number,2}. {label,-30}: {val}");

}

}

}