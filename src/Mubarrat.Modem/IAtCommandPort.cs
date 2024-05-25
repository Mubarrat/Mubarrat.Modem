namespace Mubarrat.Modem;

/// <summary>
/// This interface defines synchronous and asynchronous methods for interacting with a modem using AT commands.
/// It inherits from <see cref="ICommunicationPort"/> to handle the underlying synchronous and asynchronous serial communication.
/// </summary>
public interface IAtCommandPort : ICommunicationPort, ISyncAtCommandPort, IAsyncAtCommandPort;
