#if WINDOWS

using System;
using System.Runtime.InteropServices;

namespace RipeConsole
{
// Native helper for Window state

internal static class WindowHelper
{
// P/Invoke

[DllImport("kernel32.dll") ]

public static extern IntPtr GetConsoleWindow();

[DllImport("user32.dll")]

private static extern IntPtr GetForegroundWindow();

[DllImport("user32.dll")]

private static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

// Flags

private const int SW_SHOWMINIMIZED = 2;

// Check if console is running in background

public static bool IsConsoleInBackground()
{
var hForeground = GetForegroundWindow();
var hConsole = GetConsoleWindow();

return hConsole != IntPtr.Zero && hForeground != hConsole;
}

// Check if console is minimized

public static bool IsConsoleMinimized()
{
IntPtr hWnd = GetConsoleWindow();

if(hWnd == IntPtr.Zero)
return false;

WINDOWPLACEMENT placement = new();
placement.length = Marshal.SizeOf(placement);

if(GetWindowPlacement(hWnd, ref placement) )
return placement.showCmd == SW_SHOWMINIMIZED;

return false;
}

}

}

#endif