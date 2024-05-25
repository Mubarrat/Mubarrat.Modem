namespace Mubarrat.Modem.Commands;

/// <summary>
/// This class represents an AT command specifically used for reading data from the modem.
/// Inherits from the base AtCommand class.
/// </summary>
public class AtReadCommand : AtCommand
{
    /// <summary>
    /// Initializes a new instance of the AtReadCommand class with the specified command string.
    /// </summary>
    /// <param name="command">The raw AT command string for reading data.</param>
    public AtReadCommand(string command) : base(command) { }

    /// <summary>
    /// Overrides the ToString() method to return the complete AT command string with a trailing question mark (?),
    /// indicating that the command is intended for reading data.
    /// </summary>
    /// <returns>The complete AT command string with a trailing question mark.</returns>
    public override string ToString() => $"{base.ToString()}?";
}
