using RipeLib;
using SexyObjUtils;

namespace RipeConsole
{
// Caller to SexyObjUtils DLL

internal static partial class ActionInvoker
{
// Sort obj table

public static void SexyObj_Sort(string[] args)
{
string inFile = ArgsParser.GetInPath(args, 0);

var criteria = ArgsParser.GetEnumOrDefault<SexyObjSortCriteria>(args, 1, "Select sort criteria");
var sortProperties = ArgsParser.GetBoolOrDefault(args, 2, "Sort properties");

SexyObjMgr.SortFile(inFile, criteria, sortProperties);
}

// Comparer table

public static void SexyObj_Compare(string[] args)
{
string oldPath = ArgsParser.GetPath(args, 0, "Select path to old file");
string newPath = ArgsParser.GetPath(args, 1, "Select path to new file");

var mode = ArgsParser.GetEnumOrDefault<SexyTableCompareMode>(args, 2, "Select compare mode");
var criteria = ArgsParser.GetEnumOrDefault<SexyObjDiffCriteria>(args, 3, "Select diff criteria");

SexyObjMgr.CompareFiles(oldPath, newPath, mode, criteria);
}

// Update table

public static void SexyObj_Update(string[] args)
{
string oldPath = ArgsParser.GetPath(args, 0, "Select path to old file");
string newPath = ArgsParser.GetPath(args, 1, "Select path to new file");

SexyObjMgr.UpdateFile(oldPath, newPath);
}

// Split file

public static void SexyObj_Split(string[] args)
{
string srcPath = ArgsParser.GetInPath(args, 0);

SexyObjMgr.Split(srcPath);
}

// Merge files

public static void SexyObj_Merge(string[] args)
{
string srcDir = ArgsParser.GetPath(args, 0, "Select json dir to merge");

SexyObjMgr.Merge(srcDir);
}

}

}