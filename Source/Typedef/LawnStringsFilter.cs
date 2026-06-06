using System;
using System.Collections.Generic;
using TextHandler.LawnStrings;

namespace RipeConsole
{
// LawnStrings filters

internal static class LawnStringsFilter
{
// Auto filters

private static readonly Dictionary<string, LawnStringsFormat> AutoFormats = new()
{

[".txt"] = LawnStringsFormat.PlainText

};

// Input filters

private static readonly Dictionary<string, Func<LawnStringsFormat, bool>> InputFilters = new()
{

[".json"] = IsJson,
[".rton"] = IsRton

};

// Output filters

private static readonly Dictionary<LawnStringsFormat, Func<LawnStringsFormat, bool>> OutputFilters = new()
{

[LawnStringsFormat.PlainText] = format => format == LawnStringsFormat.PlainText,
[LawnStringsFormat.JsonList] = format => format != LawnStringsFormat.JsonList,
[LawnStringsFormat.JsonMap] = format => format != LawnStringsFormat.JsonMap,
[LawnStringsFormat.RtonList] = format => format != LawnStringsFormat.RtonList,
[LawnStringsFormat.RtonMap] = format => format != LawnStringsFormat.RtonMap

};

// Check if format is json

private static bool IsJson(LawnStringsFormat format)
{
return format is LawnStringsFormat.JsonList or LawnStringsFormat.JsonMap;
}

// Check if format is rton

private static bool IsRton(LawnStringsFormat format)
{
return format is LawnStringsFormat.RtonList or LawnStringsFormat.RtonMap;
}

// Try get format from extension

public static bool TryGetFmtFromExtension(string ext, out LawnStringsFormat format)
{
ext = ext.ToLowerInvariant();

return AutoFormats.TryGetValue(ext, out format);
}

// Get input filter

public static Func<LawnStringsFormat, bool> GetInputFilter(string ext)
{
ext = ext.ToLowerInvariant();

return InputFilters.GetValueOrDefault(ext);
}

// Get output filter

public static Func<LawnStringsFormat, bool> GetOutputFilter(LawnStringsFormat inputFormat)
{
return OutputFilters.GetValueOrDefault(inputFormat);
}

}

}