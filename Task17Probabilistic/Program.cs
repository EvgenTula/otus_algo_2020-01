using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Task17Probabilistic
{
    class Program
    {        
        static void Main(string[] args)
        {

            double countItem = 100_000;      //  N
            double rate = 0.02;              //  p

            Random random = new Random();
            HashSet<byte[]> data = new HashSet<byte[]>();
            int byteSize = 0;
            while (data.Count < countItem)
            {
                byte[] chunk = new byte[random.Next(100)];
                byteSize += chunk.Length;
                random.NextBytes(chunk);                
                data.Add(chunk);
            }

            int falsePositive = 0;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                BloomFilter bloomFilter = new BloomFilter(countItem, rate, sha256Hash);
                var index = data.GetEnumerator();
                for(int i = 0; i < data.Count; i++)
                {
                    index.MoveNext();
                    var chunk = index.Current;
                    if (bloomFilter.constains(chunk))
                        falsePositive++;
                    bloomFilter.add(index.Current);
                }

                Console.WriteLine("bloomFilter size:\t" + bloomFilter.getSize());
                Console.WriteLine("data size:\t\t" + byteSize);
            }


            Console.WriteLine("Percent error: " + falsePositive / countItem * 100 + "%");
            Console.ReadKey();
        }
    }
}
