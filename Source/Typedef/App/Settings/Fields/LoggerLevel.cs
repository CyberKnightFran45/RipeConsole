namespace RipeConsole
{
/// <summary> Modes for Trace Logger </summary>

public enum LoggerLevel
{
/// <summary> Disable Logs </summary>
Disabled = 0,

/// <summary> Enable Logger and Save files </summary>
Full = 1,

/// <summary> Redirect Logger to Console, without saving to Disk </summary>
ViewOnly = 2,

/// <summary> Only Log Exceptions </summary>
ErrorsOnly = 3
}

}