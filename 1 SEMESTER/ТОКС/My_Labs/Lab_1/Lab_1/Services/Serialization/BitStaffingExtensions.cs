using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab_1.Services.Serialization
{
    public static class BitStaffingExtensions
    {
        public static IList<bool> BytesToBits(this byte[] bytes)
        {
            BitArray array = new BitArray(bytes);
            var resultList = new List<bool>();
            foreach (bool b in array)
            {
                resultList.Add(b);
            }

            return resultList;
        }

        public static byte[] BitsToBytes(this IList<bool> bits)
        {
            BitArray bitsArray = new BitArray(bits.ToArray());

            byte[] result = new byte[bits.Count / 8];
            bitsArray.CopyTo(result, 0);
            return result;
        }

        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}
