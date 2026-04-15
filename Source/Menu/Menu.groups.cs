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

MenuCategory defaultCategory = new()
{
Name = "Exit",
Options = [ 0 ]
};

categories.Add(0, defaultCategory);

MenuCategory sexyParsers = new()
{
Name = "Sexy Parsers",
Options = [ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 ]
};

categories.Add(1, sexyParsers);

MenuCategory sexyCryptors = new()
{
Name = "Sexy Cryptors",
Options = [ 20, 21, 22, 23, 24, 25 ]
};

categories.Add(2, sexyCryptors);

MenuCategory sexyCompressor = new()
{
Name = "Sexy Compressor",
Options = [ 30, 31, 32, 33, 34 ]
};

categories.Add(3, sexyCompressor);

MenuCategory sexyPackages = new()
{
Name = "Packages Handler",
Options = [ 40, 41, 44, 45, 46, 47, 50, 51 ] // Missing: 42, 43, 48, 49
};

categories.Add(4, sexyPackages);

MenuCategory resMgr = new()
{
Name = "PopCap Resource Manager",
Options = [ 60, 61, 62, 63 ]
};

categories.Add(5, resMgr);

MenuCategory textureParser = new()
{
Name = "Texture Transcoder",
Options = [ 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85 ] // Missing: 86-87
};

categories.Add(6, textureParser);

MenuCategory sexyObjMgr = new()
{
Name = "SexyObj Utils",
Options = [ 130, 131, 132, 133, 134 ]
};

categories.Add(10, sexyObjMgr);

MenuCategory misc = new()
{
Name = "Miscelaneous",
Options = [ 140, 141, 142, 143, 144, 145, 146, 147, 148, 149, 150, 151 ]
};

categories.Add(11, misc);

/** ========  TO-DO  ==========

MenuCategory animParser = new()
{
Name = "Anim Transcoder",
Options = [] // To add: 90-100
};

categories.Add(7, animParser);

MenuCategory audioParser = new()
{
Name = "Audio Transcoder",
Options = [] // To add: 110-114
};

categories.Add(8, audioParser);

MenuCategory atlasBuilder = new()
{
Name = "Atlas Builder",
Options = [] // To add: 120-138
};

categories.Add(9, atlasBuilder); 

**/

}

}

}