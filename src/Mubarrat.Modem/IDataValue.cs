namespace Mubarrat.Modem;

/// <summary>
/// Represents a single data value, providing methods to access it in its raw string format.
/// </summary>
public interface IDataValue
{
    /// <summary>
    /// Gets the data value as an unevaluated string.
    /// </summary>
    /// <returns>The data value as a string without any interpretation or conversion.</returns>
    string UnevaluatedString();

    /// <summary>
    /// Gets the data value as an unevaluated string, potentially representing an integer.
    /// </summary>
    /// <returns>The data value as a string, possibly representing an integer.</returns>
    string UnevaluatedInteger();
}
