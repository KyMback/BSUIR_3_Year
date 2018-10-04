using System;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using cmd;

namespace Lab_3
{
    public class Program
    {
        public PowerLineStatus PowerLineStatus { get; private set; }

        public float BatteryLifePercent { get; private set; }

        public static void Main(string[] args)
        {
            var program = new Program();
            
            while (true)
            {
                program.WriteStatus(SystemInformation.PowerStatus.PowerLineStatus,
                    SystemInformation.PowerStatus.BatteryLifePercent);
            }
        }

        private string GetChargeSafeType()
        {
            dynamic cmd = new Cmd();
            var regex = new Regex(@"[(](?<type>\w*).*[*]");
            MatchCollection matches = regex.Matches(cmd.powercfg("-l").ToString());

            StringBuilder builder = new StringBuilder();
            for (int i = 1; i < matches.Count; i++)
            {
                builder.Append(matches[i].Groups["type"].Value);
            }

            return builder.ToString();
        }

        private void WriteStatus(PowerLineStatus status, float batteryLifePercent)
        {
            if (PowerLineStatus == status && BatteryLifePercent == batteryLifePercent)
            {
                Thread.Sleep(1000);
                return;
            }
            Console.Clear();
            Console.WriteLine(GetChargeSafeType());
            Console.WriteLine($"Power supply type: {GetPowerSupplyType(status)}");
            Console.WriteLine($"Battery level: {batteryLifePercent:P}");
            
            BatteryLifePercent = batteryLifePercent;
            PowerLineStatus = status;
        }



        private static string GetPowerSupplyType(PowerLineStatus status)
        {
            switch (status)
            {
                    case PowerLineStatus.Offline: return "Battery";
                    case PowerLineStatus.Online: return "External power";
                    default: throw new InvalidEnumArgumentException("Not supported power supply type");
            }
        }
    }
}