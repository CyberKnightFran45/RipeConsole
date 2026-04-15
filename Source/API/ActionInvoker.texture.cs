using MobilePtx = TextureTranscoder.Parsers.PopCapTexture.PtxParser;
using XboxPtx = TextureTranscoder.Parsers.XboxPackedTexture.PtxParser;

using RipeLib;
using TextureTranscoder.Parsers;
using TextureTranscoder.Parsers.PopCapTexture;
using TextureTranscoder.Parsers.SexyTexture;
using TextureTranscoder.Parsers.UTexture;
using TextureTranscoder.Parsers.XnaGameStudio;
using TextureTranscoder.Parsers.GXT;
using TextureTranscoder.Parsers.DirectDrawSurface;

namespace RipeConsole
{
// Caller to TextureTranscoder DLL

internal static partial class ActionInvoker
{
// Encode PTX

public static void PTX_Encode(string[] args)
{
string inFile = ArgsParser.GetInPath(args, 0);
string outFile = ArgsParser.GetOutPath(args, 1, inFile, ".ptx");

string infoPath = ArgsParser.GetPath(args, 2, "Select where to save PTX info");

var format = ArgsParser.GetEnumOrDefault<PtxFormat>(args, 3, "Select PTX format");
var endianness = ArgsParser.GetEnumOrDefault<Endianness>(args, 4, "Select endianness");

MobilePtx.EncodeFile(inFile, outFile, infoPath, format, endianness);
}

// Decode PTX

public static void PTX_Decode(string[] args)
{
string inFile = ArgsParser.GetInPath(args, 0);
string outFile = ArgsParser.GetOutPath(args, 1, inFile, ".png");

string infoPath = ArgsParser.GetPath(args, 2, "Select path to PTX info");

MobilePtx.DecodeFile(inFile, outFile, infoPath);
}

// Encode Xbox-PTX

public static void PTX360_Encode(string[] args)
{
static void execute(string input, string output) => XboxPtx.EncodeFile(input, output);

TaskHelper.Process(args, execute, "Encode", "encoded", ".ptx", FilterCriterias.ImgFilter);
}

// Decode Xbox-PTX

public static void PTX360_Decode(string[] args)
{
static void execute(string input, string output) => XboxPtx.DecodeFile(input, output);

TaskHelper.Process(args, execute, "Decode", "decoded", ".png", FilterCriterias.PtxFilter);
}

// Encode SexyTex

public static void SexyTex_Encode(string[] args)
{
var format = ArgsParser.GetEnumOrDefault<SexyTexFormat>(args, 2, "Select SexyTex format");
void execute(string input, string output) => SexyTexParser.EncodeFile(input, output, format);

TaskHelper.Process(args, execute, "Encode", "encoded", ".tex", FilterCriterias.ImgFilter);
}

// Decode SexyTex

public static void SexyTex_Decode(string[] args)
{
static void execute(string input, string output) => SexyTexParser.DecodeFile(input, output);

TaskHelper.Process(args, execute, "Decode", "decoded", ".png", FilterCriterias.TexFilter);
}

// Encode UTex

public static void UTex_Encode(string[] args)
{
var format = ArgsParser.GetEnumOrDefault<UTexFormat>(args, 2, "Select U-Tex format");
void execute(string input, string output) => UTexParser.EncodeFile(input, output, format);

TaskHelper.Process(args, execute, "Encode", "encoded", ".tex", FilterCriterias.ImgFilter);
}

// Decode UTex

public static void UTex_Decode(string[] args)
{
static void execute(string input, string output) => UTexParser.DecodeFile(input, output);

TaskHelper.Process(args, execute, "Decode", "decoded", ".png", FilterCriterias.TexFilter);
}

// Encode TXZ

public static void TXZ_Encode(string[] args)
{
var format = ArgsParser.GetEnumOrDefault<UTexFormat>(args, 2, "Select TXZ format");
void execute(string input, string output) => TxzParser.EncodeFile(input, output, format);

TaskHelper.Process(args, execute, "Encode", "encoded", ".tex", FilterCriterias.ImgFilter);
}

// Decode TXZ

public static void TXZ_Decode(string[] args)
{
static void execute(string input, string output) => TxzParser.DecodeFile(input, output);

TaskHelper.Process(args, execute, "Decode", "decoded", ".png", FilterCriterias.TexFilter);
}

// Encode XNB

public static void XNB_Encode(string[] args)
{
var platform = ArgsParser.GetEnumOrDefault<XnbPlatform>(args, 2, "Select XNB platform");
var format = ArgsParser.GetEnumOrDefault<XnbFormat>(args, 3, "Select XNB format");

void execute(string input, string output) => XnbParser.EncodeFile(input, output, platform, format);

TaskHelper.Process(args, execute, "Encode", "encoded", ".xnb", FilterCriterias.ImgFilter);
}

// Decode XNB

public static void XNB_Decode(string[] args)
{
static void execute(string input, string output) => XnbParser.DecodeFile(input, output);

TaskHelper.Process(args, execute, "Decode", "decoded", ".png", FilterCriterias.XnbFilter);
}

// Encode GXT

public static void GXT_Encode(string[] args)
{
string inFile = ArgsParser.GetInPath(args, 0);
string outFile = ArgsParser.GetOutPath(args, 1, inFile, ".gxt");

var format = ArgsParser.GetEnumOrDefault<GxtFormat>(args, 2, "Select GXT format");

GxtParser.EncodeFile(inFile, outFile, format);
}

// Decode GXT

public static void GXT_Decode(string[] args)
{
string inFile = ArgsParser.GetInPath(args, 0);
string outDir = ArgsParser.GetOutDir(args, 1, inFile, "decoded");

GxtParser.DecodeFile(inFile, outDir);
}

// Encode DDS

public static void DDS_Encode(string[] args)
{
var format = ArgsParser.GetEnumOrDefault<DdsFormat>(args, 2, "Select DDS format");
void execute(string input, string output) => DdsParser.EncodeFile(input, output, format);

TaskHelper.Process(args, execute, "Encode", "encoded", ".dds", FilterCriterias.ImgFilter);
}

// Decode DDS

public static void DDS_Decode(string[] args)
{
static void execute(string input, string output) => DdsParser.DecodeFile(input, output);

TaskHelper.Process(args, execute, "Decode", "decoded", ".png", FilterCriterias.DdsFilter);
}

}

}