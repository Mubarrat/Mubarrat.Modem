namespace Mubarrat.Modem.Ports;

/// <summary>
/// This class provides an observable communication pattern for a cellular modem.
/// Subscribers can be notified about received data through a <see cref="DataReceived"/>.
/// </summary>
public class ObservableCommunicationPort : CommunicationPort
{
    private Thread? dataReceivingThread;

    /// <summary>
    /// Event that is raised when new data is received from the communication port.
    /// </summary>
    public event DataEventHandler? DataReceived;

    /// <summary>
    /// Initializes a new instance of the <see cref="ObservableCommunicationPort"/> class with the specified communication port settings.
    /// </summary>
    /// <param name="settings">The communication port settings to use.</param>
    public ObservableCommunicationPort(CommunicationPortSettings settings) : base(settings) { }

    public override void Open()
    {
        base.Open();
        dataReceivingThread = new(CheckingData);
        dataReceivingThread.Start();
    }

    /// <summary>
    /// This method runs on a dedicated thread and continuously monitors the port for incoming data.
    /// It employs a loop to check for new data and invokes the <see cref="DataReceived"/> when data is available.
    /// </summary>
    private void CheckingData()
    {
        while (port.IsOpen && port.BytesToRead == 0) ;
        int prevBytes = port.BytesToRead - 1;
        while (port.IsOpen && prevBytes != port.BytesToRead)
        {
            prevBytes = port.BytesToRead;
            Thread.Sleep(1);
        }
        Thread.Sleep(50);
        if (port.IsOpen && !currentlyReceiving)
            DataReceived?.Invoke(this, new(ReceiveResponse()!, DataDirection.Received));
        if (port.IsOpen)
            CheckingData();
    }
}
