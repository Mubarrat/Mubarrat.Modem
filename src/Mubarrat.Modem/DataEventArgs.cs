namespace Mubarrat.Modem;

/// <summary>
/// This class holds arguments for data related events in the <see cref="CommunicationPort"/> class.
/// It provides information about the success or failure of the operation 
/// and any associated data or exception.
/// </summary>
public class DataEventArgs : EventArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DataEventArgs"/> class with successful operation data and direction.
    /// </summary>
    /// <param name="data">The data involved in the successful event.</param>
    /// <param name="direction">The direction of the data (received or sent).</param>
    public DataEventArgs(string data, DataDirection direction) => (Data, Direction) = (data ?? throw new ArgumentNullException(nameof(data)), direction);

    /// <summary>
    /// Initializes a new instance of the <see cref="DataEventArgs"/> class with an exception that occurred during the operation and direction.
    /// </summary>
    /// <param name="exception">The exception that caused the operation to fail.</param>
    /// <param name="direction">The direction of the data (received or sent).</param>
    public DataEventArgs(Exception exception, DataDirection direction) => (Failed, Exception, Direction) = (true, exception ?? throw new ArgumentNullException(nameof(exception)), direction);

    /// <summary>
    /// Indicates whether the operation associated with the event was successful.
    /// </summary>
    public bool Failed { get; }

    /// <summary>
    /// Contains the data involved in the event (received data or sent data). 
    /// Can be null if the operation failed.
    /// </summary>
    public string? Data { get; }

    /// <summary>
    /// Holds any exception that occurred during the operation. 
    /// Null if the operation was successful.
    /// </summary>
    public Exception? Exception { get; }

    /// <summary>
    /// An enumeration indicating whether the data was received or sent.
    /// </summary>
    public DataDirection Direction { get; }

    /// <summary>
    /// Contains additional information related to the original data event.
    /// This property can be null if no inner data is provided.
    /// </summary>
    public DataEventArgs? InnerDataEventArgs { get; set; }
}
