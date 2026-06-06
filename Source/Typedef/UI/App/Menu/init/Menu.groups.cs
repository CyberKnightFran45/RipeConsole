using RipeLib;

namespace RipeConsole
{
// Category loader

internal static partial class Menu
{
// Init options

private static void InitCategories()
{
categories = new();

MenuCategory manual = new()
{
Name = "Help",
Options = [ -1 ]
};

categories.Add(-1, manual);

MenuCategory defaultCategory = new()
{
Name = "Exit",
Options = [ 0 ]
};

if(SettingsManager.Current.ShowExitOption)
categories.Add(0, defaultCategory);

MenuCategory txtHandler = new()
{
Name = "Text Handler",
Options = [ 1, 2, 3, 4, 5, 6, 7, 8, 9 ]
};

categories.Add(1, txtHandler);

MenuCategory sexyParsers = new()
{
Name = "Sexy Parsers",
Options = [ 10, 11, 12, 13, 14, 15, 16, 17, 18 ]
};

categories.Add(2, sexyParsers);

MenuCategory sexyCryptors = new()
{
Name = "Sexy Cryptors",
Options = [ 20, 21, 22, 23, 24, 25 ]
};

categories.Add(3, sexyCryptors);

MenuCategory sexyCompressor = new()
{
Name = "Sexy Compressor",
Options = [ 30, 31, 32, 33, 34 ]
};

categories.Add(4, sexyCompressor);

MenuCategory sexyPackages = new()
{
Name = "Packages Handler",
Options = [ 40, 41, 44, 45, 46, 47, 49, 50, 51 ] // Missing: 42, 43, 48
};

categories.Add(5, sexyPackages);

MenuCategory resMgr = new()
{
Name = "PopCap Resource Manager",
Options = [ 60, 61, 62, 63 ]
};

categories.Add(6, resMgr);

MenuCategory textureParser = new()
{
Name = "Texture Transcoder",
Options = [ 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87 ]
};

categories.Add(7, textureParser);

MenuCategory sexyObjMgr = new()
{
Name = "SexyObj Utils",
Options = [ 130, 131, 132, 133, 134 ]
};

categories.Add(11, sexyObjMgr);

MenuCategory compressor = new()
{
Name = "Stream Compressor",
Options = [ 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151, 152, 153 ]
};

categories.Add(12, compressor);

MenuCategory misc = new()
{
Name = "Miscelaneous",
Options = [ 160, 161, 162, 163, 164, 165 ]
};

categories.Add(13, misc);

MenuCategory control = new()
{
Name = "RIPE: Hub",
Options = [ 170, 171, 172, 173, 174, 175, 176, 177 ]
};

categories.Add(14, control);

/** ========  TO-DO  ==========

MenuCategory animParser = new()
{
Name = "Anim Transcoder",
Options = [] // To add: 90-100
};

categories.Add(8, animParser);

MenuCategory audioParser = new()
{
Name = "Audio Transcoder",
Options = [] // To add: 110-114
};

categories.Add(9, audioParser);

MenuCategory atlasBuilder = new()
{
Name = "Atlas Builder",
Options = [] // To add: 120-138
};

categories.Add(10, atlasBuilder); 

**/

}

}

}