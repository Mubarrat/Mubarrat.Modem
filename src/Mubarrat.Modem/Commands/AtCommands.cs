namespace Mubarrat.Modem.Commands;

/// <summary>
/// This class represents a collection of AtCommand objects.
/// Inherits from the List<AtCommand> class.
/// </summary>
public class AtCommands : List<AtCommand>
{
    /// <summary>
    /// Initializes a new instance of the AtCommands class with an initial collection of AtCommand objects.
    /// </summary>
    /// <param name="collection">An IEnumerable collection containing <see cref="AtCommand"/> objects to be added to the list.</param>
    public AtCommands(IEnumerable<AtCommand> collection) : base(collection) { }

    /// <summary>
    /// Overrides the ToString() method to return a combined AT command string 
    /// from all the AtCommand objects in the list.
    /// </summary>
    /// <returns>A combined AT command string with commands separated by semicolons (;).</returns>
    public override string ToString() => "AT" + string.Join(";", this.Select(x => new string(x.ToString().Skip(2).ToArray())));
}
