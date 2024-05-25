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

    protected override string Suffix => "?";
}
