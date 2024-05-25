namespace Mubarrat.Modem.Commands;

/// <summary>
/// This abstract class represents a generic AT command for interacting with cellular modems.
/// </summary>
public abstract class AtCommand : IAtCommand
{
    /// <summary>
    /// Gets or sets the raw AT command string.
    /// </summary>
    public string Command { get; set; }

    /// <summary>
    /// Gets the suffix appended to the base AT command string. This property is abstract and requires concrete implementation by subclasses.
    /// </summary>
    protected abstract string Suffix { get; }

    /// <summary>
    /// Initializes a new instance of the AtCommand class with the specified command string.
    /// </summary>
    /// <param name="command">The raw AT command string.</param>
    public AtCommand(string command) => Command = command;

    /// <summary>
    /// Overrides the ToString() method to return the complete AT command string prefixed with "AT".
    /// </summary>
    /// <returns>The complete AT command string.</returns>
    public override string ToString() => $"AT{WithoutPrefixString}";

    /// <summary>
    /// Similar to the ToString() method but returns the incomplete AT command string no prefixed.
    /// </summary>
    public string WithoutPrefixString => $"{Command}{Suffix}";
}
