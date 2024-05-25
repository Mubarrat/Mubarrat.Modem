namespace Mubarrat.Modem;

/// <summary>
/// Represents the outcome of a data receiving operation.
/// Inherits from the base <see cref="Data"/> class to provide common properties 
/// for success/failure status, message (which represents the received data), error, and optional nested data.
/// </summary>
public class ReceivedData : Data
{
    /// <summary>
    /// Initializes a new instance of the ReceiveData class with a message indicating 
    /// the data received and the success of the operation.
    /// </summary>
    /// <param name="message">The message containing the data that was received.</param>
    public ReceivedData(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the ReceiveData class with an exception 
    /// indicating a failure during data reception.
    /// </summary>
    /// <param name="exception">The exception object representing the error that occurred.</param>
    public ReceivedData(Exception exception) : base(exception) { }

    /// <summary>
    /// Initializes a new instance of the ReceiveData class with a message indicating 
    /// the data received and the success of the operation, along with optional nested data.
    /// </summary>
    /// <param name="message">The message containing the data that was received.</param>
    /// <param name="innerData">An optional nested Data object containing additional information.</param>
    public ReceivedData(string message, Data innerData) : base(message, innerData) { }

    /// <summary>
    /// Initializes a new instance of the ReceiveData class with an exception and nested data 
    /// for a failed data reception operation.
    /// </summary>
    /// <param name="exception">The exception object representing the error that occurred.</param>
    /// <param name="innerData">An optional nested Data object containing additional information (related to the error).</param>
    public ReceivedData(Exception exception, Data innerData) : base(exception, innerData) { }
}
