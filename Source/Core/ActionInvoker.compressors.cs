using BlossomLib.Modules.Compression;

namespace RipeConsole
{
// Caller to .NET Compressors

internal static partial class ActionInvoker
{
// Compress Zip

public static void Zip_Compress(string[] args)
{
string srcPath = RipeArgs.GetInPath(args, 0);
string outFile = RipeArgs.GetOutFile(args, 1, srcPath, ".zip");

var compressLvl = RipeArgs.GetCompressLvl(args, 2);

ZipCompressor.Compress(srcPath, outFile, compressLvl);
}

// Extract Zip

public static void Zip_Extract(string[] args)
{
string srcFile = RipeArgs.GetInFile(args, 0, PickerFilters.Zip);
string outDir = RipeArgs.GetOutDir(args, 1, srcFile, "unpacked");

ZipCompressor.Decompress(srcFile, outDir);
}

// Compress Brotli

public static void Brotli_Compress(string[] args)
{
var compressLvl = RipeArgs.GetCompressLvl(args, 2);
void execute(string input, string output) => BrotliCompressor.CompressFile(input, output, compressLvl);

BatchHelper.Process(args, execute, "Compress", "compressed", ".bin", FilterCriterias.DefaultFilter);
}

// Decompress Brotli

public static void Brotli_Decompress(string[] args)
{
static void execute(string input, string output) => BrotliCompressor.DecompressFile(input, output);

BatchHelper.Process(args, execute, "Decompress", "decompressed", ".raw.bin",
                    FilterCriterias.BrotliFilter, PickerFilters.Brotli);

}

// Compress BZip2

public static void Bz2_Compress(string[] args)
{
int blockSize = RipeArgs.GetBlockSize(args, 2);
void execute(string input, string output) => BZip2Compressor.CompressFile(input, output, blockSize);

BatchHelper.Process(args, execute, "Compress", "compressed", ".bz2", FilterCriterias.DefaultFilter);
}

// Decompress BZip2

public static void Bz2_Decompress(string[] args)
{
static void execute(string input, string output) => BZip2Compressor.DecompressFile(input, output);

BatchHelper.Process(args, execute, "Decompress", "decompressed", ".raw.bin", 
                    FilterCriterias.Bz2Filter, PickerFilters.BZip2);

}

// Compress lzma

public static void Lzma_Compress(string[] args)
{
static void execute(string input, string output) => LzmaCompressor.CompressFile(input, output);

BatchHelper.Process(args, execute, "Compress", "compressed", ".lzma", FilterCriterias.DefaultFilter);
}

// Decompress lzma

public static void Lzma_Decompress(string[] args)
{
static void execute(string input, string output) => LzmaCompressor.DecompressFile(input, output);

BatchHelper.Process(args, execute, "Decompress", "decompressed", ".raw.bin",
                    FilterCriterias.LzmaFilter, PickerFilters.Lzma);

}

// Compress Deflate

public static void Deflate_Compress(string[] args)
{
var compressLvl = RipeArgs.GetCompressLvl(args, 2);
void execute(string input, string output) => DeflateCompressor.CompressFile(input, output, compressLvl);

BatchHelper.Process(args, execute, "Compress", "compressed", ".bin", FilterCriterias.DefaultFilter);
}

// Decompress Deflate

public static void Deflate_Decompress(string[] args)
{
static void execute(string input, string output) => DeflateCompressor.DecompressFile(input, output);

BatchHelper.Process(args, execute, "Decompress", "decompressed", ".raw.bin",
                    FilterCriterias.DflFilter, PickerFilters.Deflate);

}

// Compress GZip

public static void GZip_Compress(string[] args)
{
var compressLvl = RipeArgs.GetCompressLvl(args, 2);
void execute(string input, string output) => GZipCompressor.CompressFile(input, output, compressLvl);

BatchHelper.Process(args, execute, "Compress", "compressed", ".bin", FilterCriterias.DefaultFilter);
}

// Decompress GZip

public static void GZip_Decompress(string[] args)
{
static void execute(string input, string output) => GZipCompressor.DecompressFile(input, output);

BatchHelper.Process(args, execute, "Decompress", "decompressed", ".raw.bin",
                    FilterCriterias.GzFilter, PickerFilters.GZip);

}

// Compress Zlib

public static void Zlib_Compress(string[] args)
{
var compressLvl = RipeArgs.GetCompressLvl(args, 2);
void execute(string input, string output) => ZLibCompressor.CompressFile(input, output, compressLvl);

BatchHelper.Process(args, execute, "Compress", "compressed", ".bin", FilterCriterias.DefaultFilter);
}

// Decompress Zlib

public static void Zlib_Decompress(string[] args)
{
static void execute(string input, string output) => ZLibCompressor.DecompressFile(input, output);

BatchHelper.Process(args, execute, "Decompress", "decompressed", ".raw.bin",
                    FilterCriterias.ZlibFilter, PickerFilters.ZLib);

}

}

}