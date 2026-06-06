namespace RipeConsole
{
/// <summary> Action on Program Termination </summary>

public enum ProgramExitAction
{
/// <summary> Close program </summary>
Exit = 0,

/// <summary> Return to Main menu </summary>
Return = 1,

/// <summary> Always ask user to close program or to return to Main menu </summary>
Ask = 2
}

}