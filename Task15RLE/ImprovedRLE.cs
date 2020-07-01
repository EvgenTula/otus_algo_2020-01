using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Task15RLE
{
    public class ImprovedRLE : ICompressor
    {
        public byte[] compress(byte[] array)
        {
            List<byte> compressed = new List<byte>();

            int i = 0;
            while (i < array.Length)
            {
                byte data = (byte)array[i++];
                sbyte count = 1;
                while (i < array.Length && count <= sbyte.MaxValue && data == array[i])
                {
                    i++;
                    count++;
                }
                compressed.Add((byte)count);
                compressed.Add(data);
            }

            
            int j = 0;
            int beginIndex;
            while(j < compressed.Count)
            {
                List<byte> unique = new List<byte>(sbyte.MaxValue);
                beginIndex = j;
                while (j < compressed.Count - 1 && unique.Count < unique.Capacity && compressed[j] == (byte)1)
                {
                    unique.Add(compressed[j + 1]);
                    j += 2;
                }
                if (unique.Count > 0)
                {
                    compressed.RemoveRange(beginIndex, j - beginIndex);
                    j = beginIndex;
                    compressed.Insert(beginIndex, (byte)((-1) * unique.Count));
                    compressed.InsertRange(beginIndex + 1, unique);
                    j = j + 1 + unique.Count;                    
                }
                else
                {
                    j += 2;
                }
            }
            return compressed.ToArray();
        }

        public byte[] decompress(byte[] array)
        {
            
            List<byte> decompressed = new List<byte>();            
            for (int i = 0; i < array.Length - 1; i = i + 2)
            {
                byte count = array[i];
                if (count > sbyte.MaxValue)
                {
                    sbyte cnt = (sbyte)count;
                    cnt *= -1;
                    while (cnt > 0)
                    {
                        i++;
                        decompressed.Add(array[i]);
                        cnt--;
                    }
                    i--;
                }                
                else
                {
                    while (count > 0)
                    {
                        decompressed.Add(array[i + 1]);
                        count--;
                    }
                }
            }
            return decompressed.ToArray();
        }
    }
}
