using RipeLib;
using SexyCompressors.ArcVPackage;
using SexyCompressors.PopCapPackage;
using SexyCompressors.XboxPackedResource;
using SexyCompressors.ResourceStreamGroup;

namespace RipeConsole
{
// Caller to SexyCompressors DLL

internal static partial class ActionInvoker
{
// Build ARCV Package

public static void ARCV_Pack(string[] args)
{
string srcDir = ArgsParser.GetPath(args, 0, "Select ARCV dir");
string outFile = ArgsParser.GetOutPath(args, 1, srcDir, ".arcv");

ArcvPacker.Pack(srcDir, outFile);
}

// Unpack ARCV Package

public static void ARCV_Unpack(string[] args)
{
string srcFile = ArgsParser.GetInPath(args, 0);
string outDir = ArgsParser.GetOutDir(args, 1, srcFile, "unpacked");

ArcvUnpacker.Unpack(srcFile, outDir);
}

// TO/DO: DZip



// Build PAK file

public static void PAK_Build(string[] args)
{
string srcDir = ArgsParser.GetPath(args, 0, "Select PAK dir");
string outFile = ArgsParser.GetOutPath(args, 1, srcDir, ".pak");

PakBuilder.Pack(srcDir, outFile);
}

// Unpack PAK file

public static void PAK_Extract(string[] args)
{
string srcFile = ArgsParser.GetInPath(args, 0);
string outDir = ArgsParser.GetOutDir(args, 1, srcFile, "unpacked");

PakExtractor.Unpack(srcFile, outDir);
}

// Build XPR file

public static void XPR_Build(string[] args)
{
string srcDir = ArgsParser.GetPath(args, 0, "Select XPR dir");
string outFile = ArgsParser.GetOutPath(args, 1, srcDir, ".xpr");

XprBuilder.Pack(srcDir, outFile);
}

// Unpack XPR file

public static void XPR_Unpack(string[] args)
{
string srcFile = ArgsParser.GetInPath(args, 0);
string outDir = ArgsParser.GetOutDir(args, 1, srcFile, "unpacked");

XprUnpacker.Unpack(srcFile, outDir);
}

// Build ResGroup

public static void RSG_Pack(string[] args)
{
string srcDir = ArgsParser.GetPath(args, 0, "Select RSB dir");
string outFile = ArgsParser.GetOutPath(args, 1, srcDir, ".rsg");

RsgPacker.Pack(srcDir, outFile);
}

// Unpack ResGroup

public static void RSG_Unpack(string[] args)
{
string srcFile = ArgsParser.GetInPath(args, 0);
string outDir = ArgsParser.GetOutDir(args, 1, srcFile, "unpacked");

RsgUnpacker.Unpack(srcFile, outDir);
}

}

}