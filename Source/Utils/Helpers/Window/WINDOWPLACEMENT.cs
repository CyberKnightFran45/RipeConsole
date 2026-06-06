#if WINDOWS

using System.Drawing;

namespace RipeConsole
{
// Window Placement

internal struct WINDOWPLACEMENT
{
public int length;

public int flags;

public int showCmd;

public Point ptMinPosition;

public Point ptMaxPosition;

public Rectangle rcNormalPosition;
}

}

#endif