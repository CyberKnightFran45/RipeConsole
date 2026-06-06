#if WINDOWS

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace RipeConsole
{
// Native windows notification

public static class NotificationHelper
{
// Path to png icon
	
private static readonly string TempIconPath = Path.Combine(Path.GetTempPath(), "ripe_icon.png");

// Save .ico to temp .png

private static void ExtractIconToPng()
{
using var icon = Icon.ExtractAssociatedIcon(Environment.ProcessPath);
var bitmap = icon?.ToBitmap();

bitmap.Save(TempIconPath, ImageFormat.Png);
}

// Get PowerShell command

private static string BuildCommand(string title, string message)
{

string script = $@"
        $iconPath = '{TempIconPath}';
        [Windows.UI.Notifications.ToastNotificationManager, Windows.UI.Notifications, ContentType = WindowsRuntime] > $null;
        $template = [Windows.UI.Notifications.ToastNotificationManager]::GetTemplateContent([Windows.UI.Notifications.ToastTemplateType]::ToastImageAndText02);
        $rawXml = [xml]$template.GetXml();
        
        
        ($rawXml.toast.visual.binding.text | Where-Object {{$_.id -eq '1'}}).AppendChild($rawXml.CreateTextNode('{title}')) > $null;
        ($rawXml.toast.visual.binding.text | Where-Object {{$_.id -eq '2'}}).AppendChild($rawXml.CreateTextNode('{message}')) > $null;

        $imageNode = $rawXml.CreateElement('image');
        $imageNode.SetAttribute('id', '1');
        $imageNode.SetAttribute('src', $iconPath);
        $rawXml.toast.visual.binding.PrependChild($imageNode) > $null;
        
        $xmlDocument = New-Object Windows.Data.Xml.Dom.XmlDocument;
        $xmlDocument.LoadXml($rawXml.OuterXml);
        $toast = [Windows.UI.Notifications.ToastNotification]::new($xmlDocument);
        [Windows.UI.Notifications.ToastNotificationManager]::CreateToastNotifier('RIPE').Show($toast);";

return "-NoProfile -Command \"" + script + "\"";
}

// Show notification

public static void ShowToast(string title, string message)
{
ExtractIconToPng();

string command = BuildCommand(title, message);

ProcessHelper.StartNew("powershell", command, false, false, true);
}

}

}

#endif