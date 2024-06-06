namespace Mubarrat.Modem.Utils;

/// <summary>
/// Represents the outcome of a data sending operation.
/// Inherits from the base <see cref="Data"/> class to provide common properties 
/// for success/failure status, message (which represents the sent data), error, and optional nested data.
/// </summary>
public class SentData : Data
{
    /// <summary>
    /// Initializes a new instance of the SendData class with a message indicating 
    /// the data sent and the success of the operation.
    /// </summary>
    /// <param name="message">The message containing the data that was sent.</param>
    public SentData(string? message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the SendData class with a message indicating 
    /// the data sent and the success of the operation, along with optional nested data.
    /// </summary>
    /// <param name="message">The message containing the data that was sent.</param>
    /// <param name="innerData">An optional nested Data object containing additional information.</param>
    public SentData(string? message, Data innerData) : base(message, innerData) { }
}
