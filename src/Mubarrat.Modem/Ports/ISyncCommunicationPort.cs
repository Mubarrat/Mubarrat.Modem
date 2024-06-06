namespace Mubarrat.Modem.Ports;

/// <summary>
/// Defines an interface for advanced communication port operations on top of the basic <see cref="ISyncSerialPort" /> functionality.
/// Provides synchronous methods for synchronous data sending, receiving, and response retrieval.
/// </summary>
public interface ISyncCommunicationPort : ISyncSerialPort, IEquatable<ISyncCommunicationPort>
{
    /// <summary>
    /// Sends the specified data through the communication port synchronously.
    /// </summary>
    /// <param name="data">The string data to send.</param>
    /// <returns>A <see cref="SentData"/> object containing information about the sent data.</returns>
    public SentData SendData(string data);

    /// <summary>
    /// Sends the specified data through the communication port synchronously.
    /// </summary>
    /// <param name="data">The string data to send.</param>
    /// <returns>A <see cref="string"/> containing information about the request.</returns>
    public string SendRequest(string data);

    /// <summary>
    /// Receives data from the communication port synchronously.
    /// May wait for data if none is currently available.
    /// </summary>
    /// <returns>A <see cref="ReceivedData"/> object containing received data information, or null if no data is available.</returns>
    public ReceivedData ReceiveData();

    /// <summary>
    /// Receives response from the communication port synchronously.
    /// May wait for response if none is currently available.
    /// </summary>
    /// <returns>A <see cref="string"/> containing received response, or null if no response is available.</returns>
    public string? ReceiveResponse();

    /// <summary>
    /// Sends the specified data and retrieves the data from the communication port synchronously.
    /// </summary>
    /// <param name="data">The string data to send.</param>
    /// <returns>A <see cref="ReceivedData"/> object containing information about sent data and the received response, or null if no response is expected.</returns>
    public ReceivedData GetData(string data);

    /// <summary>
    /// Sends the specified request and retrieves the response from the communication port synchronously.
    /// </summary>
    /// <param name="data">The string data to send.</param>
    /// <returns>A <see cref="string"/> containing received response, or null if no response is available.</returns>
    public string? GetResponse(string data);

    /// <summary>
    /// Attempts to open the serial port for communication.
    /// Returns true if successful, false otherwise.
    /// </summary>
    /// <returns>A boolean indicating success or failure of the open operation.</returns>
    public bool TryOpen();

    /// <summary>
    /// Attempts to close the serial port, releasing resources.
    /// Returns true if successful, false otherwise.
    /// </summary>
    /// <returns>A boolean indicating success or failure of the close operation.</returns>
    public bool TryClose();
}
