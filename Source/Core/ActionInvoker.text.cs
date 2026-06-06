using TextHandler;
using TextHandler.LawnStrings;

namespace RipeConsole
{
// Caller to TextHandler DLL

internal static partial class ActionInvoker
{
// Sort LawnStrings

public static void LawnStrings_Sort(string[] args)
{
string inFile = RipeArgs.GetInFile(args, 0, PickerFilters.LawnStrings);

var format = RipeArgs.GetLawnStringsInFormat(inFile, args, 1, "Select LawnStrings format");
var encoding = RipeArgs.GetLawnStringsInEncoding(format, args, 2, "Select LawnStrings encoding");

LawnStringsMgr.SortFile(inFile, format, encoding);
}

// Convert LawnStrings

public static void LawnStrings_Convert(string[] args)
{
string inFile = RipeArgs.GetInFile(args, 0, PickerFilters.LawnStrings);

var inFormat = RipeArgs.GetLawnStringsInFormat(inFile, args, 1, "Select input format");
var outFormat = RipeArgs.GetLawnStringsOutFormat(inFormat, args, 2, "Select output format");

var inEncoding = RipeArgs.GetLawnStringsInEncoding(inFormat, args, 3, "Select input encoding");
var outEncoding = RipeArgs.GetLawnStringsOutEncoding(inFormat, outFormat, inEncoding);

LawnStringsMgr.ConvertFile(inFile, inFormat, outFormat, inEncoding, outEncoding);
}

// Compare LawnStrings

public static void LawnStrings_Compare(string[] args)
{
string oldPath = RipeArgs.GetInFile(args, 0, PickerFilters.LawnStrings, "Select path to old file");
string newPath = RipeArgs.GetInFile(args, 1, PickerFilters.LawnStrings, "Select path to new file");

var format = RipeArgs.GetLawnStringsFormat(oldPath, newPath, args, 2, "Select format for both files");
var mode = RipeArgs.GetLawnStringsMode(args, 3);

var excludeList = RipeArgs.GetExcludeIDs(args, 4);
var encoding = RipeArgs.GetLawnStringsInEncoding(format, args, 5, "Select encoding for both files");

LawnStringsMgr.CompareFiles(oldPath, newPath, format, mode, excludeList, encoding);
}

// Update LawnStrings

public static void LawnStrings_Update(string[] args)
{
string oldPath = RipeArgs.GetInFile(args, 0, PickerFilters.LawnStrings, "Select path to old file");
string newPath = RipeArgs.GetInFile(args, 1, PickerFilters.LawnStrings, "Select path to new file");

var format = RipeArgs.GetLawnStringsFormat(oldPath, newPath, args, 2, "Select format for both files");
var excludeList = RipeArgs.GetExcludeIDs(args, 3);

var encoding = RipeArgs.GetLawnStringsInEncoding(format, args, 4, "Select encoding for both files");

LawnStringsMgr.UpdateFile(oldPath, newPath, format, excludeList, encoding);
}

// Download res from LawnStrings server

public static void LawnStringsServer_DownloadRes(string[] args)
{
string outDir = RipeArgs.GetDownloadFolder(args, 0);

var resType = RipeArgs.GetEnum(args, 1, "Select res type", LawnStringsResType.Text);
var server = RipeArgs.GetLawnStringsServer(args, 2);

LawnStringsServer.DownloadFile(outDir, resType, server);
}

// Get new text from LawnStrings server

public static void LawnStringsServer_GetUpdate(string[] args)
{
string srcFile = RipeArgs.GetInFile(args, 0, PickerFilters.LawnStrings, "Select local file to compare");

var server = RipeArgs.GetLawnStringsServer(args, 1);
var excludeList = RipeArgs.GetExcludeIDs(args, 2);

LawnStringsServer.GetUpdate(srcFile, server, excludeList);
}

// Update local file using LawnStrings server

public static void LawnStringsServer_Update(string[] args)
{
string srcFile = RipeArgs.GetInFile(args, 0, PickerFilters.LawnStrings, "Select local file to update");

var server = RipeArgs.GetLawnStringsServer(args, 1);
var excludeList = RipeArgs.GetExcludeIDs(args, 2);

LawnStringsServer.Update(srcFile, server, excludeList);
}

// Encode Compiled txt

public static void CompiledTxt_Encode(string[] args)
{
static void execute(string input, string output) => CompiledText.EncodeFile(input, output);

BatchHelper.Process(args, execute, "Encode", "encoded", ".compiled.txt",
                    FilterCriterias.CompiledTxtFilter, PickerFilters.CompiledText);

}

// Decode Compiled txt

public static void CompiledTxt_Decode(string[] args)
{
static void execute(string input, string output) => CompiledText.DecodeFile(input, output);

BatchHelper.Process(args, execute, "Decode", "decoded", ".plain.txt", 
                    FilterCriterias.CompiledTxtFilter, PickerFilters.CompiledText);

}

}

}