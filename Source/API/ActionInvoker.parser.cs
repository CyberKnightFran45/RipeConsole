using RipeLib;
using SexyParsers.CharFontWidget2;
using SexyParsers.Newton;
using SexyParsers.PvZSave;
using SexyParsers.ReflectiveTypeObjectNotation;
using TextHandler;

namespace RipeConsole
{
// Caller to SexyParsers DLL

internal static partial class ActionInvoker
{
// Encode PvZ save

public static void PvZSave_Encode(string[] args)
{
string inPath = ArgsParser.GetInPath(args, 0);
string outPath = ArgsParser.GetOutPath(args, 1, inPath, ".dat");

SaveParser.EncodeFile(inPath, outPath);
}

// Decode PvZ save

public static void PvZSave_Decode(string[] args)
{
string inPath = ArgsParser.GetInPath(args, 0);
string outPath = ArgsParser.GetOutPath(args, 1, inPath, ".json");

SaveParser.DecodeFile(inPath, outPath);
}

// Encode PvZ font

public static void PvZFont_Encode(string[] args)
{
string inPath = ArgsParser.GetInPath(args, 0);
string outPath = ArgsParser.GetOutPath(args, 1, inPath, ".cfw2");

Cfw2Parser.EncodeFile(inPath, outPath);
}

// Decode PvZ font

public static void PvZFont_Decode(string[] args)
{
string inPath = ArgsParser.GetInPath(args, 0);
string outPath = ArgsParser.GetOutPath(args, 1, inPath, ".json");

Cfw2Parser.DecodeFile(inPath, outPath);
}

// Encode RTON

public static void RTON_Encode(string[] args)
{
bool useEncryption = ArgsParser.GetBoolOrDefault(args, 2, "Use RTON encryption");
void execute(string input, string output) => RtonParser.EncodeFile(input, output, useEncryption);

TaskHelper.Process(args, execute, "Encode", "encoded", ".rton", FilterCriterias.JsonFilter);
}

// Decode RTON

public static void RTON_Decode(string[] args)
{
static void execute(string input, string output) => RtonParser.DecodeFile(input, output);

TaskHelper.Process(args, execute, "Decode", "decoded", ".json", FilterCriterias.RtonFilter);
}

// Encode Newton file

public static void Newton_Encode(string[] args)
{
string inPath = ArgsParser.GetInPath(args, 0);
string outPath = ArgsParser.GetOutPath(args, 1, inPath, ".newton");

NewtonParser.Encode(inPath, outPath);
}

// Decode Newton file

public static void Newton_Decode(string[] args)
{
string inPath = ArgsParser.GetInPath(args, 0);
string outPath = ArgsParser.GetOutPath(args, 1, inPath, ".json");

NewtonParser.Decode(inPath, outPath);
}

// Encode Compiled txt

public static void CompiledTxt_Encode(string[] args)
{
static void execute(string input, string output) => CompiledText.EncodeFile(input, output);

TaskHelper.Process(args, execute, "Encode", "encoded", ".compiled.txt", FilterCriterias.CompiledTxtFilter);
}

// Decode Compiled txt

public static void CompiledTxt_Decode(string[] args)
{
static void execute(string input, string output) => CompiledText.DecodeFile(input, output);

TaskHelper.Process(args, execute, "Decode", "decoded", ".plain.txt", FilterCriterias.CompiledTxtFilter);
}

}

}