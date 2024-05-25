using Mubarrat.Modem.Commands;

namespace Mubarrat.Modem;

/// <summary>
/// This interface defines synchronous methods for interacting with a modem using AT commands.
/// It inherits from <see cref="ISyncCommunicationPort"/> to handle the underlying synchronous serial communication.
/// </summary>
public interface ISyncAtCommandPort : ISyncCommunicationPort
{
    /// <summary>
    /// Sends a single AT command to the modem.
    /// </summary>
    /// <param name="command">The AT command object to be sent.</param>
    /// <returns>A string containing the response from the modem, 
    /// or null if there was an error or no response.</returns>
    string? SendCommand(AtCommand command);

    /// <summary>
    /// Sends a sequence of AT commands to the modem, separated by semicolons (;).
    /// </summary>
    /// <param name="commands">A variable number of AT command objects to be sent.</param>
    /// <returns>A string containing the combined response from the modem for all commands, 
    /// or null if there was an error or no response.</returns>
    string? SendCommands(params AtCommand[] commands);

    /// <summary>
    /// Sends a collection of AT commands to the modem, combining them into a single command string.
    /// </summary>
    /// <param name="commands">A collection of AT command objects to be sent.</param>
    /// <returns>A string containing the combined response from the modem for all commands, 
    /// or null if there was an error or no response.</returns>
    string? SendCommands(AtCommands commands);

    /// <summary>
    /// Sends an AT command with ? appended to query the modem and reads the response.
    /// </summary>
    /// <param name="commandName">The name of the AT command to send.</param>
    /// <returns>The response from the modem as a string, or null if there was an error.</returns>
    string? TestCommand(string commandName);

    /// <summary>
    /// Sends an AT command with =? appended to query the modem and reads the response.
    /// </summary>
    /// <param name="commandName">The name of the AT command to send.</param>
    /// <returns>The response from the modem as a string, or null if there was an error.</returns>
    string? ReadCommand(string commandName);

    /// <summary>
    /// Sends an AT command with = and <paramref name="parameters"/> (separated with commas) appended to query the modem and reads the response.
    /// </summary>
    /// <param name="commandName">The name of the AT command to send.</param>
    /// <param name="parameters">An array of <see cref="DataValue"/>(s) representing the parameters for the command.</param>
    /// <returns>The response from the modem as a string, or null if there was an error.</returns>
    string? SetCommand(string commandName, params DataValue[] parameters);

    /// <summary>
    /// Sends only an AT command to query the modem and reads the response.
    /// </summary>
    /// <param name="commandName">The name of the AT command to send.</param>
    /// <returns>The response from the modem as a string, or null if there was an error.</returns>
    string? ExecuteCommand(string commandName);
}
