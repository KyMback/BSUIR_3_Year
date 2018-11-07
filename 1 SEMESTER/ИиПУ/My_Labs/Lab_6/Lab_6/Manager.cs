using System.Collections.Generic;
using System.IO;
using System.Linq;
using MediaDevices;

namespace Lab_6
{
    internal class Manager
    {
        public List<Usb> GetUsbs()
        {
            try
            {
                return GetUsbsInternal();
            }
            catch
            {
                return new List<Usb>();
            }
        }

        private List<Usb> GetUsbsInternal()
        {
            List<Usb> usbDevices = new List<Usb>();

            List<DriveInfo> diskDrives = DriveInfo.GetDrives()
                .Where(d => d.IsReady && d.DriveType == DriveType.Removable)
                .ToList();

            List<MediaDevice> mtpDrives = MediaDevice.GetDevices().ToList();

            foreach (var device in mtpDrives)
            {
                device.Connect();

                if (device.Protocol.Contains("MTP"))
                    usbDevices.Add(new Usb
                    {
                        DeviceName = device.FriendlyName,
                        FreeSpace = null,
                        UsedSpace = null,
                        TotalSpace = null,
                        IsMtpDevice = true
                    });
            }

            foreach (var drive in diskDrives)
            {
                usbDevices.Add(new Usb
                {
                    DeviceName = drive.Name,
                    FreeSpace = Convert(drive.TotalFreeSpace),
                    UsedSpace = Convert(drive.TotalSize - drive.TotalFreeSpace),
                    TotalSpace = Convert(drive.TotalSize),
                    IsMtpDevice = false
                });
            }

            return usbDevices;
        }

        private string Convert(long value)
        {
            double megaBytes = value / 1024 / 1024;
            return megaBytes + " mb";
        }
    }
}