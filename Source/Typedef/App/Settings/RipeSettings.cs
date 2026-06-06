using System.Text.Json.Serialization;

namespace RipeConsole
{
/// <summary> Settings for RIPE Console </summary>

public sealed class RipeSettings
{
/// <summary> Show Welcome screen on Startup </summary>

public bool ShowWelcomeScreen{ get; set; }

/// <summary> Debug level for Logger </summary>

public LoggerLevel LogLevel{ get; set; }

/// <summary> Action on Program termination </summary>

public ProgramExitAction ExitAction{ get; set; }

/// <summary> Wether to Generate Output Paths automatically </summary>

public bool GenerateOutputPaths{ get; set; }

/// <summary> Wether to fill Arguments automatically </summary>

public bool AutoFillArgs{ get; set; }

/// <summary> <b>WINDOWS ONLY:</b> uses Native file picker instead of Console prompt </summary>

public bool UseNativeFilePicker{ get; set; }

/// <summary> Enable exit Option in Menu </summary>

public bool ShowExitOption{ get; set; }

/// <summary> Show runtime info on Startup </summary>

public bool ShowDebugInfo{ get; set; }

/// <summary> Display arguments passed to Program </summary>

public bool DisplayArgs{ get; set; }

/// <summary> <b>WINDOWS ONLY:</b> render Settings in a UI </summary>

public bool UseGuiSettings{ get; set; }

/// <summary> <b>WINDOWS ONLY:</b> render Arguments editor in a UI </summary>

public bool UseGuiArgsEditor{ get; set; }

/// <summary> <b>WINDOWS ONLY:</b> notify when a Task finishes </summary>

public NotificationMode NotifyTaskCompletion{ get; set; }

/// <summary> Display task execution time </summary>

public bool ShowExecutionTime{ get; set; }

// ctor

public RipeSettings()
{
ShowWelcomeScreen = true;
LogLevel = LoggerLevel.Full;

ExitAction = ProgramExitAction.Ask;
GenerateOutputPaths = true;

ShowExitOption = true;
DisplayArgs = true;

ShowExecutionTime = true;
}

// clone

public RipeSettings(RipeSettings other)
{
ShowWelcomeScreen = other.ShowWelcomeScreen;
LogLevel = other.LogLevel;

ExitAction = other.ExitAction;
GenerateOutputPaths = other.GenerateOutputPaths;

AutoFillArgs = other.AutoFillArgs;
UseNativeFilePicker = other.UseNativeFilePicker;

ShowExitOption = other.ShowExitOption;
ShowDebugInfo = other.ShowDebugInfo;

DisplayArgs = other.DisplayArgs;
UseGuiSettings = other.UseGuiSettings;

UseGuiArgsEditor = other.UseGuiArgsEditor;
NotifyTaskCompletion = other.NotifyTaskCompletion;

ShowExecutionTime = other.ShowExecutionTime;
}

public static readonly RipeSettingsContext Context = new(JsonSerializer.Options);
}

// Json serializer context

[JsonSerializable(typeof(RipeSettings) ) ]
    
public sealed partial class RipeSettingsContext : JsonSerializerContext
{
}

}