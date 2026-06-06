using System;
using System.Diagnostics;

namespace RipeConsole
{
// Retrives performance info from Current process

internal static class PerformanceInfo
{
// Current assembly

private static readonly Process currentProcess = Process.GetCurrentProcess();

// Get memory usage

public static long MemoryUsage => currentProcess.PrivateMemorySize64;

// Get peak memory usage

public static long PeakMemoryUsage => currentProcess.PeakWorkingSet64;

// Get total processor time

public static TimeSpan ProcessorTime => currentProcess.TotalProcessorTime;

// Get modules loaded

public static int ModulesLoaded => currentProcess.Modules.Count;

// Get threads count

public static int ThreadsCount => currentProcess.Threads.Count;

// Get process start time

public static DateTime ProcessStartTime => currentProcess.StartTime;
}

}