using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using RipeLib;
using TextHandler.LawnStrings;
using TextureTranscoder.Parsers.PopCapTexture;
using TextureTranscoder.Parsers.RawImage;

namespace RipeConsole
{
// Read user arguments

internal static class RipeArgs
{
// RAM Disk options (Disabled)

private static readonly RAMDiskOptions RamDiskOptions_None = new()
{
Enabled = false
};

// Default RAM Disk options

private static readonly RAMDiskOptions RamDiskOptions_Default = new();

// RAM Disk options (Automatic)

private static readonly RAMDiskOptions RamDiskOptions_Auto = new()
{
DriveLetter = null,
AllowExpand = false
};

// Get boolean

public static bool GetBool(string[] args, int index, string prompt, bool fallback)
{

if(SettingsManager.Current.AutoFillArgs)
return fallback;

return ArgsParser.GetBoolOrDefault(args, index, prompt);
}

// Get enum

public static T GetEnum<T>(string[] args, int index, string prompt) where T : struct, Enum
{
return ArgsParser.GetEnumOrDefault<T>(args, index, prompt);
}

// Get enum (auto)

public static T GetEnum<T>(string[] args, int index, string prompt, T fallback) where T : struct, Enum
{

if(SettingsManager.Current.AutoFillArgs)
return fallback;

return ArgsParser.GetEnumOrDefault<T>(args, index, prompt);
}

// Display path dialog

private static string PathDialog(string title, string filter, int dialogId) => dialogId switch
{
1 => FilePicker.SaveFile(title, filter),
2 => FilePicker.OpenFolder(title),
_ => FilePicker.OpenFile(title, filter)
};

// Get path through file picker

private static string GetPathThroughPicker(string prompt, string filter, int dialogId)
{
string path = PathDialog(prompt, filter, dialogId);

if(path != null)
{
ConsoleWriter.WriteColored($"Selected: {path}\n", ConsoleColor.DarkYellow);

return path;
}

return ConsoleReader.ReadPath(prompt);
}

// Get path (internal)

private static string GetPathCore(string[] args, int index, string prompt, string filter, int dialogId)
{

if(ArgsParser.HasValue(args, index) )
return args[index];

if(SettingsManager.Current.UseNativeFilePicker)
return GetPathThroughPicker(prompt, filter, dialogId);

return ConsoleReader.ReadPath(prompt);
}

// Get input path

public static string GetInPath(string[] args, int index, string filter = "All files (*.*)|*.*")
{

if(ArgsParser.HasValue(args, index) )
return args[index];

int flags = 0;

if(SettingsManager.Current.UseNativeFilePicker)
{
var mode = ConsoleReader.ReadEnum<PathMode>("Choose input mode");

flags = mode == PathMode.Folder ? 2 : 0;
}

return GetPathCore(args, index, "Select input", filter, flags);
}

// Get input file

public static string GetInFile(string[] args, int index, string filter = "All files (*.*)|*.*",
                               string prompt = "Select input file")
{
return GetPathCore(args, index, prompt, filter, 0);
}

// Get input folder

public static string GetInFolder(string[] args, int index, string prompt = "Select input folder")
{
return GetPathCore(args, index, prompt, null, 2);
}

// Build output path

private static string BuildOutPath(string[] args, string inPath, string ext, string suffix)
{

if(Directory.Exists(inPath) )
return ArgsParser.GetOutDir(args, 1, inPath, suffix);

return ArgsParser.GetOutPath(args, 1, inPath, ext);
}

// Get output file or folder

public static string GetOutPath(string[] args, int index, string inPath, string fileExt, string dirSuffix)
{

if(ArgsParser.HasValue(args, index) )
return args[index];

if(SettingsManager.Current.GenerateOutputPaths)
return BuildOutPath(args, inPath, fileExt, dirSuffix);

int flags = 0;

if(SettingsManager.Current.UseNativeFilePicker)
{
var mode = ConsoleReader.ReadEnum<PathMode>("Select output mode");

flags = mode == PathMode.Folder ? 2 : 1;
}

return GetPathCore(args, index, "Select output", "All files (*.*)|*.*", flags);
}

// Get output file

public static string GetOutFile(string[] args, int index, string inPath, string ext,
                                string filter = "All files (*.*)|*.*")
{

if(SettingsManager.Current.GenerateOutputPaths)
return ArgsParser.GetOutPath(args, index, inPath, ext);

return GetPathCore(args, index, "Select output file", filter, 1);
}

// Get output dir

public static string GetOutDir(string[] args, int index, string inPath, string suffix,
                               string prompt = "Select output folder")
{

if(SettingsManager.Current.GenerateOutputPaths)
return ArgsParser.GetOutDir(args, index, inPath, suffix);

return GetPathCore(args, index, prompt, null, 2);
}

// Get download dir

public static string GetDownloadFolder(string[] args, int index)
{

if(SettingsManager.Current.AutoFillArgs)
return ArgsManager.Current.DownloadFolder;

return GetPathCore(args, index, "Select download folder", null, 2);
}

// Get base64 mode

public static bool GetBase64Mode(string[] args, int index)
{
var defaultMode = ArgsManager.Current.UseBase64WebSafe;

return GetBool(args, index, "Use Web-safe base64", defaultMode);
}

// Get CompressionLevel

public static CompressionLevel GetCompressLvl(string[] args, int index)
{
var defaultCompressLvl = ArgsManager.Current.StreamCompressionLevel;
	
return GetEnum(args, index, "Select compression level", defaultCompressLvl);
}

// Get BlockSize for BZip2

public static int GetBlockSize(string[] args, int index)
{

if(SettingsManager.Current.AutoFillArgs)
return ArgsManager.Current.BZipBlockSize;

return ArgsParser.GetIntOrDefault(args, index, "Select compression level", 1, 9);
}

// Get cipher key

public static byte[] GetCipherKey(string[] args, int index)
{

if(SettingsManager.Current.AutoFillArgs)
return Encoding.UTF8.GetBytes(ArgsManager.Current.CipherKey);

return ArgsParser.GetBytesOrDefault(args, index, "Enter a cipher key");
}

// Get PopCap res type

public static bool GetPopResType(string[] args, int index)
{
var defaultResType = ArgsManager.Current.UseNewPopRes;

return GetBool(args, index, "Is ResGroup / New Res", defaultResType);
}

// Get LawnStrings format for input file

public static LawnStringsFormat GetLawnStringsInFormat(string inPath, string[] args, 
                                                       int index, string prompt)
{
string ext = Path.GetExtension(inPath);

if(LawnStringsFilter.TryGetFmtFromExtension(ext, out var format) )
return format;

var filter = LawnStringsFilter.GetInputFilter(ext);

return ArgsParser.GetEnumOrDefault(args, index, prompt, filter);
}

// Get LawnStrings format for output file

public static LawnStringsFormat GetLawnStringsOutFormat(LawnStringsFormat inFormat, string[] args, 
                                                        int index, string prompt)
{
var filter = LawnStringsFilter.GetOutputFilter(inFormat);

return ArgsParser.GetEnumOrDefault(args, index, prompt, filter);
}

// Get LawnStrings format for both files

public static LawnStringsFormat GetLawnStringsFormat(string path1, string path2, string[] args,
                                                     int index, string prompt)
{
string ext1 = Path.GetExtension(path1);
string ext2 = Path.GetExtension(path2);

if(!string.Equals(ext1, ext2, StringComparison.OrdinalIgnoreCase) )
throw new InvalidOperationException($"Input formats do not match: '{ext1}' and '{ext2}'");

return GetLawnStringsInFormat(path1, args, index, prompt);
}

// Get input encoding for LawnStrings

public static LawnStringsEncoding GetLawnStringsInEncoding(LawnStringsFormat format, string[] args,
                                                           int index, string prompt)
{

if(format == LawnStringsFormat.PlainText && !SettingsManager.Current.AutoFillArgs)
return GetEnum<LawnStringsEncoding>(args, index, prompt);

return ArgsManager.Current.LawnStringsInEncoding;
}

// Get output encoding (internal)

private static LawnStringsEncoding GetLawnStringsOutEncoding(LawnStringsEncoding inputEncoding)
{

return inputEncoding == LawnStringsEncoding.UTF8_BOM ? 
                        LawnStringsEncoding.UTF16 : 
                        LawnStringsEncoding.UTF8_BOM;

}

// Get output encoding for LawnStrings

public static LawnStringsEncoding GetLawnStringsOutEncoding(LawnStringsFormat inputFormat, 
                                                            LawnStringsFormat outputFormat,
                                                            LawnStringsEncoding inputEncoding)
{

if(inputFormat == LawnStringsFormat.PlainText && outputFormat == LawnStringsFormat.PlainText)
return GetLawnStringsOutEncoding(inputEncoding);

return LawnStringsEncoding.UTF8_BOM;
}

// Get LawnStrings compare mode

public static LawnStringsCompareMode GetLawnStringsMode(string[] args, int index)
{
var defaultCompareMode = ArgsManager.Current.LawnStringsDiffCriteria;

return GetEnum(args, index, "Select compare mode", defaultCompareMode);
}

// Exclude dialog

private static bool ShouldUseExcludeSet(string[] args, int index)
{

if(args.Length > index && !string.IsNullOrWhiteSpace(args[index] ) )
return true; // Arg is a path to json list

return ConsoleReader.ReadBool("Use ID ExcludeList");
}

// Get Exclude IDs

public static HashSet<string> GetExcludeIDs(string[] args, int index)
{

if(SettingsManager.Current.AutoFillArgs)
return new();

bool useExcludeSet = ShouldUseExcludeSet(args, index);

if(useExcludeSet)
{
string jsonPath = GetInFile(args, index, PickerFilters.Json, "Select path to json exclude set");
using var inFile = FileManager.OpenRead(jsonPath);

return JsonSerializer.DeserializeObject<HashSet<string>>(inFile);
}

return new();
}

// Get LawnStrings server

public static LawnStringsServerType GetLawnStringsServer(string[] args, int index)
{
var defaultServerType = ArgsManager.Current.LawnStringsServer;

return GetEnum(args, index, "Select LawnStrings server", defaultServerType);
}

// Load img info dialog

private static bool ShouldImportTexInfo(string[] args, int index)
{

if(args.Length > index && !string.IsNullOrWhiteSpace(args[index] ) )
return true; // Arg is a path to imported file

return ConsoleReader.ReadBool("Import texture info");
}

// Save img info dialog

private static bool ShouldExportTexInfo(string[] args, int index)
{

if(args.Length > index && !string.IsNullOrWhiteSpace(args[index] ) )
return true; // Arg is a path to exported file

return ConsoleReader.ReadBool("Export texture info");
}

// Add suffix

private static string AddSuffix(string path, string suffix)
{
string dir = Path.GetDirectoryName(path);

string name = Path.GetFileNameWithoutExtension(path);
string ext = Path.GetExtension(path);

return Path.Combine(dir, $"{name}{suffix}{ext}");
}

// Get info path

private static string GetTexInfoPath(string inPath, string[] args, int index, bool import)
{
bool askPath = import ? ShouldImportTexInfo(args, index) : ShouldExportTexInfo(args, index);

if(SettingsManager.Current.AutoFillArgs)
{
string infoPath = AddSuffix(inPath, "info");

return import && !File.Exists(infoPath) ? null : infoPath;
}

int flags = import ? 0 : 1;

if(askPath)
return GetPathCore(args, index, "Select path to texture info", "All files (*.*)|*.*", flags);

return null;
}

// Get info path

public static string GetTexInfoPath(string inPath, string[] args, int index)
{
return GetTexInfoPath(inPath, args, index, false);
}

// Read img width

private static int GetWidth(string[] args, int index)
{
return ArgsParser.GetIntOrDefault(args, index, "Enter image width");
}

// Read img height

private static int GetHeight(string[] args, int index)
{
return ArgsParser.GetIntOrDefault(args, index, "Enter image height");
}

// Get ptx format

public static PtxFormat GetPtxFormat(string[] args, int index) 
{
var defaultFmt = ArgsManager.Current.PtxFormat_Mobile;

return GetEnum(args, index, "Select PTX format", defaultFmt);
}

// Read PtxInfo

private static PtxInfo ReadPtxInfo(string[] args)
{
int width = GetWidth(args, 3);
int height = GetHeight(args, 4);

var format = GetPtxFormat(args, 5);

return new(width, height, format);
}

// Get PtxInfo from file or load it in runtime

public static PtxInfo GetPtxInfo(string inPath, string[] args)
{
string infoPath = GetTexInfoPath(inPath, args, 2, true);

if(infoPath != null)
{
using var infoStream = FileManager.OpenRead(infoPath);

return PtxInfo.ReadBin(infoStream);
}

return ReadPtxInfo(args);
}

// Get raw img format

public static RawImgFormat GetTexFormat(string[] args, int index) 
{
var defaultFmt = ArgsManager.Current.RawTextureFmt;

return GetEnum(args, index, "Select texture format", defaultFmt);
}

// Read RawImgInfo

private static RawImgInfo ReadRawImgInfo(string[] args)
{
int width = GetWidth(args, 3);
int height = GetHeight(args, 4);

var format = GetTexFormat(args, 5);

return new(width, height, format);
}

// Get ImgInfo from file or load it in runtime

public static RawImgInfo GetRawImgInfo(string inPath, string[] args)
{
string infoPath = GetTexInfoPath(inPath, args, 2, true);

if(infoPath != null)
{
using var infoStream = FileManager.OpenRead(infoPath);

return RawImgInfo.ReadBin(infoStream);
}

return ReadRawImgInfo(args);
}

// RAM Disk mode

private static RAMDiskOptionSet GetRamDiskMode(string[] args, int index)
{
return GetEnum(args, index, "Select RAM Disk mode", RAMDiskOptionSet.Auto);
}

// Read drive letter

private static char? GetDriveLetter()
{
var letter = ConsoleReader.ReadChar("Select drive letter, leave blank for auto-fill");

if(!letter.HasValue)
return null;

var c = char.ToUpper(letter.Value);

return c >= 'A' && c <= 'Z' ? c : null;
}

// Read RAM Disk FileSystem

private static string GetFileSystem()
{
var flags = ConsoleReader.ReadEnum<RamDiskFileSystem>("Select file system");

return flags.ToString();
}

// Read disk label

private static string GetDiskLabel(string fileSystem)
{
string label = ConsoleReader.ReadString("Enter disk label, leave blank for none", true);

if(string.IsNullOrWhiteSpace(label) )
return string.Empty;

label = label.Trim();

int maxLength = fileSystem == "NTFS" ? 32 : 11;

if(label.Length > maxLength)
label = label[.. maxLength];

return label.Replace(" ", "_");
}

// Read RAM Disk options

private static RAMDiskOptions ReadRamDiskOptions()
{
var rawDrive = GetDriveLetter();
bool allowExpand = ConsoleReader.ReadBool("Allow disk expansion");

string fs = GetFileSystem();
string label = GetDiskLabel(fs);

return new()
{
DriveLetter = rawDrive,
FileSystem = fs,
Label = label,
AllowExpand = allowExpand
};

}

// Get RAM Disk options according to selected mode

public static RAMDiskOptions GetRamDiskOptions(string[] args, int index)
{
bool useRamDisk = PlatformHelper.IsWindows && ImDiskHelper.IsInstalled;
var mode = useRamDisk ? GetRamDiskMode(args, index) : RAMDiskOptionSet.None;

return mode switch
{
RAMDiskOptionSet.Default => RamDiskOptions_Default,
RAMDiskOptionSet.Auto => RamDiskOptions_Auto,
RAMDiskOptionSet.Custom => ReadRamDiskOptions(),
_ => RamDiskOptions_None
};

}

}

}