using System;
using System.IO;

namespace Task15RLE
{
    public interface ICompressor
    {
        public void Compress(string inFile, string outFile)
        {
            Stream destination;
            var data = File.ReadAllBytes(inFile);            
            using (destination = File.Create(outFile))
            {                   
                var compressedData = compress(data);
                destination.Write(compressedData, 0, compressedData.Length);
            }            
        }
        public void Decompress(string inFile, string outFile)
        {            
            Stream destination;
            var data = File.ReadAllBytes(inFile);
            using (destination = File.Create(outFile))
            {               
                var decompressedData = decompress(data);
                destination.Write(decompressedData, 0, decompressedData.Length);                
            }
        }

        public byte[] compress(byte[] array);
        public byte[] decompress(byte[] array);


    }
}