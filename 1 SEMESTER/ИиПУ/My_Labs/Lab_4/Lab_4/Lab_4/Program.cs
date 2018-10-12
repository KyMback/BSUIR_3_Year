using System;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;

namespace Lab_4
{
    public class Program
    {
        private const int SW_HIDE = 0;

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private static void Main()
        {
            ManagementObjectSearcher search = new ManagementObjectSearcher("SELECT * From Win32_PnPEntity");
            var webcams = search.Get().Cast<ManagementBaseObject>().Select(c => new
            {
                Caption = Convert.ToString(c["Caption"]),
                Manufacturer = Convert.ToString(c["Manufacturer"]),
                DeviceId = Convert.ToString(c["DeviceId"]),
                Name = Convert.ToString(c["Name"])
            }).Where(w => w.Caption.Contains("Camera")).ToArray();
            var webcam = webcams
                .First(w => w.Caption.Contains("RGB"));
            
            Console.WriteLine($"Caption : {webcam.Caption}");
            Console.WriteLine($"Device Id : {webcam.DeviceId}");
            Console.WriteLine($"Name : {webcam.Name}");
            Console.WriteLine($"Manufacturer : {webcam.Manufacturer}");

            var capture = new VideoCapture(1);
            Console.WriteLine($"Width of camera : {Convert.ToInt32(capture.GetCaptureProperty(CapProp.FrameWidth))}");
            Console.WriteLine($"Height of camera : {Convert.ToInt32(capture.GetCaptureProperty(CapProp.FrameHeight))}");
            capture.Dispose();

            HideApp();
            Application.Run(new VideoSpyAdapter());
        }

        private static void HideApp()
        {
            Console.WriteLine("Press any key to hide console window");
            Console.ReadKey();
            IntPtr handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
        }
    }
}