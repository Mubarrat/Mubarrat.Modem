namespace Mubarrat.Modem;

/// <summary>
/// Defines an interface for advanced communication port operations on top of the basic <see cref="IAsyncSerialPort" /> functionality.
/// Provides asynchronous methods for asynchronous data sending, receiving, and response retrieval.
/// </summary>
public interface IAsyncCommunicationPort : IAsyncSerialPort
{
    /// <summary>
    /// Sends the specified data string through the communication port asynchronously.
    /// </summary>
    /// <param name="data">The string data to send.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A <see cref="Task{TResult}"/> that completes and returns <see cref="SentData"/> object when sent, containing sent data information.</returns>
    public Task<SentData> SendDataAsync(string data, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends the specified data through the communication port asynchronously.
    /// </summary>
    /// <param name="data">The string data to send.</param>
    /// <returns>A <see cref="string"/> object containing information about the request.</returns>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A <see cref="Task{TResult}"/> that completes and returns <see cref="string"/> containing information about the request.</returns>
    public Task<string> SendRequestAsync(string data, CancellationToken cancellationToken = default);

    /// <summary>
    /// Receives data from the communication port asynchronously.
    /// May wait for data if none is currently available.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A <see cref="Task{TResult}"/> that completes and returns <see cref="ReceivedData"/> object when received, containing received data information, or null if no data is available.</returns>
    public Task<ReceivedData> ReceiveDataAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Receives response from the communication port asynchronously.
    /// May wait for response if none is currently available.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A <see cref="Task{TResult}"/> that completes and returns <see cref="string"/> containing received response, or null if no response is available.</returns>
    public Task<string?> ReceiveResponseAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends the specified data and retrieves the response from the communication port asynchronously.
    /// </summary>
    /// <param name="data">The string data to send.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A <see cref="Task{TResult}"/> that completes and returns <see cref="ReceivedData"/> object when received, containing a <see cref="SentData"/> in <see cref="Data.InnerData"/> and received response information, or null if no response is expected.</returns>
    public Task<ReceivedData> GetDataAsync(string data, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends the specified request and retrieves the response from the communication port asynchronously.
    /// </summary>
    /// <param name="data">The string data to send.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A <see cref="Task{TResult}"/> that completes and returns <see cref="string"/> containing received response, or null if no response is available.</returns>
    public Task<string?> GetResponseAsync(string data, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously attempts to open the serial port for communication.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A <see cref="Task{TResult}"/> that completes and returns a boolean indicating success or failure of the open operation.</returns>
    public Task<bool> TryOpenAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Attempts to close the serial port, releasing resources.
    /// Returns true if successful, false otherwise.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A <see cref="Task{TResult}"/> that completes and returns a boolean indicating success or failure of the close operation.</returns>
    public Task<bool> TryCloseAsync(CancellationToken cancellationToken = default);
}
