using System.Collections.Generic;

namespace Task15RLE
{
    public class RLE : ICompressor
    {        
        public byte[] compress(byte[] array)
        {
            List<byte> compressed = new List<byte>();

            int i = 0;
            while (i < array.Length)
            {
                byte data = array[i++];
                byte count = 1;                
                while(i < array.Length && count <= byte.MaxValue && data == array[i])
                {
                    i++;
                    count++;
                }                
                compressed.Add(count);
                compressed.Add(data);
            }

            return compressed.ToArray();
        }

        public byte[] decompress(byte[] array)
        {
            List<byte> decompressed = new List<byte>();
            for(int i = 0; i < array.Length - 1; i=i+2)
            {
                int count = array[i];
                while(count > 0)
                {
                    decompressed.Add(array[i + 1]);
                    count--;
                }                
            }
            return decompressed.ToArray();
        }
    }
}
