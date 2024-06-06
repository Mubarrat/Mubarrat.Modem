namespace Mubarrat.Modem.Delegates;

/// <summary>
///	Delegate used to handle data events (sending or receiving) raised by the <see cref="CommunicationPort"/> class.
///	</summary>
///	<param name="sender">The <see cref="CommunicationPort"/> object that raised the event.</param>
///	<param name="args">A <see cref="DataEventArgs"/> object containing information about the data event.</param>
public delegate void DataEventHandler(CommunicationPort sender, DataEventArgs args);
