namespace Mubarrat.Modem;

/// <summary>
/// This class provides functionality to manage communication through a serial port for sending and receiving data.
/// It supports asynchronous and synchronous data transfer with error handling capabilities.
/// </summary>
public class CommunicationPort : ICommunicationPort
{
    /// <summary>
    /// The underlying <see cref="SerialPort" /> object used for communication.
    /// </summary>
    private readonly SerialPort port;

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
        RtsEnable = settings.RtsEnable
    };

    /// <inheritdoc/>
    /// <exception cref="InvalidOperationException">Thrown if the port is already open.</exception>
    /// <exception cref="IOException">Thrown if there's an error opening the port due to hardware issues or other IO errors.</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown if the application doesn't have sufficient permissions to access the serial port.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if one of the arguments passed to the OpenAsync method is invalid (e.g., invalid port name or baud rate).</exception>
    /// <exception cref="NotSupportedException">Thrown if the underlying system doesn't support the requested operation (e.g., specific serial port functionality or configuration not supported by the OS or hardware).</exception>
    public void Open() { if (!IsOpen) port.Open(); }

    /// <inheritdoc/>
    /// <exception cref="InvalidOperationException">Thrown if the port is already open.</exception>
    /// <exception cref="IOException">Thrown if there's an error opening the port due to hardware issues or other IO errors.</exception>
    /// <exception cref="UnauthorizedAccessException">Thrown if the application doesn't have sufficient permissions to access the serial port.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if one of the arguments passed to the OpenAsync method is invalid (e.g., invalid port name or baud rate).</exception>
    /// <exception cref="NotSupportedException">Thrown if the underlying system doesn't support the requested operation (e.g., specific serial port functionality or configuration not supported by the OS or hardware).</exception>
    public Task OpenAsync(CancellationToken cancellationToken = default) => Task.Run(Open, cancellationToken);

    /// <inheritdoc/>
    /// <exception cref="IOException">Thrown if there's an error closing the port.</exception>
    public void Close() { if (IsOpen) port.Close(); }

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
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the data string is empty (depending on implementation).</exception>
    /// <exception cref="InvalidOperationException">Thrown if the port is not open.</exception>
    /// <exception cref="IOException">Thrown if an error occurs while sending data through the serial port.</exception>
    public SentData SendData(string data)
    {
        if (!IsOpen)
            throw new InvalidOperationException("The serial port is not currently open.");
        try
        {
            port.WriteLine(data);
            return new(data);
        }
        catch (Exception ex)
        {
            return new(ex);
        }
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">Thrown if the data parameter is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the data string is empty (depending on implementation).</exception>
    /// <exception cref="InvalidOperationException">Thrown if the port is not open.</exception>
    /// <exception cref="IOException">Thrown if an error occurs while sending data through the serial port.</exception>
    /// <exception cref="TaskCanceledException">The task has been canceled.</exception>
    /// <exception cref="ObjectDisposedException">The <see cref="CancellationTokenSource"/> associated with <paramref name="cancellationToken"/> was disposed.</exception>
    public Task<SentData> SendDataAsync(string data, CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
            throw new ArgumentException("Cancellation token already cancelled.", nameof(cancellationToken));
        return Task.Run(() => SendData(data), cancellationToken);
    }

    /// <inheritdoc/>
    /// <exception cref="InvalidOperationException">Thrown if the port is not open.</exception>
    public ReceivedData ReceiveData()
    {
        if (!IsOpen)
            throw new InvalidOperationException("The serial port is not currently open.");
        return new(port.ReadExisting().Trim().Replace("\r\n\r\n", Environment.NewLine));
    }

    /// <inheritdoc/>
    /// <exception cref="InvalidOperationException">Thrown if the port is not open.</exception>
    /// <exception cref="TaskCanceledException">The task has been canceled.</exception>
    /// <exception cref="ObjectDisposedException">The <see cref="CancellationTokenSource"/> associated with <paramref name="cancellationToken"/> was disposed.</exception>
    public Task<ReceivedData> ReceiveDataAsync(CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
            throw new ArgumentException("Cancellation token already cancelled.", nameof(cancellationToken));
        return Task.Run(ReceiveData, cancellationToken);
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">Thrown if the data parameter is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the data string is empty (depending on implementation).</exception>
    /// <exception cref="InvalidOperationException">Thrown if the port is not open.</exception>
    /// <exception cref="IOException">Thrown if an error occurs while sending data through the serial port.</exception>
    public ReceivedData GetData(string data)
    {
        if (!IsOpen)
            throw new InvalidOperationException("The serial port is not currently open.");
        SentData sent = SendData(data);
        while (port.BytesToRead == 0);
        int prevBytes = port.BytesToRead - 1;
        while (prevBytes != port.BytesToRead)
        {
            prevBytes = port.BytesToRead;
            Thread.Sleep(1);
        }
        ReceivedData receivedData = ReceiveData();
        receivedData.InnerData = sent;
        return receivedData;
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentNullException">Thrown if the data parameter is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the data string is empty (depending on implementation).</exception>
    /// <exception cref="InvalidOperationException">Thrown if the port is not open.</exception>
    /// <exception cref="IOException">Thrown if an error occurs while sending data through the serial port.</exception>
    /// <exception cref="TaskCanceledException">The task has been canceled.</exception>
    /// <exception cref="ObjectDisposedException">The <see cref="CancellationTokenSource"/> associated with <paramref name="cancellationToken"/> was disposed.</exception>
    public async Task<ReceivedData> GetDataAsync(string data, CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
            throw new ArgumentException("Cancellation token already cancelled.", nameof(cancellationToken));
        if (!IsOpen)
            throw new InvalidOperationException("The serial port is not currently open.");
        SentData sent = await SendDataAsync(data, cancellationToken);
        while (!cancellationToken.IsCancellationRequested && port.BytesToRead == 0) ;
        if (cancellationToken.IsCancellationRequested)
            return new(new OperationCanceledException(cancellationToken), sent);
        int prevBytes = port.BytesToRead - 1;
        while (!cancellationToken.IsCancellationRequested && prevBytes != port.BytesToRead)
        {
            prevBytes = port.BytesToRead;
            await Task.Delay(1, cancellationToken);
        }
        ReceivedData receivedData = await ReceiveDataAsync(cancellationToken);
        receivedData.InnerData = sent;
        return receivedData;
    }
}
