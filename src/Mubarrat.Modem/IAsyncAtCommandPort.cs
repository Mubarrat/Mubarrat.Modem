using Mubarrat.Modem.Commands;

namespace Mubarrat.Modem;

/// <summary>
/// This interface defines asynchronous methods for interacting with a modem using AT commands.
/// It inherits from <see cref="IAsyncCommunicationPort"/> to handle the underlying asynchronous serial communication.
/// </summary>
public interface IAsyncAtCommandPort : IAsyncCommunicationPort, IEquatable<IAsyncAtCommandPort>
{
    /// <summary>
    /// Asynchronously sends a single AT command to the modem.
    /// </summary>
    /// <param name="command">The AT command object to be sent.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A Task that resolves to a string containing the response from the modem, 
    /// or null if there was an error or no response.</returns>
    Task<string?> SendCommandAsync(AtCommand command, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously sends a sequence of AT commands to the modem, separated by semicolons (;).
    /// </summary>
    /// <param name="commands">A variable number of AT command objects to be sent.</param>
    /// <returns>A Task that resolves to a string containing the combined response from the modem for all commands, 
    /// or null if there was an error or no response.</returns>
    Task<string?> SendCommandsAsync(params AtCommand[] commands);

    /// <summary>
    /// Asynchronously sends a sequence of AT commands to the modem, separated by semicolons (;).
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <param name="commands">A variable number of AT command objects to be sent.</param>
    /// <returns>A Task that resolves to a string containing the combined response from the modem for all commands, 
    /// or null if there was an error or no response.</returns>
    Task<string?> SendCommandsAsync(CancellationToken cancellationToken, params AtCommand[] commands);

    /// <summary>
    /// Asynchronously sends a collection of AT commands to the modem, combining them into a single command string.
    /// </summary>
    /// <param name="commands">A collection of AT command objects to be sent.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A Task that resolves to a string containing the combined response from the modem for all commands, 
    /// or null if there was an error or no response.</returns>
    Task<string?> SendCommandsAsync(AtCommands commands, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously sends an AT command with ? appended to query the modem and reads the response.
    /// </summary>
    /// <param name="commandName">The name of the AT command to send.</param>
    /// <returns>The response from the modem as a string, or null if there was an error.</returns>
    /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
    Task<string?> TestCommandAsync(string commandName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously sends an AT command with =? appended to query the modem and reads the response.
    /// </summary>
    /// <param name="commandName">The name of the AT command to send.</param>
    /// <returns>The response from the modem as a string, or null if there was an error.</returns>
    /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
    Task<string?> ReadCommandAsync(string commandName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously sends an AT command with = and <paramref name="parameters"/> (separated with commas) appended to query the modem and reads the response.
    /// </summary>
    /// <param name="commandName">The name of the AT command to send.</param>
    /// <param name="parameters">An array of <see cref="DataValue"/>(s) representing the parameters for the command.</param>
    /// <returns>The response from the modem as a string, or null if there was an error.</returns>
    Task<string?> SetCommandAsync(string commandName, params DataValue[] parameters);

    /// <summary>
    /// Asynchronously sends an AT command with = and <paramref name="parameters"/> (separated with commas) appended to query the modem and reads the response.
    /// </summary>
    /// <param name="commandName">The name of the AT command to send.</param>
    /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
    /// <param name="parameters">An array of <see cref="DataValue"/>(s) representing the parameters for the command.</param>
    /// <returns>The response from the modem as a string, or null if there was an error.</returns>
    Task<string?> SetCommandAsync(string commandName, CancellationToken cancellationToken = default, params DataValue[] parameters);

    /// <summary>
    /// Asynchronously sends only an AT command to query the modem and reads the response.
    /// </summary>
    /// <param name="commandName">The name of the AT command to send.</param>
    /// <returns>The response from the modem as a string, or null if there was an error.</returns>
    /// <param name="cancellationToken">A token that can be used to cancel the operation.</param>
    Task<string?> ExecuteCommandAsync(string commandName, CancellationToken cancellationToken = default);
}
