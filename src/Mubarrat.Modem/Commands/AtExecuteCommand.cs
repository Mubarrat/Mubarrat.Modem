namespace Mubarrat.Modem.Commands;

/// <summary>
/// This class represents a specific AT command for executing a command on the modem.
/// Inherits from the base AtCommand class.
/// </summary>
public class AtExecuteCommand : AtCommand
{
    /// <summary>
    /// Initializes a new instance of the AtExecuteCommand class.
    /// </summary>
    /// <param name="command">The raw AT command string for execution.</param>
    public AtExecuteCommand(string command) : base(command) { }
}
