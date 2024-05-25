namespace Mubarrat.Modem.Commands;

/// <summary>
/// This abstract class represents a generic AT command for interacting with cellular modems.
/// </summary>
public abstract class AtCommand : IAtCommand
{
    public string Command { get; set; }

    /// <summary>
    /// Initializes a new instance of the AtCommand class with the specified command string.
    /// </summary>
    /// <param name="command">The raw AT command string.</param>
    public AtCommand(string command) => Command = command;

    /// <summary>
    /// Overrides the ToString() method to return the complete AT command string prefixed with "AT".
    /// </summary>
    /// <returns>The complete AT command string.</returns>
    public override string ToString() => $"AT{Command}";
}
