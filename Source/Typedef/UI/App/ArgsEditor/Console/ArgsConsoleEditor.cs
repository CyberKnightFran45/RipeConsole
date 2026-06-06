using System;
using System.IO.Compression;
using RipeLib;
using TextHandler.LawnStrings;
using TextureTranscoder.Parsers.PopCapTexture;
using TextureTranscoder.Parsers.RawImage;

namespace RipeConsole
{
// Arguments editor through console

internal sealed class ArgsConsoleEditor : IArgsEditor
{
// Apply changes

private static void Apply(RipeArgumentsSet src, RipeArgumentsSet dest)
{
dest.DownloadFolder = src.DownloadFolder;
dest.UseBase64WebSafe = src.UseBase64WebSafe;

dest.StreamCompressionLevel = src.StreamCompressionLevel;
dest.BZipBlockSize = src.BZipBlockSize;

dest.UseNewPopRes = src.UseNewPopRes;

dest.LawnStringsInEncoding = src.LawnStringsInEncoding;
dest.LawnStringsDiffCriteria = src.LawnStringsDiffCriteria;
dest.LawnStringsServer = src.LawnStringsServer;

dest.PtxFormat_Mobile = src.PtxFormat_Mobile;
dest.RawTextureFmt = src.RawTextureFmt;

dest.CipherKey = src.CipherKey;
}

// Show options

private static void ShowOptions(RipeArgumentsSet args)
{
ConsoleWriter.WriteHeader("RIPE Arguments", ConsoleColor.DarkYellow);

MenuHelper.PrintOption(0, "Exit");
MenuHelper.PrintOption(1, "Download Folder", args.DownloadFolder);
MenuHelper.PrintOption(2, "Use Base64 Web Safe", args.UseBase64WebSafe);
MenuHelper.PrintOption(3, "Stream Compression Level", args.StreamCompressionLevel);
MenuHelper.PrintOption(4, "BZip Block Size", args.BZipBlockSize);
MenuHelper.PrintOption(5, "Use New PopCap Res", args.UseNewPopRes);
MenuHelper.PrintOption(6, "LawnStrings Input Encoding", args.LawnStringsInEncoding);
MenuHelper.PrintOption(7, "LawnStrings Compare Mode", args.LawnStringsDiffCriteria);
MenuHelper.PrintOption(8, "LawnStrings Server Type", args.LawnStringsServer);
MenuHelper.PrintOption(9, "Ptx format", args.PtxFormat_Mobile);
MenuHelper.PrintOption(10, "Raw Texture Format", args.RawTextureFmt);
MenuHelper.PrintOption(11, "Cipher Key", args.CipherKey);
MenuHelper.PrintOption(12, "Save & Exit");

Console.WriteLine();
}

// Prompt

public bool Edit(RipeArgumentsSet args)
{
RipeArgumentsSet temp = new(args);

while(true)
{
Console.Clear();

ShowOptions(temp);

int option = ConsoleReader.ReadInt("Select option");

switch(option)
{
case 0:
Console.Clear();
return false;

case 1:
temp.DownloadFolder = ConsoleReader.ReadString("Select download folder");
break;

case 2:
temp.UseBase64WebSafe = ConsoleReader.ReadBool("Use Base64 Web-safe");
break;

case 3:
temp.StreamCompressionLevel = ConsoleReader.ReadEnum<CompressionLevel>("Select Compression Level");
break;

case 4:
temp.BZipBlockSize = ConsoleReader.ReadInt("Select BZip Block Size", 1, 9);
break;

case 5:
temp.UseNewPopRes = ConsoleReader.ReadBool("Use New PopCap Res");
break;

case 6:
temp.LawnStringsInEncoding = ConsoleReader.ReadEnum<LawnStringsEncoding>("Select LawnStrings encoding");
break;

case 7:
var diffCriteria = ConsoleReader.ReadEnum<LawnStringsCompareMode>("Select LawnStrings compare mode");

temp.LawnStringsDiffCriteria = diffCriteria;
break;

case 8:
temp.LawnStringsServer = ConsoleReader.ReadEnum<LawnStringsServerType>("Select LawnStrings server");
break;

case 9:
temp.PtxFormat_Mobile = ConsoleReader.ReadEnum<PtxFormat>("Select PTX Format");
break;

case 10:
temp.RawTextureFmt = ConsoleReader.ReadEnum<RawImgFormat>("Select Raw Texture Format");
break;

case 11:
temp.CipherKey = ConsoleReader.ReadString("Enter Cipher Key");
break;

case 12:
Apply(temp, args);

Console.Clear();
return true;

default:
ConsoleWriter.WriteError("Invalid option");
break;
}

Console.WriteLine();
}

}

}

}