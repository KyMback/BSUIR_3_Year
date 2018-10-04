using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
