namespace Mubarrat.Modem;

/// <summary>
/// Represents the outcome of a communication operation.
/// Provides information about success/failure, message, potential error, and optional nested data.
/// </summary>
public class Data : IData
{
    /// <summary>
    /// Initializes a new instance of the Data class with a success message.
    /// </summary>
    /// <param name="message">The message associated with the successful operation.</param>
    public Data(string message) => Message = message;

    /// <summary>
    /// Initializes a new instance of the Data class with an exception for a failed operation.
    /// </summary>
    /// <param name="exception">The exception object representing the error that occurred.</param>
    public Data(Exception exception) => Exception = exception;

    /// <summary>
    /// Initializes a new instance of the Data class with a success message and nested data.
    /// </summary>
    /// <param name="message">The message associated with the successful operation.</param>
    /// <param name="innerData">An optional nested Data object containing additional information.</param>
    public Data(string message, Data innerData) : this(message) => InnerData = innerData;

    /// <summary>
    /// Initializes a new instance of the Data class with an exception and nested data for a failed operation.
    /// </summary>
    /// <param name="exception">The exception object representing the error that occurred.</param>
    /// <param name="innerData">An optional nested Data object containing additional information (related to the error).</param>
    public Data(Exception exception, Data innerData) : this(exception) => InnerData = innerData;

    public bool Failed => Exception != null;

    public string? Message { get; }

    public Exception? Exception { get; }

    public Data? InnerData { get; set; }
}
