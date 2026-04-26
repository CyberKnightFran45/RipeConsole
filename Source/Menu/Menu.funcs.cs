using System;
using RipeLib;

namespace RipeConsole
{
// Func loader

internal static partial class Menu
{
// Init options

private static void InitOptions()
{
options = new();

ToolAction exit = new()
{
Name = "Exit",
Execute = _  => Environment.Exit(0),
AllowFiles = true,
AllowDirs = true
};

options.Add(0, exit);

// ========  TextHandler ========

ToolAction lawnStrSort = new()
{
Name = "LawnStrings Manager - Sort file",
Execute = ActionInvoker.LawnStrings_Sort,
FileFilter = FilterCriterias.LawnStringsFilter,
AllowFiles = true
};

options.Add(1, lawnStrSort);

ToolAction lawnStrConvert = new()
{
Name = "LawnStrings Manager - Convert file",
Execute = ActionInvoker.LawnStrings_Convert,
FileFilter = FilterCriterias.LawnStringsFilter,
AllowFiles = true
};

options.Add(2, lawnStrConvert);

ToolAction lawnStrCompare = new()
{
Name = "LawnStrings Manager - Compare files",
Execute = ActionInvoker.LawnStrings_Compare,
FileFilter = FilterCriterias.LawnStringsFilter,
AllowFiles = true
};

options.Add(3, lawnStrCompare);

ToolAction lawnStrUpdate = new()
{
Name = "LawnStrings Manager - Update file",
Execute = ActionInvoker.LawnStrings_Update,
FileFilter = FilterCriterias.LawnStringsFilter,
AllowFiles = true
};

options.Add(4, lawnStrUpdate);

ToolAction lawnStrDownload = new()
{
Name = "LawnStrings Server - Download res",
Execute = ActionInvoker.LawnStringsServer_DownloadRes
};

options.Add(5, lawnStrDownload);

ToolAction lawnSvGetUpdate = new()
{
Name = "LawnStrings Server - Get new text",
Execute = ActionInvoker.LawnStringsServer_GetUpdate,
FileFilter = FilterCriterias.LawnStringsFilterCN,
AllowFiles = true
};

options.Add(6, lawnSvGetUpdate);

ToolAction lawnSvUpdate = new()
{
Name = "LawnStrings Server - Update file",
Execute = ActionInvoker.LawnStringsServer_Update,
FileFilter = FilterCriterias.LawnStringsFilterCN,
AllowFiles = true
};

options.Add(7, lawnSvUpdate);

ToolAction cTxtEncode = new()
{
Name = "PopCap Compiled Text - Encode",
Execute = ActionInvoker.CompiledTxt_Encode,
FileFilter = FilterCriterias.CompiledTxtFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(8, cTxtEncode);

ToolAction cTxtDecode = new()
{
Name = "PopCap Compiled Text - Decode",
Execute = ActionInvoker.CompiledTxt_Decode,
FileFilter = FilterCriterias.CompiledTxtFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(9, cTxtDecode);

// ========  SexyParser ========

ToolAction userdataEncode = new()
{
Name = "PvZ Userdata - Encode",
Execute = ActionInvoker.PvZSave_Encode,
FileFilter = FilterCriterias.PvZRawUserFilter,
AllowFiles = true,
};

options.Add(10, userdataEncode);

ToolAction userdataDecode = new()
{
Name = "PvZ Userdata - Decode",
Execute = ActionInvoker.PvZSave_Decode,
FileFilter = FilterCriterias.PvZUserFilter,
AllowFiles = true,
};

options.Add(11, userdataDecode);

ToolAction cfw2Encode = new()
{
Name = "PvZ Font - Encode",
Execute = ActionInvoker.PvZFont_Encode,
FileFilter = FilterCriterias.JsonFilter,
AllowFiles = true,
};

options.Add(12, cfw2Encode);

ToolAction cfw2Decode = new()
{
Name = "PvZ Font - Decode",
Execute = ActionInvoker.PvZFont_Decode,
FileFilter = FilterCriterias.PvZFontFilter,
AllowFiles = true,
};

options.Add(13, cfw2Decode);

ToolAction rtonEncode = new()
{
Name = "RTON Parser - Encode",
Execute = ActionInvoker.RTON_Encode,
FileFilter = FilterCriterias.JsonFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(14, rtonEncode);

ToolAction rtonDecode = new()
{
Name = "RTON Parser - Decode",
Execute = ActionInvoker.RTON_Decode,
FileFilter = FilterCriterias.RtonFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(15, rtonDecode);

ToolAction newtonEncode = new()
{
Name = "Newton Parser - Encode",
Execute = ActionInvoker.Newton_Encode,
FileFilter = FilterCriterias.NewtonRawFilter,
AllowFiles = true,
};

options.Add(16, newtonEncode);

ToolAction newtonDecode = new()
{
Name = "Newton Parser - Decode",
Execute = ActionInvoker.Newton_Decode,
FileFilter = FilterCriterias.NewtonFilter,
AllowFiles = true,
};

options.Add(17, newtonDecode);

// ======== SexyCryptors ========

ToolAction cdatEncrypt = new()
{
Name = "PvZ Mobile - Encrypt Res",
Execute = ActionInvoker.Cdat_Encrypt,
FileFilter = FilterCriterias.ImgFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(20, cdatEncrypt);

ToolAction cdatDecrypt = new()
{
Name = "PvZ Mobile - Decrypt Res",
Execute = ActionInvoker.Cdat_Decrypt,
FileFilter = FilterCriterias.CdatFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(21, cdatDecrypt);

ToolAction luaEncrypt = new()
{
Name = "PvZ AllStars - Encrypt Lua",
Execute = ActionInvoker.XXLua_Encrypt,
FileFilter = FilterCriterias.LuaFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(22, luaEncrypt);

ToolAction luaDecrypt = new()
{
Name = "PvZ AllStars - Decrypt Lua",
Execute = ActionInvoker.XXLua_Decrypt,
FileFilter = FilterCriterias.LuaFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(23, luaDecrypt);

ToolAction rtonEncrypt = new()
{
Name = "RTON Cryptor - Encrypt",
Execute = ActionInvoker.RTON_Encrypt,
FileFilter = FilterCriterias.RtonFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(24, rtonEncrypt);

ToolAction rtonDecrypt = new()
{
Name = "RTON Cryptor - Decrypt",
Execute = ActionInvoker.RTON_Decrypt,
FileFilter = FilterCriterias.RtonFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(25, rtonDecrypt);

// ======== SexyCompressors ========

ToolAction smfCompress = new()
{
Name = "SMF Compressor - Compress",
Execute = ActionInvoker.SMF_Compress,
FileFilter = FilterCriterias.RsbFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(30, smfCompress);

ToolAction smfDecompress = new()
{
Name = "SMF Compressor - Decompress",
Execute = ActionInvoker.SMF_Decompress,
FileFilter = FilterCriterias.SmfFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(31, smfDecompress);

ToolAction smfGenTag = new()
{
Name = "SMF Compressor - Create tag",
Execute = ActionInvoker.SMF_CreateTag,
FileFilter = FilterCriterias.SmfFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(32, smfGenTag);

ToolAction soeCompress = new()
{
Name = "SOE Compressor - Compress",
Execute = ActionInvoker.SOE_Compress,
FileFilter = FilterCriterias.DefaultFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(33, soeCompress);

ToolAction soeDecompress = new()
{
Name = "SOE Compressor - Decompress",
Execute = ActionInvoker.SOE_Decompress,
FileFilter = FilterCriterias.SoeFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(34, soeDecompress);

// ======== SexyPackages ========

ToolAction pakBuild = new()
{
Name = "PopCap Package - Build",
Execute = ActionInvoker.PAK_Build,
AllowDirs = true
};

options.Add(40, pakBuild);

ToolAction pakExtract = new()
{
Name = "PopCap Package - Extract",
Execute = ActionInvoker.PAK_Extract,
FileFilter = FilterCriterias.PakFilter,
AllowFiles = true
};

options.Add(41, pakExtract);

// Rsb TO-DO: 42-43


ToolAction rsgPack = new()
{
Name = "PopCap Resources Group - Pack",
Execute = ActionInvoker.RSG_Pack,
AllowDirs = true
};

options.Add(44, rsgPack);

ToolAction rsgUnpack = new()
{
Name = "PopCap Resources Group - Unpack",
Execute = ActionInvoker.RSG_Unpack,
FileFilter = FilterCriterias.RsgpFilter,
AllowFiles = true
};

options.Add(45, rsgUnpack);

ToolAction arcvPack = new()
{
Name = "ArcV Package - Build",
Execute = ActionInvoker.ARCV_Pack,
AllowDirs = true
};

options.Add(46, arcvPack);

ToolAction arcvUnpack = new()
{
Name = "ArcV Package - Extract",
Execute = ActionInvoker.ARCV_Unpack,
FileFilter = FilterCriterias.ArcvFilter,
AllowFiles = true
};

options.Add(47, arcvUnpack);

// Dz TO-DO: 48-49



ToolAction xprBuild = new()
{
Name = "Xbox Package - Build",
Execute = ActionInvoker.XPR_Build,
AllowDirs = true
};

options.Add(50, xprBuild);

ToolAction xprExtract = new()
{
Name = "Xbox Package - Extract",
Execute = ActionInvoker.XPR_Unpack,
FileFilter = FilterCriterias.XprFilter,
AllowFiles = true
};

options.Add(51, xprExtract);

// ======== PopCap Res Manager ========

ToolAction resInfo2Gp = new()
{
Name = "PopCap Res Manager - ResInfo to Group",
Execute = ActionInvoker.PopCapRes_ToGroup,
FileFilter = FilterCriterias.PopCapResFilter,
AllowFiles = true
};

options.Add(60, resInfo2Gp);

ToolAction resGp2Info = new()
{
Name = "PopCap Res Manager - ResGroup to Info",
Execute = ActionInvoker.PopCapRes_ToInfo,
FileFilter = FilterCriterias.PopCapResFilter,
AllowFiles = true
};

options.Add(61, resGp2Info);

ToolAction splitRes = new()
{
Name = "PopCap Res Manager - Split",
Execute = ActionInvoker.PopCapRes_Split,
FileFilter = FilterCriterias.PopCapResFilter,
AllowFiles = true
};

options.Add(62, splitRes);

ToolAction mergeRes = new()
{
Name = "PopCap Res Manager - Merge",
Execute = ActionInvoker.PopCapRes_Merge,
AllowDirs = true
};

options.Add(63, mergeRes);

// ======== TextureTranscoder ========

ToolAction encodePtx = new()
{
Name = "PopCap Texture - Encode",
Execute = ActionInvoker.PTX_Encode,
FileFilter = FilterCriterias.ImgFilter,
AllowFiles = true
};

options.Add(70, encodePtx);

ToolAction decodePtx = new()
{
Name = "PopCap Texture - Decode",
Execute = ActionInvoker.PTX_Decode,
FileFilter = FilterCriterias.PtxFilter,
AllowFiles = true
};

options.Add(71, decodePtx);

ToolAction encodePtx360 = new()
{
Name = "Xbox Texture - Encode",
Execute = ActionInvoker.PTX360_Encode,
FileFilter = FilterCriterias.ImgFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(72, encodePtx360);

ToolAction decodePtx360 = new()
{
Name = "Xbox Texture - Decode",
Execute = ActionInvoker.PTX360_Decode,
FileFilter = FilterCriterias.PtxFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(73, decodePtx360);

ToolAction encodeSexyTex = new()
{
Name = "Sexy Texture - Encode",
Execute = ActionInvoker.SexyTex_Encode,
FileFilter = FilterCriterias.ImgFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(74, encodeSexyTex);

ToolAction decodeSexyTex = new()
{
Name = "Sexy Texture - Decode",
Execute = ActionInvoker.SexyTex_Decode,
FileFilter = FilterCriterias.TexFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(75, decodeSexyTex);

ToolAction uTexEncode = new()
{
Name = "U-Texture - Encode",
Execute = ActionInvoker.UTex_Encode,
FileFilter = FilterCriterias.ImgFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(76, uTexEncode);

ToolAction uTexDecode = new()
{
Name = "U-Texture - Decode",
Execute = ActionInvoker.UTex_Decode,
FileFilter = FilterCriterias.TexFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(77, uTexDecode);

ToolAction txzEncode = new()
{
Name = "TXZ Parser - Encode",
Execute = ActionInvoker.TXZ_Encode,
FileFilter = FilterCriterias.ImgFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(78, txzEncode);

ToolAction txzDecode = new()
{
Name = "TXZ Parser - Decode",
Execute = ActionInvoker.TXZ_Decode,
FileFilter = FilterCriterias.TxzFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(79, txzDecode);

ToolAction xnbEncode = new()
{
Name = "XNB Parser - Encode",
Execute = ActionInvoker.XNB_Encode,
FileFilter = FilterCriterias.ImgFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(80, xnbEncode);

ToolAction xnbDecode = new()
{
Name = "XNB Parser - Decode",
Execute = ActionInvoker.XNB_Decode,
FileFilter = FilterCriterias.XnbFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(81, xnbDecode);

ToolAction gxtEncode = new()
{
Name = "GXT Parser - Encode",
Execute = ActionInvoker.GXT_Encode,
AllowDirs = true
};

options.Add(82, gxtEncode);

ToolAction gxtDecode = new()
{
Name = "GXT Parser - Decode",
Execute = ActionInvoker.GXT_Decode,
FileFilter = FilterCriterias.GxtFilter,
AllowFiles = true,
};

options.Add(83, gxtDecode);

ToolAction ddsEncode = new()
{
Name = "DirectDraw Surface - Encode",
Execute = ActionInvoker.DDS_Encode,
FileFilter = FilterCriterias.ImgFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(84, ddsEncode);

ToolAction ddsDecode = new()
{
Name = "DirectDraw Surface - Decode",
Execute = ActionInvoker.DDS_Decode,
FileFilter = FilterCriterias.DdsFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(85, ddsDecode);

// TO-DO: Raw image (86, 87)


// ======== AnimTranscoder ========

// ReAnim, Particles, TrailFX, PopAnim, BBone

// ======== AudioTranscoder ========

// SoundBank, SexyWaves

// ======== AtlasBuilder ========

// CutImage, ImageDat, SimpleAtlas, AncientXml, OldXml, NewXml, TVAtlasXml, Plist, RtonRes (Cut/Splice)

// ======== SexyObj Utils ========

ToolAction sexyObjSort = new()
{
Name = "SexyObj Utils - Sort file",
Execute = ActionInvoker.SexyObj_Sort,
FileFilter = FilterCriterias.JsonFilter,
AllowFiles = true
};

options.Add(130, sexyObjSort);

ToolAction sexyObjCompare = new()
{
Name = "SexyObj Utils - Compare files",
Execute = ActionInvoker.SexyObj_Compare,
FileFilter = FilterCriterias.JsonFilter,
AllowFiles = true
};

options.Add(131, sexyObjCompare);

ToolAction sexyObjUpdate = new()
{
Name = "SexyObj Utils - Update file",
Execute = ActionInvoker.SexyObj_Update,
FileFilter = FilterCriterias.JsonFilter,
AllowFiles = true
};

options.Add(132, sexyObjUpdate);

ToolAction sexyObjSplit = new()
{
Name = "SexyObj Utils - Split file",
Execute = ActionInvoker.SexyObj_Split,
FileFilter = FilterCriterias.JsonFilter,
AllowFiles = true
};

options.Add(133, sexyObjSplit);

ToolAction sexyObjMerge = new()
{
Name = "SexyObj Utils - Merge files",
Execute = ActionInvoker.SexyObj_Merge,
AllowDirs = true
};

options.Add(134, sexyObjMerge);

// ======== Miscelaneous ========

ToolAction base64Encode = new()
{
Name = "Base64 Parser - Encode",
Execute = ActionInvoker.Base64_Encode,
FileFilter = FilterCriterias.DefaultFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(140, base64Encode);

ToolAction base64Decode = new()
{
Name = "Base64 Parser - Decode",
Execute = ActionInvoker.Base64_Decode,
FileFilter = FilterCriterias.BinFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(141, base64Decode);

ToolAction xorCrypt = new()
{
Name = "Xor Cryptor - Cipher file",
Execute = ActionInvoker.Xor_Cipher,
FileFilter = FilterCriterias.DefaultFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(142, xorCrypt);

ToolAction md5Hash = new()
{
Name = "MD5 Digest - Get file hash",
Execute = ActionInvoker.Md5_Digest,
FileFilter = FilterCriterias.DefaultFilter,
AllowFiles = true
};

options.Add(143, md5Hash);

ToolAction zipPack = new()
{
Name = "Zip Archive - Compress",
Execute = ActionInvoker.Zip_Compress,
FileFilter = FilterCriterias.ToZipFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(144, zipPack);

ToolAction zipUnpack = new()
{
Name = "Zip Archive - Extract",
Execute = ActionInvoker.Zip_Extract,
FileFilter = FilterCriterias.ZipFilter,
AllowFiles = true
};

options.Add(145, zipUnpack);

ToolAction dflCompress = new()
{
Name = "Stream Deflator - Compress",
Execute = ActionInvoker.Deflate_Compress,
FileFilter = FilterCriterias.DefaultFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(146, dflCompress);

ToolAction dflDecompress = new()
{
Name = "Stream Deflator - Decompress",
Execute = ActionInvoker.Deflate_Decompress,
FileFilter = FilterCriterias.DflFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(147, dflDecompress);

ToolAction gzCompress = new()
{
Name = "GZip Compressor - Compress",
Execute = ActionInvoker.GZip_Compress,
FileFilter = FilterCriterias.DefaultFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(148, gzCompress);

ToolAction gzDecompress = new()
{
Name = "GZip Compressor - Decompress",
Execute = ActionInvoker.GZip_Decompress,
FileFilter = FilterCriterias.GzFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(149, gzDecompress);

ToolAction zlCompress = new()
{
Name = "ZLib Compressor - Compress",
Execute = ActionInvoker.Zlib_Compress,
FileFilter = FilterCriterias.DefaultFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(150, zlCompress);

ToolAction zlDecompress = new()
{
Name = "ZLib Compressor - Decompress",
Execute = ActionInvoker.Zlib_Decompress,
FileFilter = FilterCriterias.ZlibFilter,
AllowFiles = true,
AllowDirs = true
};

options.Add(151, zlDecompress);
}

}

}