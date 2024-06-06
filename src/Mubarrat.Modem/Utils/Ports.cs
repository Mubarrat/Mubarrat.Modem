namespace Mubarrat.Modem.Utils;

/// <summary>
/// This class provides static methods for accessing information about available serial ports.
/// </summary>
public static class Ports
{
    /// <summary>
    /// Gets a string array containing the names of all available serial ports on the system.
    /// </summary>
    public static string[] AllPorts => SerialPort.GetPortNames();
}
