using System.IO.Compression;
using System.Text.Json.Serialization;
using TextHandler.LawnStrings;
using TextureTranscoder.Parsers.PopCapTexture;
using TextureTranscoder.Parsers.RawImage;

namespace RipeConsole
{
/// <summary> Arguments Set for RIPE Console </summary>

public sealed class RipeArgumentsSet
{
/// <summary> Path to Downloads Folder </summary>

public string DownloadFolder{ get; set; }

/// <summary> Wheter to use Base64 Web-safe instead of standar </summary>

public bool UseBase64WebSafe{ get; set; }

/// <summary> Stream Compression Level </summary>

public CompressionLevel StreamCompressionLevel{ get; set; }

/// <summary> BZip2 Block Size (-1 to 9) </summary>

public int BZipBlockSize{ get; set; }

/// <summary> Wheter to use New PopCap ResGroup </summary>

public bool UseNewPopRes{ get; set; }

/// <summary> Default LawnStrings encoding </summary>

public LawnStringsEncoding LawnStringsInEncoding{ get; set; }

/// <summary> Default LawnStrings Compare Mode </summary>

public LawnStringsCompareMode LawnStringsDiffCriteria{ get; set; }

/// <summary> Default LawnStrings Server </summary>

public LawnStringsServerType LawnStringsServer{ get; set; }

/// <summary> PTX Format (Mobile) </summary>

public PtxFormat PtxFormat_Mobile{ get; set; }

/// <summary> Raw Texture Format </summary>

public RawImgFormat RawTextureFmt{ get; set; }

/// <summary> Cipher Key (for XOR) </summary>

public string CipherKey{ get; set; }

// ctor

public RipeArgumentsSet()
{
DownloadFolder = PathHelper.GetDownloadsFolder();

UseBase64WebSafe = false;

StreamCompressionLevel = CompressionLevel.Optimal;
BZipBlockSize = -1;

UseNewPopRes = true;

LawnStringsInEncoding = LawnStringsEncoding.UTF8_BOM;
LawnStringsDiffCriteria = LawnStringsCompareMode.Added;
LawnStringsServer = LawnStringsServerType.Release;

PtxFormat_Mobile = PtxFormat.RGBA8888;
RawTextureFmt = RawImgFormat.RGBA_ASTC_HDR;

CipherKey = "RIPE";
}

// clone

public RipeArgumentsSet(RipeArgumentsSet other)
{
DownloadFolder = other.DownloadFolder;

UseBase64WebSafe = other.UseBase64WebSafe;

StreamCompressionLevel = other.StreamCompressionLevel;
BZipBlockSize = other.BZipBlockSize;

UseNewPopRes = other.UseNewPopRes;

LawnStringsInEncoding = other.LawnStringsInEncoding;
LawnStringsDiffCriteria = other.LawnStringsDiffCriteria;
LawnStringsServer = other.LawnStringsServer;

PtxFormat_Mobile = other.PtxFormat_Mobile;
RawTextureFmt = other.RawTextureFmt;

CipherKey = other.CipherKey;
}

public static readonly RipeArgsContext Context = new(JsonSerializer.Options);
}

// Json serializer context

[JsonSerializable(typeof(RipeArgumentsSet) ) ]
    
public sealed partial class RipeArgsContext : JsonSerializerContext
{
}

}