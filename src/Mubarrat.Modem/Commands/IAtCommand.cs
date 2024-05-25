namespace Mubarrat.Modem.Commands;

public interface IAtCommand
{
    /// <summary>
    /// Gets or sets the raw AT command string.
    /// </summary>
    string Command { get; set; }
}
