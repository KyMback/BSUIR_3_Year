using System.Linq;
using UsbEject;

namespace Lab_6
{
    internal class Usb
    {
        public string DeviceName { get; set; }
        public string FreeSpace { get; set; }
        public string UsedSpace { get; set; }
        public string TotalSpace { get; set; }
        public bool IsMtpDevice { get; set; }

        public bool EjectDevice()
        {
            try
            {
                var tempName = DeviceName.Remove(2);
                var ejectedDevice = new VolumeDeviceClass().SingleOrDefault(v => v.LogicalDrive == tempName);
                if (!IsMtpDevice)
                {
                    ejectedDevice.Eject(false);
                    ejectedDevice = new VolumeDeviceClass().SingleOrDefault(v => v.LogicalDrive == tempName);
                }
                else
                {
                    return false;
                }

                return ejectedDevice == null;
            }
            catch
            {
                return false;
            }
        }
    }
}