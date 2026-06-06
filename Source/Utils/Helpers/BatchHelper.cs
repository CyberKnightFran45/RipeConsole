using System;
using RipeLib;

namespace RipeConsole
{
// Batch Helper

internal static class BatchHelper
{
// Process file or dir

public static void Process(string[] args, Action<string, string> execute, string actionName, 
                           string dirSuffix, string fileExt, Func<string, bool> filter,
						   string pickerFilter = "All files (*.*)|*.*")
{
string srcPath = RipeArgs.GetInPath(args, 0, pickerFilter);
string destPath = RipeArgs.GetOutPath(args, 1, srcPath, fileExt, dirSuffix);

TaskHelper.Process(srcPath, destPath, fileExt, execute, actionName, filter);
}

}

}