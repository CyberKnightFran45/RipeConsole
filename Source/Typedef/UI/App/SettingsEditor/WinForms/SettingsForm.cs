#if WINDOWS

using System;
using System.Drawing;
using System.Windows.Forms;

namespace RipeConsole
{
// Settings editor form

internal sealed class SettingsForm : Form
{
// Fields

private readonly RipeSettings _settings;

private CheckBox chkShowWelcome;
private CheckBox chkGenerateOutput;
private CheckBox chkAutoFill;
private CheckBox chkUseNativePicker;
private CheckBox chkShowExit;
private CheckBox chkDebug;
private CheckBox chkDisplayArgs;
private CheckBox chkUseGuiSettings;
private CheckBox chkUseGuiArgsEditor;
private CheckBox chkShowExecutionTime;

private ComboBox cmbNotifyCompletion;
private ComboBox cmbLogLevel;
private ComboBox cmbExitAction;

private Button btnSave;
private Button btnCancel;

// ctor

public SettingsForm(RipeSettings settings)
{
_settings = settings;

Text = "RIPE Settings";
Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

ClientSize = new Size(460, 620);

FormBorderStyle = FormBorderStyle.FixedDialog;

MaximizeBox = false;
MinimizeBox = false;

StartPosition = FormStartPosition.CenterScreen;

BackColor = Color.FromArgb(32, 34, 37);
ForeColor = Color.White;

Font = new Font("Segoe UI", 9f);

InitializeUI();

LoadValues();
}

// Save and exit event

private void SaveAndExit()
{
SaveValues();

DialogResult = DialogResult.OK;
Close();
}

// Exit event

private void Exit()
{
DialogResult = DialogResult.Cancel;

Close();
}

// Initialize UI

private void InitializeUI()
{

Label lblInfo = new()
{
Text = "Customize console behavior and runtime options",
ForeColor = Color.Gold,

AutoSize = true,

Left = 18,
Top = 18
};

Controls.Add(lblInfo);

FlowLayoutPanel panel = new()
{
Left = 12,
Top = 40,
Width = 420,
Height = 410,

FlowDirection = FlowDirection.TopDown,

WrapContents = false,
AutoScroll = true,

BackColor = BackColor
};

// ======== Toggles ========

chkShowWelcome = CreateCheckBox("Show welcome screen");
chkGenerateOutput = CreateCheckBox("Generate output paths");

chkAutoFill = CreateCheckBox("Auto-fill arguments");
chkUseNativePicker = CreateCheckBox("Use native file picker");

chkShowExit = CreateCheckBox("Show exit option");
chkDebug = CreateCheckBox("Enable debug information");

chkDisplayArgs = CreateCheckBox("Display parsed arguments");
chkUseGuiSettings = CreateCheckBox("Use GUI settings editor");

chkUseGuiArgsEditor = CreateCheckBox("Use GUI arguments editor");
chkShowExecutionTime = CreateCheckBox("Show task execution time");

panel.Controls.Add(chkShowWelcome);
panel.Controls.Add(chkGenerateOutput);
panel.Controls.Add(chkAutoFill);
panel.Controls.Add(chkUseNativePicker);
panel.Controls.Add(chkShowExit);
panel.Controls.Add(chkDebug);
panel.Controls.Add(chkDisplayArgs);
panel.Controls.Add(chkUseGuiSettings);
panel.Controls.Add(chkUseGuiArgsEditor);
panel.Controls.Add(chkShowExecutionTime);

Controls.Add(panel);

// ======== Selectors ========

Label lblNotify = CreateLabel("Notify Completion");

lblNotify.Top = 460;
lblNotify.Left = 20;

cmbNotifyCompletion = CreateCombo();

cmbNotifyCompletion.Top = 482;
cmbNotifyCompletion.Left = 20;

Label lblLogLevel = CreateLabel("Log level");

lblLogLevel.Top = 460;
lblLogLevel.Left = 220;

cmbLogLevel = CreateCombo();

cmbLogLevel.Top = 482;
cmbLogLevel.Left = 220;

Label lblExitAction = CreateLabel("Exit action");

lblExitAction.Top = 510;
lblExitAction.Left = 20;

cmbExitAction = CreateCombo();

cmbExitAction.Top = 532;
cmbExitAction.Left = 20;

Controls.Add(lblNotify);
Controls.Add(cmbNotifyCompletion);

Controls.Add(lblLogLevel);
Controls.Add(cmbLogLevel);

Controls.Add(lblExitAction);
Controls.Add(cmbExitAction);

// ======== Buttons ========

btnSave = CreateButton("Save", true);

btnSave.Left = 90;
btnSave.Top = 570;
btnSave.Click += (_, _) => SaveAndExit();

btnCancel = CreateButton("Cancel", false);

btnCancel.Left = 220;
btnCancel.Top = 570;
btnCancel.BackColor = Color.FromArgb(200, 50, 50);
btnCancel.Click += (_, _) => Exit();

Controls.Add(btnSave);
Controls.Add(btnCancel);
}

// Create check box

private CheckBox CreateCheckBox(string text) => new()
{
Text = text,

Width = 360,
Height = 24,

AutoSize = false,

Margin = new Padding(4, 6, 4, 6),
FlatStyle = FlatStyle.Standard,

ForeColor = Color.White,
BackColor = BackColor
};

// Create combo box

private static ComboBox CreateCombo() => new()
{
Width = 180,
Height = 28,

DropDownStyle = ComboBoxStyle.DropDownList,
FlatStyle = FlatStyle.Flat,

BackColor = Color.FromArgb(58, 60, 64),
ForeColor = Color.White
};

// Create label

private static Label CreateLabel(string text) => new()
{
Text = text,
AutoSize = true,

ForeColor = Color.Gainsboro
};

// Create button

private static Button CreateButton(string text, bool primary) => new()
{
Text = text,

Width = 110,
Height = 34,

FlatStyle = FlatStyle.Flat,

BackColor = primary ? Color.FromArgb(88, 101, 242) : Color.FromArgb(55, 57, 60),
ForeColor = Color.White
};

// Load values

private void LoadValues()
{
cmbNotifyCompletion.DataSource = Enum.GetValues<NotificationMode>();
cmbLogLevel.DataSource = Enum.GetValues<LoggerLevel>();
cmbExitAction.DataSource = Enum.GetValues<ProgramExitAction>();

chkShowWelcome.Checked = _settings.ShowWelcomeScreen;
chkGenerateOutput.Checked = _settings.GenerateOutputPaths;

chkAutoFill.Checked = _settings.AutoFillArgs;
chkUseNativePicker.Checked = _settings.UseNativeFilePicker;

chkShowExit.Checked = _settings.ShowExitOption;
chkDebug.Checked = _settings.ShowDebugInfo;

chkDisplayArgs.Checked = _settings.DisplayArgs;

chkUseGuiSettings.Checked = _settings.UseGuiSettings;
chkUseGuiArgsEditor.Checked = _settings.UseGuiArgsEditor;

chkShowExecutionTime.Checked = _settings.ShowExecutionTime;

cmbNotifyCompletion.SelectedItem = _settings.NotifyTaskCompletion;
cmbLogLevel.SelectedItem = _settings.LogLevel;
cmbExitAction.SelectedItem = _settings.ExitAction;
}

// Save values

private void SaveValues()
{
_settings.ShowWelcomeScreen = chkShowWelcome.Checked;
_settings.GenerateOutputPaths = chkGenerateOutput.Checked;

_settings.AutoFillArgs = chkAutoFill.Checked;
_settings.UseNativeFilePicker = chkUseNativePicker.Checked;

_settings.ShowExitOption = chkShowExit.Checked;
_settings.ShowDebugInfo = chkDebug.Checked;

_settings.DisplayArgs = chkDisplayArgs.Checked;

_settings.UseGuiSettings = chkUseGuiSettings.Checked;
_settings.UseGuiArgsEditor = chkUseGuiArgsEditor.Checked;

_settings.ShowExecutionTime = chkShowExecutionTime.Checked;

if(cmbNotifyCompletion.SelectedItem != null)
_settings.NotifyTaskCompletion = (NotificationMode)cmbNotifyCompletion.SelectedItem;

if(cmbLogLevel.SelectedItem != null)
_settings.LogLevel = (LoggerLevel)cmbLogLevel.SelectedItem;
 
if(cmbExitAction.SelectedItem != null)
_settings.ExitAction = (ProgramExitAction)cmbExitAction.SelectedItem;

}

}

}

#endif