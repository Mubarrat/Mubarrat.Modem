namespace Mubarrat.Modem.Ports;

/// <summary>
/// A struct provides a way to configure options for <see cref="CommunicationPort"/>.
/// </summary>
public struct CommunicationPortSettings
{
    /// <summary>
    /// Gets or sets the name or port number of the serial port to connect to (e.g., "COM1").
    /// Defaults to "COM1".
    /// </summary>
    public string PortName { get; set; } = "COM1";

    /// <summary>
    /// Gets or sets the baud rate (communication speed) for the serial port in bits per second (bps).
    /// Defaults to 9600 bps, a common value for GSM modems.
    /// </summary>
    public int BaudRate { get; set; } = 9600;

    /// <summary>
    /// Gets or sets the number of data bits used per character in serial communication.
    /// Common values are 7 or 8 bits. Defaults to 8 bits.
    /// </summary>
    public int DataBits { get; set; } = 8;

    /// <summary>
    /// Gets or sets the parity checking method used for serial communication.
    /// This helps detect errors in data transmission. Defaults to <see cref="Parity.None"/>.
    /// </summary>
    public Parity Parity { get; set; } = Parity.None;

    /// <summary>
    /// Gets or sets the number of stop bits used to signal the end of a character in serial communication.
    /// Common values are 1 or 2 bits. Defaults to <see cref="StopBits.One"/>.
    /// </summary>
    public StopBits StopBits { get; set; } = StopBits.One;

    /// <summary>
    /// Gets or sets a value indicating whether to discard null bytes received from the serial port.
    /// Defaults to <c>false</c> (null bytes are not discarded).
    /// </summary>
    public bool DiscardNull { get; set; } = false;

    /// <summary>
    /// Gets or sets the handshake mode used for flow control between the application and the serial port.
    /// This helps prevent data overrun or underrun errors. Defaults to <see cref="Handshake.None"/>.
    /// </summary>
    public Handshake Handshake { get; set; } = Handshake.None;

    /// <summary>
    /// Gets or sets the character to be used for replacing parity errors during data reception.
    /// Applicable only if a parity checking method is enabled. Defaults to a question mark ('?').
    /// </summary>
    public byte ParityReplace { get; set; } = (byte)'?';

    /// <summary>
    /// Gets or sets the minimum number of bytes that must be received before a <see cref="DataReceived"/> event is raised.
    /// A value of 1 triggers the event on every received byte. Defaults to 1.
    /// </summary>
    public int ReceivedBytesThreshold { get; set; } = 1;

    /// <summary>
    /// Gets or sets the string representing the newline character sequence used when writing data to the serial port.
    /// Defaults to a single line feed character ("\n").
    /// </summary>
    public string NewLine { get; set; } = "\n";

    /// <summary>
    /// Gets or sets the size of the buffer used for outgoing data on the serial port in bytes.
    /// A larger buffer can improve performance for bulk writes, but it also increases memory usage. Defaults to 2048 bytes or 2 KB.
    /// </summary>
    public int WriteBufferSize { get; set; } = 2048;

    /// <summary>
    /// Gets or sets the size of the buffer used for incoming data on the serial port in bytes.
    /// A larger buffer size can reduce the number of reads required for large data streams, but it also increases memory usage. Defaults to 4096 bytes or 4 KB.
    /// </summary>
    public int ReadBufferSize { get; set; } = 4096;

    /// <summary>
    /// Gets or sets the timeout value in milliseconds for write operations on the serial port.
    /// A value of zero indicates no timeout (infinite wait). Defaults to <see cref="SerialPort.InfiniteTimeout"/>.
    /// </summary>
    public int WriteTimeout { get; set; } = SerialPort.InfiniteTimeout;

    /// <summary>
    /// Gets or sets the timeout value in milliseconds for read operations on the serial port.
    /// A value of zero indicates no timeout (infinite wait). Defaults to <see cref="SerialPort.InfiniteTimeout"/>.
    /// </summary>
    public int ReadTimeout { get; set; } = SerialPort.InfiniteTimeout;

    /// <summary>
    /// Gets or sets a value indicating whether to enable the Data Terminal Ready (DTR) signal on the serial port.
    /// This signal can be used for handshaking with certain devices. Defaults to <c>false</c> (DTR disabled).
    /// </summary>
    public bool DtrEnable { get; set; } = false;

    /// <summary>
    /// Gets or sets a value indicating whether to enable the Ready To Send (RTS) signal on the serial port.
    /// This signal can be used for flow control with certain devices. Defaults to <c>false</c> (RTS disabled).
    /// </summary>
    public bool RtsEnable { get; set; } = false;

    /// <summary>
    /// Initializes a new instance of the <see cref="CommunicationPortSettings"/> struct with default values.
    /// </summary>
    public CommunicationPortSettings() { }
}
