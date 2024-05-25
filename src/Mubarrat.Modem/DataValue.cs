namespace Mubarrat.Modem;

/// <summary>
/// Represents a data value that can be stored as either a string or an integer.
/// Provides methods to access the data in its raw string format without interpretation or conversion.
/// </summary>
public class DataValue : IDataValue
{
    private readonly string? stringValue;
    private readonly int? intValue;

    public DataValue(string stringValue) => this.stringValue = stringValue ?? throw new ArgumentNullException(nameof(stringValue));
    public DataValue(int intValue) => this.intValue = intValue;

    private string UnevaluatedString()
    {
        if (stringValue == null)
            return "";
        return @$"""{
            stringValue
            .Replace("\\", "\\\\")
            .Replace("\"", "\\\"")
            .Replace("\n", "\\n")
            .Replace("\r", "\\r")
            .Replace("\t", "\\t")
        }""";
    }

    private string UnevaluatedInteger()
    {
        if (intValue == null)
            return "";
        return intValue.ToString();
    }

    public override string ToString() => stringValue != null ? UnevaluatedString() : UnevaluatedInteger();

    string IDataValue.UnevaluatedString() => UnevaluatedString();

    string IDataValue.UnevaluatedInteger() => UnevaluatedInteger();
}
