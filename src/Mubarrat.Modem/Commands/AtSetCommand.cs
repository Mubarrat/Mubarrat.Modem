namespace Mubarrat.Modem.Commands;

/// <summary>
/// This class represents an AT command specifically used for setting values on the modem.
/// Inherits from the base AtCommand class.
/// </summary>
public class AtSetCommand : AtCommand
{
    /// <summary>
    /// Initializes a new instance of the AtSetCommand class with the specified command string and optional data.
    /// </summary>
    /// <param name="command">The raw AT command string for setting a value.</param>
    /// <param name="data">Optional data values to be set with the command (variable number of strings using params keyword).</param>
    public AtSetCommand(string command, params DataValue[] data) : base(command) => Data = data;

    /// <summary>
    /// Gets or sets the optional data values associated with the AT command for setting.
    /// </summary>
    public DataValue[] Data { get; set; }

    protected override string Suffix => $"={string.Join(",", (IEnumerable<DataValue>)Data)}";
}
