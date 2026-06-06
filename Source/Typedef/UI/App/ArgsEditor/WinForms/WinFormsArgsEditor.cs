#if WINDOWS

using System.Windows.Forms;
using RipeLib;

namespace RipeConsole
{
// Arguments editor via Win forms

internal sealed class WinFormsArgsEditor : IArgsEditor
{
// Show dialog

public bool Edit(RipeArgumentsSet args)
{
ConsoleWriter.WriteInfo("Opening arguments editor...");

using ArgsForm form = new(args);

return form.ShowDialog() == DialogResult.OK;
}

}

}

#endif