using System.IO.Ports;
using Lab_1.Enums;

namespace Lab_1.Services.Connection
{
    public class ConnectionConfiguration : IConnectionConfiguration
    {
        public ConnectionType ConnectionType { get; set; }

        public string ConnectionName { get; set; }

        public SerialDataReceivedEventHandler DataReceivedHandler { get; set; }
    }
}
