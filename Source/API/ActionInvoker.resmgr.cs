using RipeLib;
using PopCapResManager;

namespace RipeConsole
{
// Caller to PopCapResManager DLL

internal static partial class ActionInvoker
{
// ResInfo to group

public static void PopCapRes_ToGroup(string[] args)
{
string inFile = ArgsParser.GetInPath(args, 0);
string outFile = ArgsParser.GetOutPath(args, 1, inFile, ".group.json");

ResManager.ConvertToGroup(inFile, outFile);
}

// ResGroup to info

public static void PopCapRes_ToInfo(string[] args)
{
string inFile = ArgsParser.GetInPath(args, 0);
string outFile = ArgsParser.GetOutPath(args, 1, inFile, ".info.json");

var pStyle = ArgsParser.GetEnumOrDefault<PathType>(args, 2, "Select path type");

ResManager.ConvertToInfo(inFile, outFile, pStyle);
}

// Split PopCapRes

public static void PopCapRes_Split(string[] args)
{
string srcFile = ArgsParser.GetInPath(args, 0);
bool isNewRes = ArgsParser.GetBoolOrDefault(args, 1, "Is ResGroup");

ResManager.Split(srcFile, isNewRes);
}

// Merge PopCapRes

public static void PopCapRes_Merge(string[] args)
{
string srcDir = ArgsParser.GetPath(args, 0, "Select res dir to merge");
bool isNewRes = ArgsParser.GetBoolOrDefault(args, 1, "Is ResGroup");

ResManager.Merge(srcDir, isNewRes);
}

}

}