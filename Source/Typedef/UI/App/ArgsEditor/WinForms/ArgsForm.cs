#if WINDOWS

using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Compression;
using TextHandler.LawnStrings;
using TextureTranscoder.Parsers.PopCapTexture;
using TextureTranscoder.Parsers.RawImage;

namespace RipeConsole
{
// Arguments editor form

internal sealed class ArgsForm : Form
{
// Fields

private readonly RipeArgumentsSet _args;

private TextBox txtDownloadFolder;
private TextBox txtCipherKey;

private CheckBox chkBase64WebSafe;
private CheckBox chkUseNewPopRes;

private NumericUpDown numBZipBlockSize;

private ComboBox cmbCompression;
private ComboBox cmbEncoding;
private ComboBox cmbDiffCriteria;
private ComboBox cmbServer;
private ComboBox cmbPtxFormat;
private ComboBox cmbRawFormat;

private Button btnSave;
private Button btnCancel;

// ctor

public ArgsForm(RipeArgumentsSet args)
{
_args = args;

Text = "RIPE Arguments";
Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

ClientSize = new Size(620, 570);

FormBorderStyle = FormBorderStyle.FixedDialog;

MaximizeBox = false;

StartPosition = FormStartPosition.CenterScreen;

BackColor = Color.FromArgb(32, 34, 37);
ForeColor = Color.White;

Font = new Font("Segoe UI", 9f);

InitializeUI();

LoadValues();
}

// Browse folder

private void BrowseFolder()
{
using FolderBrowserDialog dirPicker = new(); 
dirPicker.InitialDirectory = PathHelper.GetDownloadsFolder();

if(dirPicker.ShowDialog() == DialogResult.OK)
txtDownloadFolder.Text = dirPicker.SelectedPath;

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

// Generate random key

private void GenRandomKey()
{
txtCipherKey.Text = InputHelper.GenRandomStr(32);
}

// Initialize UI

private void InitializeUI()
{
// ======== General ========

GroupBox grpGeneral = CreateGroup("General", 12, 10, 600, 75);

var lblDownloadFolder = CreateLabel("Download Folder", 15, 15);

txtDownloadFolder = CreateTextBox();
txtDownloadFolder.SetBounds(15, 35, 460, 28);

Button btnBrowse = CreateButton("...", false);

btnBrowse.SetBounds(485, 34, 100, 30);
btnBrowse.Click += (s, e) => BrowseFolder();

grpGeneral.Controls.Add(lblDownloadFolder);
grpGeneral.Controls.Add(txtDownloadFolder);
grpGeneral.Controls.Add(btnBrowse);

Controls.Add(grpGeneral);

// ======== Compression ========

GroupBox grpCompression = CreateGroup("Compression", 12, 90, 295, 110);

var lblCompressLvl = CreateLabel("Compression Level", 15, 15);

cmbCompression = CreateCombo();
cmbCompression.SetBounds(15, 35, 265, 28);

var lblBlockSize = CreateLabel("BZip Block Size", 15, 55);

numBZipBlockSize = new NumericUpDown()
{
Left = 15,
Top = 75,
Width = 100, 

Minimum = -1,
Maximum = 9,

BackColor = Color.FromArgb(58, 60, 64),
ForeColor = Color.White
};

grpCompression.Controls.Add(lblCompressLvl);
grpCompression.Controls.Add(cmbCompression);

grpCompression.Controls.Add(lblBlockSize);
grpCompression.Controls.Add(numBZipBlockSize);

Controls.Add(grpCompression);

// ======== Options ========

GroupBox grpFlags = CreateGroup("Options", 317, 90, 295, 110);

chkBase64WebSafe = CreateCheckBox("Use Base64 Web-safe");
chkBase64WebSafe.Top = 30;

chkUseNewPopRes = CreateCheckBox("Use New PopCap Res");
chkUseNewPopRes.Top = 65;

grpFlags.Controls.Add(chkBase64WebSafe);
grpFlags.Controls.Add(chkUseNewPopRes);

Controls.Add(grpFlags);

// ======== LawnStrings ========

GroupBox grpLawnStrings = CreateGroup("LawnStrings", 12, 205, 600, 85);

var lblEncoding = CreateLabel("Encoding", 15, 20);

cmbEncoding = CreateCombo();
cmbEncoding.SetBounds(15, 40, 180, 28);

var lblCompareMode = CreateLabel("Compare Mode", 210, 20);

cmbDiffCriteria = CreateCombo();
cmbDiffCriteria.SetBounds(210, 40, 180, 28);

var lblServerType = CreateLabel("Server Type", 405, 20);

cmbServer = CreateCombo();
cmbServer.SetBounds(405, 40, 180, 28);

grpLawnStrings.Controls.Add(lblEncoding);
grpLawnStrings.Controls.Add(cmbEncoding);

grpLawnStrings.Controls.Add(lblCompareMode);
grpLawnStrings.Controls.Add(cmbDiffCriteria);

grpLawnStrings.Controls.Add(lblServerType);
grpLawnStrings.Controls.Add(cmbServer);

Controls.Add(grpLawnStrings);

// ======== Textures ========

GroupBox grpTextures = CreateGroup("Textures", 12, 295, 600, 85);

var lblPtxFmt =  CreateLabel("PTX Format", 15, 20);

cmbPtxFormat = CreateCombo();
cmbPtxFormat.SetBounds(15, 40, 280, 28);

var lblRawFmt =  CreateLabel("Raw Format", 310, 20);

cmbRawFormat = CreateCombo();
cmbRawFormat.SetBounds(310, 40, 280, 28);

grpTextures.Controls.Add(lblPtxFmt);
grpTextures.Controls.Add(cmbPtxFormat);

grpTextures.Controls.Add(lblRawFmt);
grpTextures.Controls.Add(cmbRawFormat);

Controls.Add(grpTextures);

// ======== Security ========

GroupBox grpSecurity = CreateGroup("Security", 12, 385, 600, 75);

var lblKey = CreateLabel("Cipher Key", 15, 15);

txtCipherKey = CreateTextBox();
txtCipherKey.SetBounds(15, 35, 430, 28);

Button btnGen = CreateButton("?", false);

btnGen.SetBounds(455, 34, 50, 30);
btnGen.Click += (s, e) => GenRandomKey();

grpSecurity.Controls.Add(lblKey);
grpSecurity.Controls.Add(txtCipherKey);
grpSecurity.Controls.Add(btnGen);

Controls.Add(grpSecurity);

// ======== Buttons ========

btnSave = CreateButton("Save", true);

btnSave.SetBounds(380, 500, 110, 34);
btnSave.Click += (_, _) => SaveAndExit();

btnCancel = CreateButton("Cancel", false);

btnCancel.SetBounds(500, 500, 110, 34);
btnCancel.BackColor = Color.FromArgb(200, 50, 50);
btnCancel.Click += (_, _) => Exit();

Controls.Add(btnSave);
Controls.Add(btnCancel);
}

// Create group box

private GroupBox CreateGroup(string text, int x, int y, int w, int h) => new()
{ 
Text = text,

Left = x,
Top = y,
Width = w,
Height = h,

ForeColor = Color.White
};

// Create label

private static Label CreateLabel(string text, int x, int y) => new()
{
Text = text,
AutoSize = true,

Left = x,
Top = y,

ForeColor = Color.DodgerBlue
};

// Create text box

private TextBox CreateTextBox() => new()
{
BackColor = Color.FromArgb(58, 60, 64),
ForeColor = Color.White,

BorderStyle = BorderStyle.FixedSingle
};

// Create combo box

private ComboBox CreateCombo() => new()
{
DropDownStyle = ComboBoxStyle.DropDownList,

BackColor = Color.FromArgb(58, 60, 64),
ForeColor = Color.White
};

// Create check box

private CheckBox CreateCheckBox(string text) => new()
{
Text = text,

Left = 15,
Width = 220,

ForeColor = Color.White,
BackColor = Color.Transparent
};

// Create button

private Button CreateButton(string text, bool primary) => new()
{
Text = text,
FlatStyle = FlatStyle.Flat,

BackColor = primary ? Color.FromArgb(88, 101, 242) : Color.FromArgb(55, 57, 60),
ForeColor = Color.White
};

// Load values

private void LoadValues()
{
cmbCompression.DataSource = Enum.GetValues<CompressionLevel>();
cmbEncoding.DataSource = Enum.GetValues<LawnStringsEncoding>();

cmbDiffCriteria.DataSource = Enum.GetValues<LawnStringsCompareMode>();
cmbServer.DataSource = Enum.GetValues<LawnStringsServerType>();

cmbPtxFormat.DataSource = Enum.GetValues<PtxFormat>();
cmbRawFormat.DataSource = Enum.GetValues<RawImgFormat>();

txtDownloadFolder.Text = _args.DownloadFolder;

txtCipherKey.Text = _args.CipherKey;
chkBase64WebSafe.Checked = _args.UseBase64WebSafe;

chkUseNewPopRes.Checked = _args.UseNewPopRes;

numBZipBlockSize.Value = _args.BZipBlockSize;
cmbCompression.SelectedItem = _args.StreamCompressionLevel;

cmbEncoding.SelectedItem = _args.LawnStringsInEncoding;
cmbDiffCriteria.SelectedItem = _args.LawnStringsDiffCriteria;
cmbServer.SelectedItem = _args.LawnStringsServer;

cmbPtxFormat.SelectedItem = _args.PtxFormat_Mobile;
cmbRawFormat.SelectedItem = _args.RawTextureFmt;
}

// Save values

private void SaveValues()
{
_args.DownloadFolder = txtDownloadFolder.Text;
_args.CipherKey = txtCipherKey.Text;

_args.UseBase64WebSafe = chkBase64WebSafe.Checked;
_args.UseNewPopRes = chkUseNewPopRes.Checked;

_args.BZipBlockSize = (int)numBZipBlockSize.Value;

if(cmbCompression.SelectedItem != null)
_args.StreamCompressionLevel = (CompressionLevel)cmbCompression.SelectedItem;

if(cmbEncoding.SelectedItem != null)
_args.LawnStringsInEncoding = (LawnStringsEncoding)cmbEncoding.SelectedItem;

if(cmbDiffCriteria.SelectedItem != null)
_args.LawnStringsDiffCriteria = (LawnStringsCompareMode)cmbDiffCriteria.SelectedItem;

if(cmbServer.SelectedItem != null)
_args.LawnStringsServer = (LawnStringsServerType)cmbServer.SelectedItem;

if(cmbPtxFormat.SelectedItem != null)
_args.PtxFormat_Mobile = (PtxFormat)cmbPtxFormat.SelectedItem;

if(cmbRawFormat.SelectedItem != null)
_args.RawTextureFmt = (RawImgFormat)cmbRawFormat.SelectedItem;

}

}

}

#endif