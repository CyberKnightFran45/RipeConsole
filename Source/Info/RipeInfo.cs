using System.Linq;
using System.Reflection;

namespace RipeConsole
{
// Retrives info about this Assembly

internal static class RipeInfo
{
// Current assembly

private static readonly Assembly appAssembly = Assembly.GetExecutingAssembly();

// Get metadata attribute

private static string GetMetadataAttribute(string fieldName)
{
var metadata = appAssembly.GetCustomAttributes<AssemblyMetadataAttribute>();

return metadata.FirstOrDefault(x => x.Key == fieldName)?.Value ?? "<none>";
}

// Get program version

public static string GetVersion()
{
return appAssembly.GetName().Version?.ToString() ?? "1.0.0.0";
}

// Get build version

public static string GetBuildVersion()
{
return appAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion;
}

// Get app title

public static string GetTitle()
{
return appAssembly.GetCustomAttribute<AssemblyTitleAttribute>()?.Title ?? "<Missing Title>";
}

// Get app description

public static string GetDescription()
{
return appAssembly.GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description ?? "<Missing Description>";
}

// Get company name

public static string GetCompany()
{
return appAssembly.GetCustomAttribute<AssemblyCompanyAttribute>()?.Company ?? "<Missing CompanyName>";
}

// Get product name

public static string GetProduct()
{
return appAssembly.GetCustomAttribute<AssemblyProductAttribute>()?.Product ?? "<Missing ProductName>";
}

// Get copyright text

public static string GetCopyright()
{
return appAssembly.GetCustomAttribute<AssemblyCopyrightAttribute>()?.Copyright ?? "<Missing Copyright>";
}

// Get App type

public static string GetAppType() => GetMetadataAttribute("AppType");

// Get Author name

public static string GetAuthorName() => GetMetadataAttribute("Authors");

// Get License

public static string GetLicense() => GetMetadataAttribute("License");

// Get Package ID

public static string GetPackageId() => GetMetadataAttribute("PackageId");

// Get Build date

public static string GetBuildDate() => GetMetadataAttribute("BuildDate");

// Get configuration

public static string GetConfiguration() => GetMetadataAttribute("Configuration");

// Check if build is debug or release

public static bool IsDebug()
{

#if DEBUG
return true;

#else
return false;

#endif
}

}

}