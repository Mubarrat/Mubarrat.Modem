namespace Mubarrat.Modem.Ports;

/// <summary>
/// Defines an interface for interacting with a serial port for modem communication.
/// Provides asynchronous methods for managing the port state, discarding buffers,
/// and potentially additional communication-specific operations.
/// </summary>
public interface IAsyncSerialPort : IDisposable, IEquatable<IAsyncSerialPort>
{
    /// <summary>
    /// Asynchronously opens the serial port for communication.
    /// </summary>
    /// <returns>A <see cref="Task"/> that completes when the serial port is opened successfully.</returns>
    Task OpenAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously closes the serial port, stopping communication.
    /// </summary>
    /// <returns>A <see cref="Task"/> that completes when the serial port is closed successfully.</returns>
    Task CloseAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously discards any data currently in the serial port's input buffer.
    /// </summary>
    /// <returns>A <see cref="Task"/> that completes when the input buffer is discarded.</returns>
    Task DiscardInBufferAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously discards any data currently in the serial port's output buffer.
    /// </summary>
    /// <returns>A <see cref="Task"/> that completes when the output buffer is discarded.</returns>
    Task DiscardOutBufferAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously discards any data currently in both the serial port's input and output buffers.
    /// </summary>
    /// <returns>A <see cref="Task"/> that completes when both buffers are discarded.</returns>
    Task DiscardBufferAsync(CancellationToken cancellationToken = default);
}
