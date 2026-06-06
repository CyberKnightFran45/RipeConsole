using SexyCompressors;
using SexyCompressors.PopCapZLib;

namespace RipeConsole
{
// Caller to SexyCompressors DLL

internal static partial class ActionInvoker
{
// Compress SMF

public static void SMF_Compress(string[] args)
{
var compressLvl = RipeArgs.GetCompressLvl(args, 2);
bool genTag = RipeArgs.GetBool(args, 3, "Generate smf tag", true);

void execute(string input, string output) => SmfCompressor.CompressFile(input, output, compressLvl, genTag);

BatchHelper.Process(args, execute, "Compress", "compressed", "rsb.smf",
                    FilterCriterias.RsbFilter, PickerFilters.Rsb);

}

// Decompress SMF

public static void SMF_Decompress(string[] args)
{
bool removeExt = RipeArgs.GetBool(args, 3, "Remove smf extension", true);
void execute(string input, string output) => SmfCompressor.DecompressFile(input, output, removeExt);

BatchHelper.Process(args, execute, "Decompress", "decompressed", ".rsb",
                    FilterCriterias.SmfFilter, PickerFilters.Smf);

}

// Create SMF tag

public static void SMF_CreateTag(string[] args)
{
static void execute(string input, string output) => SmfTagCreator.CreateTag(input, output);

BatchHelper.Process(args, execute, "Create tag", "tags", ".smf",
                    FilterCriterias.SmfFilter, PickerFilters.Smf);

}

// Compress SOE

public static void SOE_Compress(string[] args)
{
var compressLvl = RipeArgs.GetCompressLvl(args, 2);
void execute(string input, string output) => SoeCompressor.CompressFile(input, output, compressLvl);

BatchHelper.Process(args, execute, "Compress", "compressed", ".soe", FilterCriterias.DefaultFilter);
}

// Decompress SOE

public static void SOE_Decompress(string[] args)
{
static void execute(string input, string output) => SoeCompressor.DecompressFile(input, output);

BatchHelper.Process(args, execute, "Decompress", "decompressed", ".raw.bin",
                    FilterCriterias.SoeFilter, PickerFilters.Soe);

}

}

}