using RipeLib;
using BlossomLib.Modules.Parsers;
using BlossomLib.Modules.Security;
using BlossomLib.Modules.Compression;

namespace RipeConsole
{
// Another caller

internal static partial class ActionInvoker
{
// Get base64 mode

private static bool GetBase64Mode(string[] args)
{
return ArgsParser.GetBoolOrDefault(args, 2, "Use Web-safe base64");
}

// Encode base64

public static void Base64_Encode(string[] args)
{
bool isWebSafe = GetBase64Mode(args);
void execute(string input, string output) => Base64.EncodeFile(input, output, isWebSafe);

TaskHelper.Process(args, execute, "Encode", "encoded", ".bin", FilterCriterias.DefaultFilter);
}

// Decode base64

public static void Base64_Decode(string[] args)
{
bool isWebSafe = GetBase64Mode(args);
void execute(string input, string output) => Base64.DecodeFile(input, output, isWebSafe);

TaskHelper.Process(args, execute, "Decode", "decode", ".raw.bin", FilterCriterias.BinFilter);
}

// Xor cipher

public static void Xor_Cipher(string[] args)
{
var key = ArgsParser.GetBytesOrDefault(args, 2, "Enter a cipher key");
void execute(string input, string output) => XorCryptor.CipherFile(input, output, key);

TaskHelper.Process(args, execute, "Cipher", "xor", ".crypto.bin", FilterCriterias.DefaultFilter);
}

// Compute md5 hash

private static void GenMd5(string srcPath, string destPath)
{
TraceLogger.WriteActionStart("Computing digest...");

using var input = FileManager.OpenRead(srcPath);
using var digest = GenericDigest.GetString(input, "MD5");

using var output = FileManager.OpenWrite(destPath);

output.WriteString(digest.AsSpan() );

TraceLogger.WriteActionEnd();
}

// Md5 digest

public static void Md5_Digest(string[] args)
{
string inFile = ArgsParser.GetInPath(args, 0);
string outFile = ArgsParser.GetOutPath(args, 1, inFile, ".hash.txt");

GenMd5(inFile, outFile);
}

// Compress Zip

public static void Zip_Compress(string[] args)
{
string srcPath = ArgsParser.GetPath(args, 0, "Select file/folder to compress");
string outFile = ArgsParser.GetOutPath(args, 1, srcPath, ".zip");

var compressLvl = GetCompressLvl(args);

ZipCompressor.Compress(srcPath, outFile, compressLvl);
}

// Extract Zip

public static void Zip_Extract(string[] args)
{
string srcFile = ArgsParser.GetPath(args, 0, "Select zip to extract");
string outDir = ArgsParser.GetOutDir(args, 1, srcFile, "unpacked");

ZipCompressor.Decompress(srcFile, outDir);
}

// Compress Deflate

public static void Deflate_Compress(string[] args)
{
var compressLvl = GetCompressLvl(args);
void execute(string input, string output) => DeflateCompressor.CompressFile(input, output, compressLvl);

TaskHelper.Process(args, execute, "Compress", "compressed", ".bin", FilterCriterias.DefaultFilter);
}

// Decompress Deflate

public static void Deflate_Decompress(string[] args)
{
static void execute(string input, string output) => DeflateCompressor.DecompressFile(input, output);

TaskHelper.Process(args, execute, "Decompress", "decompressed", ".raw.bin", FilterCriterias.ZlibFilter);
}

// Compress GZip

public static void GZip_Compress(string[] args)
{
var compressLvl = GetCompressLvl(args);
void execute(string input, string output) => GZipCompressor.CompressFile(input, output, compressLvl);

TaskHelper.Process(args, execute, "Compress", "compressed", ".bin", FilterCriterias.DefaultFilter);
}

// Decompress GZip

public static void GZip_Decompress(string[] args)
{
static void execute(string input, string output) => GZipCompressor.DecompressFile(input, output);

TaskHelper.Process(args, execute, "Decompress", "decompressed", ".raw.bin", FilterCriterias.GzFilter);
}

// Compress Zlib

public static void Zlib_Compress(string[] args)
{
var compressLvl = GetCompressLvl(args);
void execute(string input, string output) => ZLibCompressor.CompressFile(input, output, compressLvl);

TaskHelper.Process(args, execute, "Compress", "compressed", ".bin", FilterCriterias.DefaultFilter);
}

// Decompress Zlib

public static void Zlib_Decompress(string[] args)
{
static void execute(string input, string output) => ZLibCompressor.DecompressFile(input, output);

TaskHelper.Process(args, execute, "Decompress", "decompressed", ".raw.bin", FilterCriterias.ZlibFilter);
}

}

}