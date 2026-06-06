using BlossomLib.Modules.Parsers;
using BlossomLib.Modules.Security;

namespace RipeConsole
{
// Another caller

internal static partial class ActionInvoker
{
// Encode base64

public static void Base64_Encode(string[] args)
{
bool isWebSafe = RipeArgs.GetBase64Mode(args, 2);
void execute(string input, string output) => Base64.EncodeFile(input, output, isWebSafe);

BatchHelper.Process(args, execute, "Encode", "encoded", ".bin", FilterCriterias.DefaultFilter);
}

// Decode base64

public static void Base64_Decode(string[] args)
{
bool isWebSafe = RipeArgs.GetBase64Mode(args, 2);
void execute(string input, string output) => Base64.DecodeFile(input, output, isWebSafe);

BatchHelper.Process(args, execute, "Decode", "decode", ".raw.bin", 
                    FilterCriterias.BinFilter, PickerFilters.Binary);

}

// Xor cipher

public static void Xor_Cipher(string[] args)
{
var key = RipeArgs.GetCipherKey(args, 2);
void execute(string input, string output) => XorCryptor.CipherFile(input, output, key);

BatchHelper.Process(args, execute, "Cipher", "xor", ".crypto.bin", FilterCriterias.DefaultFilter);
}

// Adler32 digest

public static void Adler32_Digest(string[] args)
{
string inFile = RipeArgs.GetInFile(args, 0);
string outFile = RipeArgs.GetOutFile(args, 1, inFile, ".checksum.txt");

Adler32.HashFile(inFile, outFile);
}

// CRC32 digest

public static void Crc32_Digest(string[] args)
{
string inFile = RipeArgs.GetInFile(args, 0);
string outFile = RipeArgs.GetOutFile(args, 1, inFile, ".checksum.txt");

Crc32.HashFile(inFile, outFile);
}

// Md5 digest

public static void Md5_Digest(string[] args)
{
string inFile = RipeArgs.GetInFile(args, 0);
string outFile = RipeArgs.GetOutFile(args, 1, inFile, ".hash.txt");

Md5Digest.HashFile(inFile, outFile);
}

}

}