using System.IO.Compression;
using RipeLib;
using SexyCompressors;
using SexyCompressors.PopCapZLib;

namespace RipeConsole
{
// Caller to SexyCompressors DLL

internal static partial class ActionInvoker
{
// Get CompressionLevel

private static CompressionLevel GetCompressLvl(string[] args, int index = 2)
{
return ArgsParser.GetEnumOrDefault<CompressionLevel>(args, index, "Select compression level");
}

// Compress SMF

public static void SMF_Compress(string[] args)
{
var compressLvl = GetCompressLvl(args);
bool genTag = ArgsParser.GetBoolOrDefault(args, 3, "Generate smf tag");

void execute(string input, string output) => SmfCompressor.CompressFile(input, output, compressLvl, genTag);

TaskHelper.Process(args, execute, "Compress", "compressed", "rsb.smf", FilterCriterias.RsbFilter);
}

// Decompress SMF

public static void SMF_Decompress(string[] args)
{
bool removeExt = ArgsParser.GetBoolOrDefault(args, 3, "Remove smf extension");
void execute(string input, string output) => SmfCompressor.DecompressFile(input, output, removeExt);

TaskHelper.Process(args, execute, "Decompress", "decompressed", ".rsb", FilterCriterias.SmfFilter);
}

// Create SMF tag

public static void SMF_CreateTag(string[] args)
{
static void execute(string input, string output) => SmfTagCreator.CreateTag(input, output);

TaskHelper.Process(args, execute, "Create tag", "tags", ".smf", FilterCriterias.SmfFilter);
}

// Compress SOE

public static void SOE_Compress(string[] args)
{
var compressLvl = GetCompressLvl(args);
void execute(string input, string output) => SoeCompressor.CompressFile(input, output, compressLvl);

TaskHelper.Process(args, execute, "Compress", "compressed", ".soe", FilterCriterias.DefaultFilter);
}

// Decompress SOE

public static void SOE_Decompress(string[] args)
{
static void execute(string input, string output) => SoeCompressor.DecompressFile(input, output);

TaskHelper.Process(args, execute, "Decompress", "decompressed", ".raw.bin", FilterCriterias.SoeFilter);
}



}

}