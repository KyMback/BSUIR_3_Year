using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_1.Services.Serialization
{
    public static class PackageBuilder
    {
        public static byte[] BuildPackage(PackageInfo packageInfo)
        {
            var bodyData = new List<byte>();

            bodyData.Add(packageInfo.DestinationAddress);
            bodyData.Add(packageInfo.SourceAddress);
            bodyData.Add((byte)packageInfo.Message.Length);
            bodyData.AddRange(Encoding.ASCII.GetBytes(packageInfo.Message));

            var result = new List<byte>(SystemSettings.DefaultStartValue);
            result.AddRange(GetBitStaffedBytes(bodyData.ToArray()));
            result.Add(SystemSettings.DefaultEndValue);

            return result.ToArray();
        }

        private static byte[] GetBitStaffedBytes(byte[] dataBytes)
        {
            var bitArray = new BitArray(dataBytes);

            bitArray.
        }

        private static IEnumerable<bool> FromByteToBoolArray(byte b)
        {

        }
    }
}
