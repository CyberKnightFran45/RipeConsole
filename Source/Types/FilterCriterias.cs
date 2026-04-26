using System;
using System.Collections.Generic;

namespace RipeConsole
{
// Filter criterias for Files

internal static class FilterCriterias
{
// Default filter

public static readonly Func<string, bool> DefaultFilter;

// Json filter

public static readonly Func<string, bool> JsonFilter;

// Images filter

public static readonly Func<string, bool> ImgFilter;

// Lua filter

public static readonly Func<string, bool> LuaFilter;

// Bin filter

public static readonly Func<string, bool> BinFilter;

// Zip filter

public static readonly Func<string, bool> ToZipFilter;

public static readonly Func<string, bool> ZipFilter;

// Deflate filter

public static readonly Func<string, bool> DflFilter;

// Gzip filter

public static readonly Func<string, bool> GzFilter;

// Zlib filter

public static readonly Func<string, bool> ZlibFilter;

// LawnStrings filter

public static readonly Func<string, bool> LawnStringsFilter;

public static readonly Func<string, bool> LawnStringsFilterCN;

// CompiledTxt filter

public static readonly Func<string, bool> CompiledTxtFilter;

// PvZ User filter

public static readonly Func<string, bool> PvZUserFilter;

public static readonly Func<string, bool> PvZRawUserFilter;

// PvZ Font filter

public static readonly Func<string, bool> PvZFontFilter;

// Rton filter

public static readonly Func<string, bool> RtonFilter;

// Newton filter

public static readonly Func<string, bool> NewtonFilter;

public static readonly Func<string, bool> NewtonRawFilter;

// Cdat filter

public static readonly Func<string, bool> CdatFilter;

// Smf filter

public static readonly Func<string, bool> SmfFilter;

// Soe filter

public static readonly Func<string, bool> SoeFilter;

// Pak filter

public static readonly Func<string, bool> PakFilter;

// Rsb filter

public static readonly Func<string, bool> RsbFilter;

// Rsgp filter

public static readonly Func<string, bool> RsgpFilter;

// Arcv filter

public static readonly Func<string, bool> ArcvFilter;

// DZip filter

public static readonly Func<string, bool> DZipFilter;

// Xpr filter

public static readonly Func<string, bool> XprFilter;

// PopCap res filter

public static readonly Func<string, bool> PopCapResFilter;

// PTX filter

public static readonly Func<string, bool> PtxFilter;

// SexyTex filter

public static readonly Func<string, bool> TexFilter;

// Txz filter

public static readonly Func<string, bool> TxzFilter;

// Xnb filter

public static readonly Func<string, bool> XnbFilter;

// Gxt filter

public static readonly Func<string, bool> GxtFilter;

// Dds filter

public static readonly Func<string, bool> DdsFilter;

// Default

private static readonly HashSet<string> DEFAULT_EXT = [ ".*" ];

private static readonly HashSet<string> DEFAULT_NAMES = [ "*" ];

// Text

private static readonly HashSet<string> TXT_EXT = new(StringComparer.OrdinalIgnoreCase)
{
".txt"
};

// Json

private static readonly HashSet<string> JSON_EXT = new(StringComparer.OrdinalIgnoreCase)
{
".json"
};

// Bitmap

private static readonly HashSet<string> IMG_EXT = new(StringComparer.OrdinalIgnoreCase)
{
".bmp",
".img",
".jpg",
".png"
};

// Lua script

private static readonly HashSet<string> LUA_EXT = [ ".lua" ];

// Binary

private static readonly HashSet<string> BIN_EXT = new(StringComparer.OrdinalIgnoreCase)
{
".bin"
};

// Zip

private static readonly HashSet<string> ZIP_EXT = new(StringComparer.OrdinalIgnoreCase)
{
".zip"
};

// Deflate

private static readonly HashSet<string> DEFLATE_EXT = new(StringComparer.OrdinalIgnoreCase)
{
".bin",
".deflate",
".dfl"
};

// GZip

private static readonly HashSet<string> GZIP_EXT = new(StringComparer.OrdinalIgnoreCase)
{
".bin",
".gzip",
".gz"
};

// ZLib

private static readonly HashSet<string> ZLIB_EXT = new(StringComparer.OrdinalIgnoreCase)
{
".bin",
".zlib",
".zl"
};

// PopCap text

private static readonly HashSet<string> POPCAP_TXT_EXT = new(StringComparer.OrdinalIgnoreCase)
{
".txt",
".json",
".rton"
};

// LawnStrings names

private static readonly HashSet<string> LAWNSTRINGS_NAMES = new(StringComparer.OrdinalIgnoreCase)
{
"LawnStrings",
"LawnStrings-de-de",
"LawnStrings-en-us",
"LawnStrings-es-es",
"LawnStrings-fr-fr",
"LawnStrings-it-it",
"LawnStrings-pt-br",
"android_file",
"ios_file"
};

// LawnStrings names (Chinese version)

private static readonly HashSet<string> LAWNSTRINGS_NAMES_CN = new(StringComparer.OrdinalIgnoreCase)
{
"LawnStrings",
"android_file",
"ios_file"
};

// PvZ userdata

private static readonly HashSet<string> PVZ_USERDATA_EXT = [ ".dat" ];

private static readonly HashSet<string> PVZ_USERDATA_NAMES = [ "user1", "user2", "user3" ];

// PvZ Font

private static readonly HashSet<string> PVZ_FONT_EXT = new(StringComparer.OrdinalIgnoreCase)
{
".cfw2"
};

// Rton

private static readonly HashSet<string> RTON_EXT = new(StringComparer.OrdinalIgnoreCase)
{
".bak",
".dat",
".rton"
};

// Newton

private static readonly HashSet<string> NEWTON_EXT = new(StringComparer.OrdinalIgnoreCase)
{
".newton"
};

// Cdat

private static readonly HashSet<string> CDAT_EXT = new(StringComparer.OrdinalIgnoreCase)
{
".cdat"
};

// Soe

private static readonly HashSet<string> SOE_EXT = new(StringComparer.OrdinalIgnoreCase)
{
".soe"
};

// Smf

private static readonly HashSet<string> SMF_EXT = new(StringComparer.OrdinalIgnoreCase)
{
".smf"
};

// Arcv

private static readonly HashSet<string> ARCV_EXT = new(StringComparer.OrdinalIgnoreCase)
{
".arcv"
};

// Dzip

private static readonly HashSet<string> DZIP_EXT = new(StringComparer.OrdinalIgnoreCase)
{
".dzip",
".dz"
};

// Pak

private static readonly HashSet<string> PAK_EXT = new(StringComparer.OrdinalIgnoreCase) 
{
".pak"
};

// Xpr

private static readonly HashSet<string> XPR_EXT = new(StringComparer.OrdinalIgnoreCase)
{
".xpr"
};

// Rsb

private static readonly HashSet<string> RSB_EXT = new(StringComparer.OrdinalIgnoreCase)
{
".1bsr",
".rsb",
".rsb1",
".obb",
".smf"
};

// Rsgp

private static readonly HashSet<string> RSGP_EXT = new(StringComparer.OrdinalIgnoreCase)
{
".gsr",
".pgsr",
".rsg",
".rsgp"
};

// PopCap res

private static readonly HashSet<string> POPCAP_RES_NAMES = new(StringComparer.OrdinalIgnoreCase)
{
"Resources",
"ResourcesDynamic",
"ResourcesInit",
"ResourcesLuaAct"
};

// Ptx

private static readonly HashSet<string> PTX_EXT = new(StringComparer.OrdinalIgnoreCase)
{
".ptx"
};

// SexyTex

private static readonly HashSet<string> TEX_EXT = new(StringComparer.OrdinalIgnoreCase)
{
".tex"
};

// Txz

private static readonly HashSet<string> TXZ_EXT = new(StringComparer.OrdinalIgnoreCase)
{
".txz"
};

// Xnb

private static readonly HashSet<string> XNB_EXT = new(StringComparer.OrdinalIgnoreCase)
{
".xnb"
};

// Gxt

private static readonly HashSet<string> GXT_EXT = new(StringComparer.OrdinalIgnoreCase)
{
".gxt"
};

// DirectDraw Surface

private static readonly HashSet<string> DDS_EXT = new(StringComparer.OrdinalIgnoreCase)
{
".dds"
};


// Init 

static FilterCriterias()
{
DefaultFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, DEFAULT_EXT);

JsonFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, JSON_EXT);
ImgFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, IMG_EXT);
LuaFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, LUA_EXT);
BinFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, BIN_EXT);

ToZipFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, DEFAULT_EXT, null, ZIP_EXT);
ZipFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, ZIP_EXT);

DflFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, DEFLATE_EXT);
GzFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, GZIP_EXT);
ZlibFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, ZLIB_EXT);

LawnStringsFilter = PathHelper.CreateFileFilter(LAWNSTRINGS_NAMES, POPCAP_TXT_EXT);
LawnStringsFilterCN = PathHelper.CreateFileFilter(LAWNSTRINGS_NAMES_CN, TXT_EXT);

CompiledTxtFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, POPCAP_TXT_EXT);

PvZUserFilter = PathHelper.CreateFileFilter(PVZ_USERDATA_NAMES, PVZ_USERDATA_EXT);
PvZRawUserFilter = PathHelper.CreateFileFilter(PVZ_USERDATA_NAMES, JSON_EXT);

PvZFontFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, PVZ_FONT_EXT);

NewtonFilter = PathHelper.CreateFileFilter(POPCAP_RES_NAMES, NEWTON_EXT);
NewtonRawFilter = PathHelper.CreateFileFilter(POPCAP_RES_NAMES, JSON_EXT);

RtonFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, RTON_EXT);

CdatFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, CDAT_EXT);

SoeFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, SOE_EXT);
SmfFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, SMF_EXT);

ArcvFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, ARCV_EXT);
DZipFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, DZIP_EXT);
PakFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, PAK_EXT);
XprFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, XPR_EXT);
RsbFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, RSB_EXT);
RsgpFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, RSGP_EXT);

PopCapResFilter = PathHelper.CreateFileFilter(POPCAP_RES_NAMES, JSON_EXT);

PtxFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, PTX_EXT);
TexFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, TEX_EXT);
TxzFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, TXZ_EXT);
XnbFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, XNB_EXT);
GxtFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, GXT_EXT);
DdsFilter = PathHelper.CreateFileFilter(DEFAULT_NAMES, DDS_EXT);
}

}

}