namespace Mubarrat.Modem;

/// <summary>
/// Defines an interface for interacting with a serial port for modem communication.
/// Provides synchronous and asynchronous methods for managing the port state,
/// discarding buffers, and potentially additional communication-specific operations.
/// </summary>
public interface ISerialPort : ISyncSerialPort, IAsyncSerialPort
{
    /// <summary>
    /// Gets a boolean value indicating whether the serial port is currently open.
    /// </summary>
    bool IsOpen { get; }
}
