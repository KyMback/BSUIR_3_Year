using System;
using System.IO.Ports;
using System.Linq;
using System.Text;
using Lab_1.Enums;
using Lab_1.Services.Connection;
using Lab_1.Services.Serialization;

namespace Lab_1.Services.Connectors
{
    public class ComConnector : IConnector
    {
        private SerialPort Port { get; set; }

        public SoftwareFlowControl AnotherFlowState = SoftwareFlowControl.XOff;

        public SoftwareFlowControl CurrentFlowState = SoftwareFlowControl.XOff;

        private bool IsDataCanBeSent => !Port.IsOpen || AnotherFlowState == SoftwareFlowControl.XOn;

        private string latestMessage;

        private bool isCurrentPortInitialized;

        private bool isAnotherPortInitialized;

        public bool IsPortsInitialized => isAnotherPortInitialized && isCurrentPortInitialized;

        public byte SourceAddress { get; set; }

        public byte DestinationAddress { get; set; }

        public byte[] LatestPackage { get; set; }

        private readonly byte[] FlowControlSymbols =
        {
            (byte) SoftwareFlowControl.XOff,
            (byte) SoftwareFlowControl.XOn
        };

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
                Port.BaudRate = 9600;
                Port.DataBits = 8;
                Port.Parity = Parity.None;
                Port.StopBits = StopBits.One;
                Port.DataReceived += configuration.DataReceivedHandler;
                Port.Open();
                return true;
            }
            catch (Exception ex)
            {
                latestMessage = ex.Message;
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

            PackageInfo packageInfo = PackageDeserializator.DeserializePackage(buffer);
            if (!IsPackageValid(packageInfo))
            {
                return string.Empty;
            }

            return Port.Encoding.GetString(packageInfo.Message, 0, packageInfo.Message.Length);
        }

        private bool IsPackageValid(PackageInfo packageInfo)
        {
            return packageInfo.DestinationAddress == SourceAddress;
        }

        public int WriteMessage(string message, bool isForceWrite = false, bool skipPackaging = false)
        {
            if (IsDataCanBeSent || isForceWrite)
            {
                if (skipPackaging)
                {
                    Port.Write(message);
                    return message.Length;
                }

                if (message.Length > byte.MaxValue)
                {
                    return 0;
                }

                PackageInfo packageInfo = GetPackageInfo(message);
                byte[] bytes = LatestPackage = PackageSerializator.SerializePackage(packageInfo);
                Port.Write(bytes, 0, bytes.Length);
                return packageInfo.Message.Length;
            }

            return 0;
        }

        private PackageInfo GetPackageInfo(string message)
        {
            return new PackageInfo
            {
                Message = Encoding.UTF8.GetBytes(message),
                DestinationAddress = DestinationAddress,
                SourceAddress = SourceAddress
            };
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

            WriteMessage(((char)CurrentFlowState).ToString(), !IsPortsInitialized, true);
        }

        public DebugInfo GetDebugInfo()
        {
            return new DebugInfo
            {
                IsCurrentPortBusy = CurrentFlowState == SoftwareFlowControl.XOff,
                IsAnotherPortBusy = AnotherFlowState == SoftwareFlowControl.XOff,
                LatestMessage = latestMessage,
                Package = LatestPackage
            };
        }
    }
}
