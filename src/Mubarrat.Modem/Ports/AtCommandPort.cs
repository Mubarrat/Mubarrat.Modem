namespace Mubarrat.Modem.Ports;

/// <summary>
/// This class provides a low-level interface for interacting with a modem using AT commands.
/// </summary>
public class AtCommandPort : ObservableCommunicationPort, IAtCommandPort
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AtCommandPort"/> class for low-level communication on the specified serial port.
    /// </summary>
    /// <param name="portName">The name or port number of the serial port to connect to (e.g., "COM1"). This parameter cannot be null.</param>
    /// <exception cref="ArgumentNullException">An <see cref="ArgumentNullException"/> if <paramref name="portName"/> is null.</exception>
    public AtCommandPort(string portName) : base(new()
    {
        WriteBufferSize = 4096,
        ReadBufferSize = 2097152,
        PortName = portName ?? throw new ArgumentNullException(nameof(portName)),
        BaudRate = 115200,
        DtrEnable = true,
        RtsEnable = true,
        NewLine = Environment.NewLine
    }) { }

    public string? SendCommand(AtCommand command) => GetResponse(command.ToString());

    public Task<string?> SendCommandAsync(AtCommand command, CancellationToken cancellationToken = default) => GetResponseAsync(command.ToString(), cancellationToken);

    public string? SendCommands(params AtCommand[] commands) => SendCommands(new AtCommands(commands));

    public string? SendCommands(IEnumerable<AtCommand> commands) => SendCommands(new AtCommands(commands));

    public Task<string?> SendCommandsAsync(params AtCommand[] commands) => SendCommandsAsync(new AtCommands(commands));

    public Task<string?> SendCommandsAsync(CancellationToken cancellationToken, params AtCommand[] commands) => SendCommandsAsync(new AtCommands(commands), cancellationToken);

    public Task<string?> SendCommandsAsync(IEnumerable<AtCommand> commands, CancellationToken cancellationToken = default) => SendCommandsAsync(new AtCommands(commands), cancellationToken);

    public string? SendCommands(AtCommands commands) => GetResponse(commands.ToString());

    public Task<string?> SendCommandsAsync(AtCommands commands, CancellationToken cancellationToken = default) => GetResponseAsync(commands.ToString(), cancellationToken);

    public string? TestCommand(string commandName) => SendCommand(AtCommand.Create(AtCommandType.Test, commandName));

    public Task<string?> TestCommandAsync(string commandName, CancellationToken cancellationToken = default) => SendCommandAsync(AtCommand.Create(AtCommandType.Test, commandName), cancellationToken);

    public string? ReadCommand(string commandName) => SendCommand(AtCommand.Create(AtCommandType.Read, commandName));

    public Task<string?> ReadCommandAsync(string commandName, CancellationToken cancellationToken = default) => SendCommandAsync(AtCommand.Create(AtCommandType.Read, commandName), cancellationToken);

    public string? SetCommand(string commandName, params object[] parameters) => SendCommand(AtCommand.Create(AtCommandType.Set, commandName, parameters));

    public string? SetCommand(string commandName, IEnumerable<object> parameters) => SendCommand(AtCommand.Create(AtCommandType.Set, commandName, parameters));

    public Task<string?> SetCommandAsync(string commandName, params object[] parameters) => SendCommandAsync(AtCommand.Create(AtCommandType.Set, commandName, parameters));

    public Task<string?> SetCommandAsync(string commandName, CancellationToken cancellationToken, params object[] parameters) => SendCommandAsync(AtCommand.Create(AtCommandType.Set, commandName, parameters), cancellationToken);

    public Task<string?> SetCommandAsync(string commandName, IEnumerable<object> parameters, CancellationToken cancellationToken = default) => SendCommandAsync(AtCommand.Create(AtCommandType.Set, commandName, parameters), cancellationToken);

    public string? ExecuteCommand(string commandName) => SendCommand(AtCommand.Create(AtCommandType.Execute, commandName));

    public Task<string?> ExecuteCommandAsync(string commandName, CancellationToken cancellationToken = default) => SendCommandAsync(AtCommand.Create(AtCommandType.Execute, commandName), cancellationToken);

    public bool Equals(ISyncAtCommandPort other) => this == other;

    public bool Equals(IAsyncAtCommandPort other) => this == other;

    public bool Equals(IAtCommandPort other) => this == other;
}
