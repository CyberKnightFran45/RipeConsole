using System.Collections.Generic;
using RipeLib;

namespace RipeConsole
{
// Program menu (logic)

internal static partial class Menu
{
// Menu options

private static Dictionary<int, ToolAction> options;

// Menu categories

private static Dictionary<int, MenuCategory> categories;

// Init

static Menu()
{
InitOptions();

InitCategories();
}

// Display

public static ToolAction Display(string path, int? choice = null)
{
string mainTitle = "RIPE - Main Menu";
string quickMenu = "RIPE - Fast Menu";

return BaseMenu.Display(mainTitle, quickMenu, path, options, categories, choice);
}

// Check function

public static bool FunctionExists(int src) => options.ContainsKey(src);
}

}