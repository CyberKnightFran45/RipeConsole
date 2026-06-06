using SexyParsers.CharFontWidget2;
using SexyParsers.Newton;
using SexyParsers.PvZSave;
using SexyParsers.ReflectiveTypeObjectNotation;

namespace RipeConsole
{
// Caller to SexyParsers DLL

internal static partial class ActionInvoker
{
// Encode PvZ save

public static void PvZSave_Encode(string[] args)
{
string inPath = RipeArgs.GetInFile(args, 0, PickerFilters.PvZRawUserData);
string outPath = RipeArgs.GetOutFile(args, 1, inPath, ".dat", PickerFilters.PvZUserData);

SaveParser.EncodeFile(inPath, outPath);
}

// Decode PvZ save

public static void PvZSave_Decode(string[] args)
{
string inPath = RipeArgs.GetInFile(args, 0, PickerFilters.PvZUserData);
string outPath = RipeArgs.GetOutFile(args, 1, inPath, ".json", PickerFilters.PvZRawUserData);

SaveParser.DecodeFile(inPath, outPath);
}

// Encode PvZ font

public static void PvZFont_Encode(string[] args)
{
string inPath = RipeArgs.GetInFile(args, 0, PickerFilters.Json);
string outPath = RipeArgs.GetOutFile(args, 1, inPath, ".cfw2", PickerFilters.PvZFont);

Cfw2Parser.EncodeFile(inPath, outPath);
}

// Decode PvZ font

public static void PvZFont_Decode(string[] args)
{
string inPath = RipeArgs.GetInFile(args, 0, PickerFilters.PvZFont);
string outPath = RipeArgs.GetOutFile(args, 1, inPath, ".json", PickerFilters.Json);

Cfw2Parser.DecodeFile(inPath, outPath);
}

// Encode RTON

public static void RTON_Encode(string[] args)
{
static void execute(string input, string output) => RtonParser.EncodeFile(input, output, false);

BatchHelper.Process(args, execute, "Encode", "encoded", ".rton",
                    FilterCriterias.JsonFilter, PickerFilters.Json);

}

// Encode RTON, then encrypt

public static void RTON_EncodeAndEncrypt(string[] args)
{
static void execute(string input, string output) => RtonParser.EncodeFile(input, output, true);

BatchHelper.Process(args, execute, "Encode + Encrypt", "parsed", ".rton",
                    FilterCriterias.JsonFilter, PickerFilters.Json);

}

// Decode RTON

public static void RTON_Decode(string[] args)
{
static void execute(string input, string output) => RtonParser.DecodeFile(input, output);

BatchHelper.Process(args, execute, "Decode", "decoded", ".json",
                    FilterCriterias.RtonFilter, PickerFilters.Rton);

}

// Encode Newton file

public static void Newton_Encode(string[] args)
{
string inPath = RipeArgs.GetInFile(args, 0, PickerFilters.NewtonRaw);
string outPath = RipeArgs.GetOutFile(args, 1, inPath, ".newton", PickerFilters.Newton);

NewtonParser.Encode(inPath, outPath);
}

// Decode Newton file

public static void Newton_Decode(string[] args)
{
string inPath = RipeArgs.GetInPath(args, 0, PickerFilters.Newton);
string outPath = RipeArgs.GetOutPath(args, 1, inPath, ".json", PickerFilters.NewtonRaw);

NewtonParser.Decode(inPath, outPath);
}

}

}