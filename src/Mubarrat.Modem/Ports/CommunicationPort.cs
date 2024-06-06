using System.Text;
using static System.Environment;

namespace Mubarrat.Modem.Ports;

/// <summary>
/// This class provides functionality to manage communication through a serial port for sending and receiving data.
/// It supports asynchronous and synchronous data transfer with error handling capabilities.
/// </summary>
public class CommunicationPort : ICommunicationPort
{
    /// <summary>
    /// The underlying <see cref="SerialPort" /> object used for communication.
    /// </summary>
    protected readonly SerialPort port;

    protected bool currentlyReceiving;

    public bool IsOpen => port.IsOpen;

    /// <summary>
    /// Initializes a new instance of the <see cref="CommunicationPort"/> class using the provided configuration settings.
    /// </summary>
    /// <param name="settings">An instance of <see cref="CommunicationPortSettings"/> containing the desired serial port configuration options.</param>
    public CommunicationPort(CommunicationPortSettings settings) => port = new()
    {
        PortName = settings.PortName,
        BaudRate = settings.BaudRate,
        DataBits = settings.DataBits,
        Parity = settings.Parity,
        StopBits = settings.StopBits,
        DiscardNull = settings.DiscardNull,
        Handshake = settings.Handshake,
        ParityReplace = settings.ParityReplace,
        ReceivedBytesThreshold = settings.ReceivedBytesThreshold,
        NewLine = settings.NewLine,
        WriteBufferSize = settings.WriteBufferSize,
        ReadBufferSize = settings.ReadBufferSize,
        WriteTimeout = settings.WriteTimeout,
        ReadTimeout = settings.ReadTimeout,
        DtrEnable = settings.DtrEnable,
        RtsEnable = settings.RtsEnable,
        Encoding = Encoding.GetEncoding("iso-8859-1")
    };

    /// <inheritdoc/>
    /// <exception cref="InvalidOperationException">Thrown if the port is already open.</exception>
    /// <exception cref="IOException">Thrown if there's an error opening the port due to hardware issues or other IO errors.</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown if the application doesn't have sufficient permissions to access the serial port.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if one of the arguments passed to the OpenAsync method is invalid (e.g., invalid port name or baud rate).</exception>
    /// <exception cref="NotSupportedException">Thrown if the underlying system doesn't support the requested operation (e.g., specific serial port functionality or configuration not supported by the OS or hardware).</exception>
    public virtual void Open() { if (!IsOpen) port.Open(); }

    /// <inheritdoc/>
    /// <exception cref="InvalidOperationException">Thrown if the port is already open.</exception>
    /// <exception cref="IOException">Thrown if there's an error opening the port due to hardware issues or other IO errors.</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown if the application doesn't have sufficient permissions to access the serial port.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if one of the arguments passed to the OpenAsync method is invalid (e.g., invalid port name or baud rate).</exception>
    /// <exception cref="NotSupportedException">Thrown if the underlying system doesn't support the requested operation (e.g., specific serial port functionality or configuration not supported by the OS or hardware).</exception>
    public Task OpenAsync(CancellationToken cancellationToken = default) => Task.Run(Open, cancellationToken);

    /// <inheritdoc/>
    /// <exception cref="IOException">Thrown if there's an error closing the port.</exception>
    public virtual void Close() { if (IsOpen) port.Close(); }

    /// <inheritdoc/>
    /// <exception cref="IOException">Thrown if there's an error closing the port.</exception>
    public Task CloseAsync(CancellationToken cancellationToken = default) => Task.Run(Close, cancellationToken);

    public bool TryOpen()
    {
        try
        {
            Open();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> TryOpenAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await OpenAsync(cancellationToken);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool TryClose()
    {
        try
        {
            Close();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> TryCloseAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await CloseAsync(cancellationToken);
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <inheritdoc/>
    /// <exception cref="IOException">Thrown if there's an error discarding the data.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the port is not open.</exception>
    public void DiscardInBuffer() => port.DiscardInBuffer();

    /// <inheritdoc/>
    /// <exception cref="IOException">Thrown if there's an error discarding the data.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the port is not open.</exception>
    public Task DiscardInBufferAsync(CancellationToken cancellationToken = default) => Task.Run(DiscardInBuffer, cancellationToken);

    /// <inheritdoc/>
    /// <exception cref="IOException">Thrown if there's an error discarding the data.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the port is not open.</exception>
    public void DiscardOutBuffer() => port.DiscardOutBuffer();

    /// <inheritdoc/>
    /// <exception cref="IOException">Thrown if there's an error discarding the data.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the port is not open.</exception>
    public Task DiscardOutBufferAsync(CancellationToken cancellationToken = default) => Task.Run(DiscardOutBuffer, cancellationToken);

    /// <inheritdoc/>
    /// <exception cref="IOException">Thrown if there's an error discarding the data.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the port is not open.</exception>
    public void DiscardBuffer() { DiscardInBuffer(); DiscardOutBuffer(); }

    /// <inheritdoc/>
    /// <exception cref="IOException">Thrown if there's an error discarding the data from either buffer.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the port is not open.</exception>
    public Task DiscardBufferAsync(CancellationToken cancellationToken = default) => Task.Run(DiscardBuffer, cancellationToken);

    /// <summary>
    /// Releases all resources used by the <see cref="CommunicationPort"/> class.
    /// This method should be called when the <see cref="CommunicationPort"/> is no longer needed.
    /// </summary>
    public void Dispose()
    {
        port.Dispose();
        GC.SuppressFinalize(this);
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">Thrown if the data parameter is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the data string is empty.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the port is not open.</exception>
    /// <exception cref="IOException">Thrown if an error occurs while sending data through the serial port.</exception>
    public SentData SendData(string data) => new(SendRequest(data));

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">Thrown if the data parameter is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the data string is empty.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the port is not open.</exception>
    /// <exception cref="IOException">Thrown if an error occurs while sending data through the serial port.</exception>
    /// <exception cref="TaskCanceledException">The task has been canceled.</exception>
    /// <exception cref="ObjectDisposedException">The <see cref="CancellationTokenSource"/> associated with <paramref name="cancellationToken"/> was disposed.</exception>
    public async Task<SentData> SendDataAsync(string data, CancellationToken cancellationToken = default) => new(await SendRequestAsync(data, cancellationToken));

    public string SendRequest(string data)
    {
        if (!IsOpen)
            throw new InvalidOperationException("The serial port is not currently open.");
        DiscardBuffer();
        byte[] dataBytes = port.Encoding.GetBytes(data + port.NewLine);
        port.BaseStream.Write(dataBytes, 0, dataBytes.Length);
        while (port.BytesToRead == 0) ;
        int prevBytes = port.BytesToRead - 1;
        while (prevBytes != port.BytesToRead)
        {
            prevBytes = port.BytesToRead;
            Thread.Sleep(1);
        }
        return data;
    }

    public async Task<string> SendRequestAsync(string data, CancellationToken cancellationToken = default)
    {
        if (!IsOpen)
            throw new InvalidOperationException("The serial port is not currently open.");
        await DiscardBufferAsync(cancellationToken);
        byte[] dataBytes = port.Encoding.GetBytes(data + port.NewLine);
        cancellationToken.ThrowIfCancellationRequested();
        await port.BaseStream.WriteAsync(dataBytes, 0, dataBytes.Length, cancellationToken);
        while (port.BytesToRead == 0)
            cancellationToken.ThrowIfCancellationRequested();
        int prevBytes = port.BytesToRead - 1;
        while (prevBytes != port.BytesToRead)
        {
            cancellationToken.ThrowIfCancellationRequested();
            prevBytes = port.BytesToRead;
            await Task.Delay(1, cancellationToken);
        }
        return data;
    }

    /// <inheritdoc/>
    /// <exception cref="InvalidOperationException">Thrown if the port is not open.</exception>
    public ReceivedData ReceiveData() => new(ReceiveResponse());

    /// <inheritdoc/>
    /// <exception cref="InvalidOperationException">Thrown if the port is not open.</exception>
    /// <exception cref="TaskCanceledException">The task has been canceled.</exception>
    /// <exception cref="ObjectDisposedException">The <see cref="CancellationTokenSource"/> associated with <paramref name="cancellationToken"/> was disposed.</exception>
    public async Task<ReceivedData> ReceiveDataAsync(CancellationToken cancellationToken = default) => new(await ReceiveResponseAsync(cancellationToken));

    public string? ReceiveResponse()
    {
        if (!IsOpen)
            throw new InvalidOperationException("The serial port is not currently open.");
        currentlyReceiving = true;
        StringBuilder responseBuilder = new();
        try
        {
            byte[] buffer = new byte[1024];
            do
            {
                int bytesRead = port.BaseStream.Read(buffer, 0, buffer.Length);
                if (bytesRead > 0)
                    responseBuilder.Append(port.Encoding.GetString(buffer, 0, bytesRead));
            }
            while (!CheckResponseReceived(responseBuilder.ToString()));
            return responseBuilder.ToString().Trim().Replace(NewLine + NewLine, NewLine);
        }
        finally
        {
            currentlyReceiving = false;
        }
    }

    public async Task<string?> ReceiveResponseAsync(CancellationToken cancellationToken = default)
    {
        if (!IsOpen)
            throw new InvalidOperationException("The serial port is not currently open.");
        currentlyReceiving = true;
        StringBuilder responseBuilder = new();
        try
        {
            cancellationToken.ThrowIfCancellationRequested();
            byte[] buffer = new byte[1024];
            do
            {
                int bytesRead = await port.BaseStream.ReadAsync(buffer, 0, buffer.Length, cancellationToken);
                cancellationToken.ThrowIfCancellationRequested();
                if (bytesRead > 0)
                    responseBuilder.Append(port.Encoding.GetString(buffer, 0, bytesRead));
            }
            while (!cancellationToken.IsCancellationRequested &&
                   !CheckResponseReceived(responseBuilder.ToString()));
            return responseBuilder.ToString().Trim().Replace(NewLine + NewLine, NewLine);
        }
        finally
        {
            currentlyReceiving = false;
        }
    }

    private static readonly string[] ValidEndings =
    [
        $"{NewLine}OK{NewLine}",
        $"{NewLine}> ",
        $"{NewLine}ERROR{NewLine}"
    ];

    private bool CheckResponseReceived(string response) => ValidEndings.Any(response.EndsWith);

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">Thrown if the data parameter is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the data string is empty.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the port is not open.</exception>
    /// <exception cref="IOException">Thrown if an error occurs while sending data through the serial port.</exception>
    public ReceivedData GetData(string data)
    {
        if (!IsOpen)
            throw new InvalidOperationException("The serial port is not currently open.");
        SentData sent = SendData(data);
        ReceivedData receivedData = ReceiveData();
        receivedData.InnerData = sent;
        return receivedData;
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">Thrown if the data parameter is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the data string is empty.</exception>
    /// <exception cref="InvalidOperationException">Thrown if the port is not open.</exception>
    /// <exception cref="IOException">Thrown if an error occurs while sending data through the serial port.</exception>
    /// <exception cref="TaskCanceledException">The task has been canceled.</exception>
    /// <exception cref="ObjectDisposedException">The <see cref="CancellationTokenSource"/> associated with <paramref name="cancellationToken"/> was disposed.</exception>
    public async Task<ReceivedData> GetDataAsync(string data, CancellationToken cancellationToken = default)
    {
        if (!IsOpen)
            throw new InvalidOperationException("The serial port is not currently open.");
        SentData sent = await SendDataAsync(data, cancellationToken);
        ReceivedData receivedData = await ReceiveDataAsync(cancellationToken);
        receivedData.InnerData = sent;
        return receivedData;
    }

    public string? GetResponse(string data)
    {
        SendRequest(data);
        return ReceiveResponse();
    }

    public async Task<string?> GetResponseAsync(string data, CancellationToken cancellationToken = default)
    {
        await SendRequestAsync(data, cancellationToken);
        return await ReceiveResponseAsync(cancellationToken);
    }

    public bool Equals(ISerialPort other) => this == other;

    public bool Equals(ISyncSerialPort other) => this == other;

    public bool Equals(IAsyncSerialPort other) => this == other;

    public bool Equals(ISyncCommunicationPort other) => this == other;

    public bool Equals(IAsyncCommunicationPort other) => this == other;

    public bool Equals(ICommunicationPort other) => this == other;
}
