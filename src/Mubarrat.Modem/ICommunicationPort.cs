namespace Mubarrat.Modem;

/// <summary>
/// Defines an interface for advanced communication port operations on top of the basic <see cref="ISerialPort" /> functionality.
/// Provides synchronous and asynchronous methods for synchronous and asynchronous data sending, receiving, and response retrieval.
/// </summary>
public interface ICommunicationPort : ISerialPort, ISyncCommunicationPort, IAsyncCommunicationPort, IEquatable<ICommunicationPort>;
