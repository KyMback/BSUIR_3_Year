using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;

namespace Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var searcher13 = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DiskDrive");

            var list = searcher13.Get().Cast<ManagementObject>().ToArray();

            Tuple<long, long> allDrives = DriveInfo.GetDrives()
                .Select(v => new Tuple<long, long>(v.AvailableFreeSpace, v.TotalSize)).Aggregate((l, r) =>
                    new Tuple<long, long>(l.Item1 + r.Item1, l.Item2 + r.Item2));


            foreach (var entity in list)
            {
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine($"Model: {entity["Model"]}");
                Console.WriteLine($"Manufacturer: {entity["Manufacturer"]}");
                Console.WriteLine($"SerialNumber: {entity["SerialNumber"]}");
                Console.WriteLine($"FirmwareRevision: {entity["FirmwareRevision"]}");
                Console.WriteLine($"FreeSpace: {allDrives.Item1:N}");
                Console.WriteLine($"BusySpace: {(allDrives.Item2 - allDrives.Item1):N}");
                Console.WriteLine($"Size: {entity["Size"]:N}");
                Console.WriteLine($"InterfaceType: {entity["InterfaceType"]}");
                Console.WriteLine(
                    $"CapabilityDescriptions: {(entity["CapabilityDescriptions"] as IEnumerable<string>).Aggregate((l, r) => $"{l.ToString()}; {r.ToString()}")}");
                Console.WriteLine("------------------------------------------------------------------");
            }
        }
    }
}
