using SexyCryptor;

namespace RipeConsole
{
// Caller to SexyCryptor DLL

internal static partial class ActionInvoker
{
// Encrypt cdat

public static void Cdat_Encrypt(string[] args)
{
static void execute(string input, string output) => Cdat.EncryptFile(input, output);

BatchHelper.Process(args, execute, "Encrypt", "encrypted", ".cdat",
                    FilterCriterias.ImgFilter, PickerFilters.Images);

}

// Decrypt cdat

public static void Cdat_Decrypt(string[] args)
{
static void execute(string input, string output) => Cdat.DecryptFile(input, output);

BatchHelper.Process(args, execute, "Decrypt", "decrypted", ".png", 
                    FilterCriterias.CdatFilter, PickerFilters.Cdat);

}

// Encrypt XXLua

public static void XXLua_Encrypt(string[] args)
{
static void execute(string input, string output) => XXLua.EncryptFile(input, output);

BatchHelper.Process(args, execute, "Encrypt", "encrypted", ".encrypted.lua",
                    FilterCriterias.LuaFilter, PickerFilters.Lua);

}

// Decrypt XXLua

public static void XXLua_Decrypt(string[] args)
{
static void execute(string input, string output) => XXLua.DecryptFile(input, output);

BatchHelper.Process(args, execute, "Decrypt", "decrypted", ".plain.lua", 
                    FilterCriterias.LuaFilter, PickerFilters.Lua);

}

// Encrypt RTON

public static void RTON_Encrypt(string[] args)
{
static void execute(string input, string output) => CRton.EncryptFile(input, output);

BatchHelper.Process(args, execute, "Encrypt", "encrypted", ".encrypted.rton",
                    FilterCriterias.RtonFilter, PickerFilters.Rton);

}

// Decrypt RTON

public static void RTON_Decrypt(string[] args)
{
static void execute(string input, string output) => CRton.DecryptFile(input, output);

BatchHelper.Process(args, execute, "Decrypt", "decrypted", ".raw.rton", 
                    FilterCriterias.RtonFilter, PickerFilters.Rton);

}

}

}