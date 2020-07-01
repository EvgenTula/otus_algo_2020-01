using System.Diagnostics;
using System.IO;

namespace Task15RLE
{
    public class Archiver
    {
        private ICompressor _compressor;
        public Archiver(ICompressor compressor)
        {
            _compressor = compressor;
        }

        public string Compress(string inFile, string outFile)
        {
            Stopwatch sw = Stopwatch.StartNew();
            _compressor.Compress(inFile, outFile);
            sw.Stop();
            return GetFileInfo(inFile) + "\n" + GetFileInfo(outFile) + "\ntime: " + sw.ElapsedMilliseconds;            
        }

        public string Decompress(string inFile, string outFile)
        {
            Stopwatch sw = Stopwatch.StartNew();
            _compressor.Decompress(inFile, outFile);
            sw.Stop();
            return GetFileInfo(inFile) + "\n" + GetFileInfo(outFile) + "\ntime: " + sw.ElapsedMilliseconds;
        }

        private string GetFileInfo(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            return "File name: " + fileInfo.Name + " size: " + fileInfo.Length;
        }        
    }
}
