namespace Mubarrat.Modem.Commands;

/// <summary>
/// This class represents a specific AT command potentially used for testing functionality on the modem.
/// Inherits from the base AtCommand class.
/// 
/// **Note:** The exact behavior of this class depends on the specific modem implementation 
/// and the AT command set it supports. 
/// </summary>
public class AtTestCommand : AtCommand
{
    /// <summary>
    /// Initializes a new instance of the AtTestCommand class with the specified command string.
    /// </summary>
    /// <param name="command">The raw AT command string for testing.</param>
    public AtTestCommand(string command) : base(command) { }

    /// <summary>
    /// Overrides the ToString() method to return the complete AT command string with a trailing question mark (?),
    /// potentially indicating a test or query operation.
    /// </summary>
    /// <returns>The complete AT command string with a trailing question mark.</returns>
    public override string ToString() => $"AT{Command}=?";
}
