namespace Mubarrat.Modem.Commands;

/// <summary>
/// This class represents an AT command specifically used for setting values on the modem.
/// Inherits from the base AtCommand class.
/// </summary>
public class AtSetCommand : AtCommand
{
    /// <summary>
    /// Initializes a new instance of the AtSetCommand class with the specified command string and data.
    /// </summary>
    /// <param name="command">The raw AT command string for setting a value.</param>
    /// <param name="data">Data values to be set with the command (variable number of strings using params keyword).</param>
    public AtSetCommand(string command, params object[] data) : base(command) => Data = [ .. data! ];

    /// <summary>
    /// Initializes a new instance of the AtSetCommand class with the specified command string and data.
    /// </summary>
    /// <param name="command">The raw AT command string for setting a value.</param>
    /// <param name="data">Data values to be set with the command (variable number of strings using params keyword).</param>
    public AtSetCommand(string command, IEnumerable<object> data) : base(command) => Data = [ .. data! ];

    /// <summary>
    /// Gets or sets the optional data values associated with the AT command for setting.
    /// </summary>
    public IEnumerable<object> Data { get; }

    protected override string Suffix => $"={string.Join(",", Data.Select(x => x == null
            ? ""
            : @$"""{x.ToString()
            .Replace("\\", "\\\\")
            .Replace("\"", "\\\"")
            .Replace("\n", "\\n")
            .Replace("\r", "\\r")
            .Replace("\t", "\\t")}"""))}";
}
