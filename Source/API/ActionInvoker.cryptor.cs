using RipeLib;
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

TaskHelper.Process(args, execute, "Encrypt", "encrypted", ".cdat", FilterCriterias.ImgFilter);
}

// Decrypt cdat

public static void Cdat_Decrypt(string[] args)
{
static void execute(string input, string output) => Cdat.DecryptFile(input, output);

TaskHelper.Process(args, execute, "Decrypt", "decrypted", ".png", FilterCriterias.CdatFilter);
}

// Encrypt XXLua

public static void XXLua_Encrypt(string[] args)
{
static void execute(string input, string output) => XXLua.EncryptFile(input, output);

TaskHelper.Process(args, execute, "Encrypt", "encrypted", ".encrypted.lua", FilterCriterias.LuaFilter);
}

// Decrypt XXLua

public static void XXLua_Decrypt(string[] args)
{
static void execute(string input, string output) => XXLua.DecryptFile(input, output);

TaskHelper.Process(args, execute, "Decrypt", "decrypted", ".plain.lua", FilterCriterias.LuaFilter);
}

// Encrypt RTON

public static void RTON_Encrypt(string[] args)
{
static void execute(string input, string output) => CRton.EncryptFile(input, output);

TaskHelper.Process(args, execute, "Encrypt", "encrypted", ".encrypted.rton", FilterCriterias.RtonFilter);
}

// Decrypt RTON

public static void RTON_Decrypt(string[] args)
{
static void execute(string input, string output) => CRton.DecryptFile(input, output);

TaskHelper.Process(args, execute, "Decrypt", "decrypted", ".raw.rton", FilterCriterias.RtonFilter);
}

}

}