using System;
using System.IO.Ports;
using System.Linq;
using Lab_1.Enums;
using Lab_1.Services.Connection;

namespace Lab_1.Services.Connectors
{
    public class ComConnector : IConnector
    {
        private SerialPort Port { get; set; }

        public SoftwareFlowControl AnotherFlowState { get; private set; } = SoftwareFlowControl.XOn;

        public SoftwareFlowControl CurrentFlowState { get; private set; } = SoftwareFlowControl.XOn;

        private bool IsDataCanBeSent => !Port.IsOpen || AnotherFlowState == SoftwareFlowControl.XOn;

        private readonly byte[] FlowControlSymbols =
            {(byte) SoftwareFlowControl.XOff, (byte) SoftwareFlowControl.XOn};

        public bool OpenConnection(IConnectionConfiguration configuration)
        {
            if (Port != null)
            {
                return false;
            }

            Port = new SerialPort();

            try
            {
                Port.PortName = configuration.ConnectionName;
                Port.BaudRate = 256000;
                Port.DataBits = 8;
                Port.Parity = Parity.None;
                Port.StopBits = StopBits.One;
                Port.DataReceived += configuration.DataReceivedHandler;
                Port.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string ReadMessage()
        {
            int size = Port.BytesToRead;
            var buffer = new byte[size];
            Port.Read(buffer, 0, size);
            if (buffer.Length == 1 && FlowControlSymbols.Contains(buffer.First()))
            {
                AnotherFlowState = (SoftwareFlowControl)buffer.First();
                return string.Empty;
            }
            return Port.Encoding.GetString(buffer, 0, buffer.Length);
        }

        public void WriteMessage(string message)
        {
            if (!IsDataCanBeSent)
            {
                return;
            }

            Port.Write(message);
        }

        public void CloseConnection()
        {
            Port.Close();
            Port = null;
        }

        public void ChangeCurrentFlowState(bool isCurrentFlowEnable)
        {
            CurrentFlowState = isCurrentFlowEnable
                ? SoftwareFlowControl.XOn
                : SoftwareFlowControl.XOff;

            WriteMessage(((char)CurrentFlowState).ToString());
        }

        public DebugInfo GetDebugInfo()
        {
            return new DebugInfo
            {
                IsCurrentPortBusy = CurrentFlowState == SoftwareFlowControl.XOff,
                IsAnotherPortBusy = AnotherFlowState == SoftwareFlowControl.XOff
            };
        }
    }
}
