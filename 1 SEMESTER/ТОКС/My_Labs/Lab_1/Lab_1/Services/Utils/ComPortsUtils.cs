using System.IO.Ports;

namespace Lab_1.Services.Utils
{
    public static class ComPortsUtils
    {
        public static string[] GetAllComPorts()
        {
            return SerialPort.GetPortNames();
        }
    }
}
