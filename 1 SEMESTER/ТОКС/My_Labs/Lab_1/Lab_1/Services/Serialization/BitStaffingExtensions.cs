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
            var resultList = new List<bool>();
            foreach (byte b in bytes)
            {
                resultList.AddRange(b.ByteToBit());
            }

            return resultList;
        }

        public static IList<bool> ByteToBit(this byte @byte)
        {
            BitArray array = new BitArray(new [] { @byte });
            var resultList = new List<bool>();
            foreach (bool b in array)
            {
                resultList.Add(b);
            }

            resultList.Reverse();
            return resultList;
        }

        public static byte[] BitsToBytes(this IList<bool> bits)
        {
            var array = new List<bool>();
            for (int i = 0; i < bits.Count; i+=8)
            {
                array.AddRange(bits.Skip(i).Take(8).Reverse());
            }

            BitArray bitsArray = new BitArray(array.ToArray());

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
