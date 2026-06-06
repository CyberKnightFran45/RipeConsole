using SexyCompressors.ArcVPackage;
using SexyCompressors.PopCapPackage;
using SexyCompressors.XboxPackedResource;
using SexyCompressors.ResourceStreamGroup;
using SexyCompressors.MarmaladeDZip;

namespace RipeConsole
{
// Caller to SexyCompressors DLL

internal static partial class ActionInvoker
{
// Build ARCV Package

public static void ARCV_Pack(string[] args)
{
string srcDir = RipeArgs.GetInFolder(args, 0, "Select ARCV dir");
string outFile = RipeArgs.GetOutFile(args, 1, srcDir, ".arcv", PickerFilters.Arcv);

ArcvPacker.Pack(srcDir, outFile);
}

// Unpack ARCV Package

public static void ARCV_Unpack(string[] args)
{
string srcFile = RipeArgs.GetInFile(args, 0, PickerFilters.Arcv);
string outDir = RipeArgs.GetOutDir(args, 1, srcFile, "unpacked");

var diskOptions = RipeArgs.GetRamDiskOptions(args, 2);

ArcvUnpacker.Unpack(srcFile, outDir, diskOptions);
}

// TO/DO: Pack DZip

// Unpack DZip Package

public static void Dz_Unpack(string[] args)
{
string srcFile = RipeArgs.GetInFile(args, 0, PickerFilters.DZip);
string outDir = RipeArgs.GetOutDir(args, 1, srcFile, "unpacked");

var diskOptions = RipeArgs.GetRamDiskOptions(args, 2);

DzUnpacker.Unpack(srcFile, outDir, diskOptions);
}

// Build PAK file

public static void PAK_Build(string[] args)
{
string srcDir = RipeArgs.GetInFolder(args, 0, "Select PAK dir");
string outFile = RipeArgs.GetOutFile(args, 1, srcDir, ".pak", PickerFilters.Pak);

PakBuilder.Pack(srcDir, outFile);
}

// Unpack PAK file

public static void PAK_Extract(string[] args)
{
string srcFile = RipeArgs.GetInFile(args, 0, PickerFilters.Pak);
string outDir = RipeArgs.GetOutDir(args, 1, srcFile, "unpacked");

var diskOptions = RipeArgs.GetRamDiskOptions(args, 2);

PakExtractor.Unpack(srcFile, outDir, diskOptions);
}

// Build XPR file

public static void XPR_Build(string[] args)
{
string srcDir = RipeArgs.GetInFolder(args, 0, "Select XPR dir");
string outFile = RipeArgs.GetOutFile(args, 1, srcDir, ".xpr", PickerFilters.Xpr);

XprBuilder.Pack(srcDir, outFile);
}

// Unpack XPR file

public static void XPR_Unpack(string[] args)
{
string srcFile = RipeArgs.GetInFile(args, 0, PickerFilters.Xpr);
string outDir = RipeArgs.GetOutDir(args, 1, srcFile, "unpacked");

var diskOptions = RipeArgs.GetRamDiskOptions(args, 2);

XprUnpacker.Unpack(srcFile, outDir, diskOptions);
}

// Build ResGroup

public static void RSG_Pack(string[] args)
{
string srcDir = RipeArgs.GetInFolder(args, 0, "Select RSG dir");
string outFile = RipeArgs.GetOutFile(args, 1, srcDir, ".rsg", PickerFilters.Rsgp);

RsgPacker.Pack(srcDir, outFile);
}

// Unpack ResGroup

public static void RSG_Unpack(string[] args)
{
string srcFile = RipeArgs.GetInFile(args, 0, PickerFilters.Rsgp);
string outDir = RipeArgs.GetOutDir(args, 1, srcFile, "unpacked");

var diskOptions = RipeArgs.GetRamDiskOptions(args, 2);

RsgUnpacker.Unpack(srcFile, outDir, diskOptions);
}

}

}