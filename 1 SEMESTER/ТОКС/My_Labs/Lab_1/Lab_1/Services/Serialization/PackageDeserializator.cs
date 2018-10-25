using System.Collections.Generic;
using System.Linq;

namespace Lab_1.Services.Serialization
{
    public static class PackageDeserializator
    {
        public static PackageInfo DeserializePackage(byte[] bytes)
        {
            byte[] body = bytes.SubArray(1, bytes.Length - 2);

            byte[] unencodedBody = GetUnencodedBytes(body);
            var packageInfo = new PackageInfo
            {
                DestinationAddress = unencodedBody[0],
                SourceAddress = unencodedBody[1],
                Message = unencodedBody.SubArray(3, unencodedBody.Length - 3)
            };

            return packageInfo;
        }

        private static byte[] GetUnencodedBytes(byte[] sourceBytes)
        {
            IList<bool> bits = sourceBytes.BytesToBits();

            int count = 0;
            for (int i = 0; i < bits.Count; i++)
            {
                if (bits[i])
                {
                    count++;
                }
                else
                {
                    count = 0;
                }

                if (count == 3)
                {
                    bits.RemoveAt(i);
                    i--;
                    count = 0;
                }
            }

            return NormalizeBitePackage(bits).BitsToBytes();
        }

        private static IList<bool> NormalizeBitePackage(IList<bool> bitCollection)
        {
            int neededBits = bitCollection.Count % 8;
            if (neededBits == 0)
            {
                return bitCollection;
            }

            return bitCollection.ToArray().SubArray(0, bitCollection.Count - neededBits);
        }
    }
}
