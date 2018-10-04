using System;
using System.IO.Ports;

namespace Lab_1.Services.Connection
{
    public interface IConnectionConfiguration
    {
        string ConnectionName { get; set; }

        SerialDataReceivedEventHandler DataReceivedHandler { get; set; }
    }
}
