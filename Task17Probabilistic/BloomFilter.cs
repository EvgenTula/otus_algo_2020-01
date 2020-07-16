using System;
using System.Collections;
using System.Security.Cryptography;

namespace Task17Probabilistic
{
    public class BloomFilter
    {
        long size = 0; //M
        int hashCount = 0; //k
        BitArray BitArray;
        HashAlgorithm hashAlgorithm;
        public BloomFilter(double n, double p, HashAlgorithm algorithm)
        {
            size = (long)Math.Ceiling(-n * (Math.Log2(p) / Math.Log(2)));
            hashCount = (int)Math.Ceiling(size / n * Math.Log(2));
            BitArray = new BitArray((int)size);
            hashAlgorithm = algorithm;
        }

        public void add(byte[] data)
        {
            var hash1 = GetHash(data);
            var hash2 = GetHash(hash1);
            for(int i = 0; i < hashCount; i++)
            {                
                int position = (int)Math.Abs((hash1 + i * hash2) % size);
                BitArray.Set(position, true);
            }
        }

        public bool constains(byte[] data)
        {
            var hash1 = GetHash(data);
            var hash2 = GetHash(hash1);
            for (int i = 0; i < hashCount; i++)
            {
                int position = (int)Math.Abs((hash1 + i * hash2) % size);
                if (!BitArray.Get(position))
                    return false;
            }
            return true;
        }

        public int getSize()
        {
            return BitArray.Length;
        }

        private int GetHash(byte[] data)
        {
            var hashValue = hashAlgorithm.ComputeHash(data);
            return BitConverter.ToInt32(hashValue);
        }

        private int GetHash(int data)
        {
            return GetHash(BitConverter.GetBytes(data));
        }
    }
}
