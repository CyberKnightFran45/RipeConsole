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
using TextureTranscoder.Parsers.RawImage;

namespace RipeConsole
{
// Caller to TextureTranscoder DLL

internal static partial class ActionInvoker
{
// Encode raw img

public static void RawImg_Encode(string[] args)
{
string inFile = RipeArgs.GetInFile(args, 0, PickerFilters.Images);
string outFile = RipeArgs.GetOutFile(args, 1, inFile, ".bin", PickerFilters.Binary);

var format = RipeArgs.GetTexFormat(args, 2);
string infoPath = RipeArgs.GetTexInfoPath(inFile, args, 3);

RawImgParser.EncodeFile(inFile, outFile, format, infoPath);
}

// Decode raw img

public static void RawImg_Decode(string[] args)
{
string inFile = RipeArgs.GetInFile(args, 0, PickerFilters.Binary);
string outFile = RipeArgs.GetOutFile(args, 1, inFile, ".png", PickerFilters.Images);

var info = RipeArgs.GetRawImgInfo(inFile, args);

RawImgParser.DecodeFile(inFile, outFile, info);
}

// Encode PTX

public static void PTX_Encode(string[] args)
{
string inFile = RipeArgs.GetInFile(args, 0, PickerFilters.Images);
string outFile = RipeArgs.GetOutFile(args, 1, inFile, ".ptx", PickerFilters.Ptx);

var format = RipeArgs.GetPtxFormat(args, 2);
var endianness = RipeArgs.GetEnum(args, 3, "Select endianness", Endianness.LittleEndian);

string infoPath = RipeArgs.GetTexInfoPath(inFile, args, 4);

MobilePtx.EncodeFile(inFile, outFile, format, endianness, infoPath);
}

// Decode PTX

public static void PTX_Decode(string[] args)
{
string inFile = RipeArgs.GetInFile(args, 0, PickerFilters.Ptx);
string outFile = RipeArgs.GetOutFile(args, 1, inFile, ".png", PickerFilters.Images);

var info = RipeArgs.GetPtxInfo(inFile, args);

MobilePtx.DecodeFile(inFile, outFile, info);
}

// Encode Xbox-PTX

public static void PTX360_Encode(string[] args)
{
static void execute(string input, string output) => XboxPtx.EncodeFile(input, output);

BatchHelper.Process(args, execute, "Encode", "encoded", ".ptx",
                    FilterCriterias.ImgFilter, PickerFilters.Images);

}

// Decode Xbox-PTX

public static void PTX360_Decode(string[] args)
{
static void execute(string input, string output) => XboxPtx.DecodeFile(input, output);

BatchHelper.Process(args, execute, "Decode", "decoded", ".png", 
                    FilterCriterias.PtxFilter, PickerFilters.Ptx);

}

// Encode SexyTex

public static void SexyTex_Encode(string[] args)
{
var format = RipeArgs.GetEnum(args, 2, "Select SexyTex format", SexyTexFormat.ARGB8888);
void execute(string input, string output) => SexyTexParser.EncodeFile(input, output, format);

BatchHelper.Process(args, execute, "Encode", "encoded", ".tex",
                    FilterCriterias.ImgFilter, PickerFilters.Images);

}

// Decode SexyTex

public static void SexyTex_Decode(string[] args)
{
static void execute(string input, string output) => SexyTexParser.DecodeFile(input, output);

BatchHelper.Process(args, execute, "Decode", "decoded", ".png",
                    FilterCriterias.TexFilter, PickerFilters.SexyTex);

}

// Encode UTex

public static void UTex_Encode(string[] args)
{
var format = RipeArgs.GetEnum(args, 2, "Select U-Tex format", UTexFormat.ABGR8888);
void execute(string input, string output) => UTexParser.EncodeFile(input, output, format);

BatchHelper.Process(args, execute, "Encode", "encoded", ".tex",
                    FilterCriterias.ImgFilter, PickerFilters.Images);

}

// Decode UTex

public static void UTex_Decode(string[] args)
{
static void execute(string input, string output) => UTexParser.DecodeFile(input, output);

BatchHelper.Process(args, execute, "Decode", "decoded", ".png",
                    FilterCriterias.TexFilter, PickerFilters.UTex);

}

// Encode TXZ

public static void TXZ_Encode(string[] args)
{
var format = RipeArgs.GetEnum(args, 2, "Select TXZ format", UTexFormat.ABGR8888);
var compressionLvl = RipeArgs.GetCompressLvl(args, 3);

void execute(string input, string output) => TxzParser.EncodeFile(input, output, format, compressionLvl);

BatchHelper.Process(args, execute, "Encode", "encoded", ".tex",
                    FilterCriterias.ImgFilter, PickerFilters.Images);

}

// Decode TXZ

public static void TXZ_Decode(string[] args)
{
static void execute(string input, string output) => TxzParser.DecodeFile(input, output);

BatchHelper.Process(args, execute, "Decode", "decoded", ".png",
                    FilterCriterias.TexFilter, PickerFilters.Txz);

}

// Encode XNB

public static void XNB_Encode(string[] args)
{
var platform = RipeArgs.GetEnum(args, 2, "Select XNB platform", XnbPlatform.WindowsPhone);
var format = RipeArgs.GetEnum(args, 3, "Select XNB format", XnbFormat.Color);

void execute(string input, string output) => XnbParser.EncodeFile(input, output, platform, format);

BatchHelper.Process(args, execute, "Encode", "encoded", ".xnb", 
                    FilterCriterias.ImgFilter, PickerFilters.Images);

}

// Decode XNB

public static void XNB_Decode(string[] args)
{
static void execute(string input, string output) => XnbParser.DecodeFile(input, output);

BatchHelper.Process(args, execute, "Decode", "decoded", ".png", 
                    FilterCriterias.XnbFilter, PickerFilters.Xnb);

}

// Encode GXT

public static void GXT_Encode(string[] args)
{
string inFolder = RipeArgs.GetInFolder(args, 0, "Select GXT folder");
string outFile = RipeArgs.GetOutDir(args, 1, inFolder, "build");

GxtBuilder.BuildFile(inFolder, outFile);
}

// Decode GXT

public static void GXT_Decode(string[] args)
{
string inFile = RipeArgs.GetInFile(args, 0, PickerFilters.Gxt);
string outDir = RipeArgs.GetOutDir(args, 1, inFile, "decoded");

GxtUnpacker.UnpackFile(inFile, outDir);
}

// Encode DDS

public static void DDS_Encode(string[] args)
{
var format = RipeArgs.GetEnum(args, 2, "Select DDS format", DdsFormat.DXT5);
void execute(string input, string output) => DdsParser.EncodeFile(input, output, format);

BatchHelper.Process(args, execute, "Encode", "encoded", ".dds",
                    FilterCriterias.ImgFilter, PickerFilters.Images);

}

// Decode DDS

public static void DDS_Decode(string[] args)
{
static void execute(string input, string output) => DdsParser.DecodeFile(input, output);

BatchHelper.Process(args, execute, "Decode", "decoded", ".png",
                    FilterCriterias.DdsFilter, PickerFilters.Dds);

}

}

}