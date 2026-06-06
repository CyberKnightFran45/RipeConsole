using SexyObjUtils;

namespace RipeConsole
{
// Caller to SexyObjUtils DLL

internal static partial class ActionInvoker
{
// Sort obj table

public static void SexyObj_Sort(string[] args)
{
string inFile = RipeArgs.GetInFile(args, 0, PickerFilters.Json);

var criteria = RipeArgs.GetEnum(args, 1, "Select sort criteria", SexyObjSortCriteria.Type);
var sortProperties = RipeArgs.GetBool(args, 2, "Sort properties", false);

SexyObjMgr.SortFile(inFile, criteria, sortProperties);
}

// Comparer table

public static void SexyObj_Compare(string[] args)
{
string oldPath = RipeArgs.GetInFile(args, 0, PickerFilters.Json, "Select path to old file");
string newPath = RipeArgs.GetInFile(args, 1, PickerFilters.Json, "Select path to new file");

var mode = RipeArgs.GetEnum(args, 2, "Select compare mode", SexyTableCompareMode.Added);
var criteria = RipeArgs.GetEnum(args, 3, "Select diff criteria", SexyObjDiffCriteria.AddedProps);

SexyObjMgr.CompareFiles(oldPath, newPath, mode, criteria);
}

// Update table

public static void SexyObj_Update(string[] args)
{
string oldPath = RipeArgs.GetInFile(args, 0, PickerFilters.Json, "Select path to old file");
string newPath = RipeArgs.GetInFile(args, 1, PickerFilters.Json, "Select path to new file");

SexyObjMgr.UpdateFile(oldPath, newPath);
}

// Split file

public static void SexyObj_Split(string[] args)
{
string srcPath = RipeArgs.GetInFile(args, 0, PickerFilters.Json);

SexyObjMgr.Split(srcPath);
}

// Merge files

public static void SexyObj_Merge(string[] args)
{
string srcDir = RipeArgs.GetInFolder(args, 0, "Select json dir to merge");

SexyObjMgr.Merge(srcDir);
}

}

}