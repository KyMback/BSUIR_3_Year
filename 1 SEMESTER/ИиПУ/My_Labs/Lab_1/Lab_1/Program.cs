using System;
using System.Linq;
using System.Management;

namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string deviceId = "DeviceID";
            const string venderId = "VenderID";

            var m = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity").Get()
                .Cast<ManagementBaseObject>()
                .Select(obj => obj[deviceId])
                .Cast<string>()
                .Where(obj => obj.Contains("PCI"))
                .Select(str => $"{venderId}: {str.Substring(8, 4)} {deviceId}: {str.Substring(17, 4)}");

            foreach (var o in m.ToArray())
            {
                Console.WriteLine(o);
            }
        }
    }
}
