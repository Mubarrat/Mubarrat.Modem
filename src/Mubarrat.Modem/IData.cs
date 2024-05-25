namespace Mubarrat.Modem;

/// <summary>
/// Defines the base interface for representing the outcome of communication operations.
/// Serves as the foundation for the <see cref="Data"/> class, providing a standard structure 
/// for indicating success/failure, messages, errors, and optional nested data.
/// </summary>
public interface IData
{
    /// <summary>
    /// Indicates whether the operation resulted in a failure.
    /// </summary>
    bool Failed { get; }

    /// <summary>
    /// Contains the actual message during the operation, 
    /// or null if no message was available or an error occurred.
    /// </summary>
    string? Message { get; }

    /// <summary>
    /// Holds an Exception object if an error occurred during the operation, 
    /// or null if successful.
    /// </summary>
    Exception? Exception { get; }

    /// <summary>
    /// Provides an optional inner <see cref="Data"/> object for nested data structures. 
    /// This can be used for complex data exchanges with hierarchical information.
    /// </summary>
    Data? InnerData { get; set; }
}
