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

    /// <summary>
    /// Creates a new instance of <see cref="AtCommand"/> by given <paramref name="atCommandType"/>
    /// </summary>
    /// <param name="atCommandType">The type of the <see cref="AtCommand"/>.</param>
    /// <param name="command">The command of the <see cref="AtCommand"/></param>
    /// <param name="parameters">If you set <paramref name="atCommandType"/> = <see cref="AtCommandType.Set"/>, it will be defined. Otherwise ignored.</param>
    /// <returns>Returns the new instance of <see cref="AtCommand"/> that was created.</returns>
    /// <exception cref="ArgumentException">Thrown if <paramref name="atCommandType"/> isn't valid.</exception>
    public static AtCommand CreateInstance(AtCommandType atCommandType, string command, params DataValue[] parameters)
    {
        return atCommandType switch
        {
            AtCommandType.Test => new AtTestCommand(command),
            AtCommandType.Read => new AtReadCommand(command),
            AtCommandType.Set => new AtSetCommand(command, parameters),
            AtCommandType.Execute => new AtExecuteCommand(command),
            _ => throw new ArgumentException("Invalid enum given", nameof(atCommandType)),
        };
    }
}
