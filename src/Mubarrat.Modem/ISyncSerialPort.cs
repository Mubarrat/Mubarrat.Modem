namespace Mubarrat.Modem;

/// <summary>
/// Defines an interface for interacting with a serial port for modem communication.
/// Provides synchronous methods for managing the port state, discarding buffers,
/// and potentially additional communication-specific operations.
/// </summary>
public interface ISyncSerialPort : IDisposable
{
    /// <summary>
    /// Opens the serial port for communication.
    /// </summary>
    void Open();

    /// <summary>
    /// Closes the serial port, releasing resources.
    /// </summary>
    void Close();

    /// <summary>
    /// Discards any data currently in the serial port's input buffer.
    /// </summary>
    void DiscardInBuffer();

    /// <summary>
    /// Discards any data currently in the serial port's output buffer.
    /// </summary>
    void DiscardOutBuffer();

    /// <summary>
    /// Discards any data in both the input and output buffers of the serial port.
    /// </summary>
    void DiscardBuffer();
}
