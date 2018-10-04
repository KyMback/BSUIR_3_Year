using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab_1.Services.Utils;

namespace Lab_1.Services.PackageForming
{
    public class PackingService
    {
        public byte[] GetFormedPackage(PackageInfo packageInfo)
        {
            return GetPackageBody(packageInfo).ToArray();
        }

        private IEnumerable<byte> GetPackageBody(PackageInfo packageInfo)
        {
            return new List<byte>
            {
                GetDestinationAddress(packageInfo),
                GetSourceAddress(packageInfo)
            }
                .Concat(GetDataWithSize(packageInfo))
                .Append(PackageUtils.DefaultEndByte);
        }

        private IEnumerable<byte> GetDataWithSize(PackageInfo packageInfo)
        {
            IEnumerable<byte> message = GetMessageBytes(packageInfo);
            return message.Append((byte) message.Count());
        }

        private IEnumerable<byte> GetMessageBytes(PackageInfo packageInfo)
        {
            return Encoding.ASCII.GetBytes(packageInfo.Message);
        }

        private byte GetDestinationAddress(PackageInfo packageInfo)
        {
            return packageInfo.DestinationAddress;
        }

        private byte GetSourceAddress(PackageInfo packageInfo)
        {
            return packageInfo.SourceAddress;
        }
    }
}
