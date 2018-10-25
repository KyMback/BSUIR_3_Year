using System.Collections.Generic;
using System.Linq;

namespace Lab_1.Services.Serialization
{
    public static class PackageSerializator
    {
        public static byte[] SerializePackage(PackageInfo packageInfo)
        {
            List<byte> result = new List<byte> {SystemSettings.StartFlag};

            result.AddRange(GetBody(packageInfo));
            result.Add(SystemSettings.EndFlag);

            return result.ToArray();
        }

        private static byte[] GetBody(PackageInfo packageInfo)
        {
            var sourceList = new List<byte>
            {
                packageInfo.DestinationAddress,
                packageInfo.SourceAddress,
                (byte) packageInfo.Message.Length
            };
            sourceList.AddRange(packageInfo.Message);

            return BitStaffing(sourceList.ToArray());
        }

        private static byte[] BitStaffing(byte[] sourceCollection)
        {
            IList<bool> result = sourceCollection.BytesToBits();

            int count = 0;
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i])
                {
                    count++;
                }
                else
                {
                    count = 0;
                }

                if (count == 2)
                {
                    result.Insert(i, true);
                    count = 0;
                    i++;
                }
            }

            return NormalizeBytePackage(result).BitsToBytes().ToArray();
        }

        private static IList<bool> NormalizeBytePackage(IList<bool> bitCollection)
        {
            int neededBits = 8 - bitCollection.Count % 8;
            if (neededBits == 8)
            {
                return bitCollection;
            }

            for (int i = 0; i < neededBits; i++)
            {
                bitCollection.Add(false);
            }

            return bitCollection;
        }
    }
}
