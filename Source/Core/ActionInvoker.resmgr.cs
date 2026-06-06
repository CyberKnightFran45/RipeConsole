using PopCapResManager;

namespace RipeConsole
{
// Caller to PopCapResManager DLL

internal static partial class ActionInvoker
{
// ResInfo to group

public static void PopCapRes_ToGroup(string[] args)
{
string inFile = RipeArgs.GetInFile(args, 0);
string outFile = RipeArgs.GetOutFile(args, 1, inFile, ".group.json");

ResManager.ConvertToGroup(inFile, outFile);
}

// ResGroup to info

public static void PopCapRes_ToInfo(string[] args)
{
string inFile = RipeArgs.GetInFile(args, 0);
string outFile = RipeArgs.GetOutFile(args, 1, inFile, ".info.json");

var pStyle = RipeArgs.GetEnum<PathType>(args, 2, "Select path type");

ResManager.ConvertToInfo(inFile, outFile, pStyle);
}

// Split PopCapRes

public static void PopCapRes_Split(string[] args)
{
string srcFile = RipeArgs.GetInFile(args, 0);
bool isNewRes = RipeArgs.GetPopResType(args, 1);

ResManager.Split(srcFile, isNewRes);
}

// Merge PopCapRes

public static void PopCapRes_Merge(string[] args)
{
string srcDir = RipeArgs.GetInFolder(args, 0, "Select res dir to merge");
bool isNewRes = RipeArgs.GetPopResType(args, 1);

ResManager.Merge(srcDir, isNewRes);
}

}

}