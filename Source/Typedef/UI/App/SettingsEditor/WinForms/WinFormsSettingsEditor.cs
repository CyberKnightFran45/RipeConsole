#if WINDOWS

using System.Windows.Forms;
using RipeLib;

namespace RipeConsole
{
// Settings editor via Win forms

internal sealed class WinFormsSettingsEditor : ISettingsEditor
{
// Show dialog

public bool Edit(RipeSettings settings)
{
ConsoleWriter.WriteInfo("Opening settings dialog...");

using SettingsForm form = new(settings);

return form.ShowDialog() == DialogResult.OK;
}

}

}

#endif