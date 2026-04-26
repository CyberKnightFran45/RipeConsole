using System.Collections.Generic;
using RipeLib;
using TextHandler;
using TextHandler.LawnStrings;

namespace RipeConsole
{
// Caller to TextHandler DLL

internal static partial class ActionInvoker
{
// Get LawnStrings format

private static LawnStringsFormat GetLawnStringsFormat(string[] args, int index, string prompt)
{
return ArgsParser.GetEnumOrDefault<LawnStringsFormat>(args, index, prompt);
}

// Get LawnStrings encoding

private static LawnStringsEncoding GetLawnStringsEncoding(LawnStringsFormat format, string[] args,
                                                          int index, string prompt)
{

if(format == LawnStringsFormat.PlainText)
return ArgsParser.GetEnumOrDefault<LawnStringsEncoding>(args, index, prompt);

return LawnStringsEncoding.UTF8_BOM;
}

// Sort LawnStrings

public static void LawnStrings_Sort(string[] args)
{
string inFile = ArgsParser.GetInPath(args, 0);

var format = GetLawnStringsFormat(args, 1, "Select LawnStrings format");
var encoding = GetLawnStringsEncoding(format, args, 2, "Select LawnStrings encoding");

LawnStringsMgr.SortFile(inFile, format, encoding);
}

// Convert LawnStrings

public static void LawnStrings_Convert(string[] args)
{
string inFile = ArgsParser.GetInPath(args, 0);

var inFormat = GetLawnStringsFormat(args, 1, "Select input format");
var outFormat = GetLawnStringsFormat(args, 2, "Select output format");

var inEncoding = GetLawnStringsEncoding(inFormat, args, 3, "Select input encoding");
var outEncoding = GetLawnStringsEncoding(outFormat, args, 4, "Select output encoding");

LawnStringsMgr.ConvertFile(inFile, inFormat, outFormat, inEncoding, outEncoding);
}

// Get LawnStrings compare mode

private static LawnStringsCompareMode GetLawnStringsMode(string[] args, int index)
{
return ArgsParser.GetEnumOrDefault<LawnStringsCompareMode>(args, index, "Select compare mode");
}

// Exclude dialog

private static bool ShouldUseExcludeSet(string[] args, int index)
{

if(args.Length > index && !string.IsNullOrWhiteSpace(args[index] ) )
return true; // Arg is a path to json list

return ConsoleReader.ReadBool("Use ID ExcludeList");
}

// Get Exclude IDs

private static HashSet<string> GetExcludeIDs(string[] args, int index)
{
bool useExcludeSet = ShouldUseExcludeSet(args, index);

if(useExcludeSet)
{
string jsonPath = ArgsParser.GetPath(args, index, "Select path to json exclude set");
using var inFile = FileManager.OpenRead(jsonPath);

return JsonSerializer.DeserializeObject<HashSet<string>>(inFile);
}

return new();
}

// Compare LawnStrings

public static void LawnStrings_Compare(string[] args)
{
string oldPath = ArgsParser.GetPath(args, 0, "Select path to old file");
string newPath = ArgsParser.GetPath(args, 1, "Select path to new file");

var format = GetLawnStringsFormat(args, 2, "Select format for both files");
var mode = GetLawnStringsMode(args, 3);

var excludeList = GetExcludeIDs(args, 4);
var encoding = GetLawnStringsEncoding(format, args, 5, "Select encoding for both files");

LawnStringsMgr.CompareFiles(oldPath, newPath, format, mode, excludeList, encoding);
}

// Update LawnStrings

public static void LawnStrings_Update(string[] args)
{
string oldPath = ArgsParser.GetPath(args, 0, "Select path to old file");
string newPath = ArgsParser.GetPath(args, 1, "Select path to new file");

var format = GetLawnStringsFormat(args, 2, "Select format for both files");
var excludeList = GetExcludeIDs(args, 3);

var encoding = GetLawnStringsEncoding(format, args, 4, "Select encoding for both files");

LawnStringsMgr.UpdateFile(oldPath, newPath, format, excludeList, encoding);
}

// Get LawnStrings server

private static LawnStringsServerType GetLawnStringsServer(string[] args, int index)
{
return ArgsParser.GetEnumOrDefault<LawnStringsServerType>(args, index, "Select LawnStrings server");
}

// Download res from LawnStrings server

public static void LawnStringsServer_DownloadRes(string[] args)
{
string outDir = ArgsParser.GetPath(args, 0, "Select download folder");

var resType = ArgsParser.GetEnumOrDefault<LawnStringsResType>(args, 1, "Select res type");
var server = GetLawnStringsServer(args, 2);

LawnStringsServer.DownloadFile(outDir, resType, server);
}

// Get new text from LawnStrings server

public static void LawnStringsServer_GetUpdate(string[] args)
{
string srcFile = ArgsParser.GetPath(args, 0, "Select local file to compare");

var server = GetLawnStringsServer(args, 1);
var excludeList = GetExcludeIDs(args, 2);

LawnStringsServer.GetUpdate(srcFile, server, excludeList);
}

// Update local file using LawnStrings server

public static void LawnStringsServer_Update(string[] args)
{
string srcFile = ArgsParser.GetPath(args, 0, "Select local file to update");

var server = GetLawnStringsServer(args, 1);
var excludeList = GetExcludeIDs(args, 2);

LawnStringsServer.Update(srcFile, server, excludeList);
}

// Encode Compiled txt

public static void CompiledTxt_Encode(string[] args)
{
static void execute(string input, string output) => CompiledText.EncodeFile(input, output);

TaskHelper.Process(args, execute, "Encode", "encoded", ".compiled.txt", FilterCriterias.CompiledTxtFilter);
}

// Decode Compiled txt

public static void CompiledTxt_Decode(string[] args)
{
static void execute(string input, string output) => CompiledText.DecodeFile(input, output);

TaskHelper.Process(args, execute, "Decode", "decoded", ".plain.txt", FilterCriterias.CompiledTxtFilter);
}

}

}