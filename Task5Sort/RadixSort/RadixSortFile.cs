using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task5Sort
{
    public class RadixSortFile : IDisposable
    {
        private FileStream fileStream;
        private string resultFile;
        private int maxRadix;
        private int itemCount;

        public RadixSortFile(string filePath, int itemCount)
        {
            this.itemCount = itemCount;
            this.maxRadix = 5;
            
            resultFile = filePath.Replace(".in", ".out") + "_radixSortFileResult" + itemCount;

            //string resultFileArr = filePath + "_mergeSortFileResultArr" + itemCount;
            if (File.Exists(resultFile))
            {
                File.Delete(resultFile);
                //File.Delete(resultFileArr);
            }
            File.Copy(filePath, resultFile);
            fileStream = File.Open(resultFile, FileMode.Open);
            
        }

        public void sort()
        {
            RadixSort();
        }


        private void RadixSort()
        {           
            for (int i = maxRadix - 1; i >= 0; i--)
            {
                MemoryStream memoryStream = new MemoryStream();
                int[] radix = new int[10];
                for (int j = 0; j < this.itemCount; j++)
                {
                    String num = fileStream.GetValue(j).ToString("D" + maxRadix);                    
                    radix[Int32.Parse(num[i].ToString())]++;
                }

                for (int j = 1; j < radix.Length; j++)
                {
                    radix[j] = radix[j] + radix[j - 1];
                }

                for (int j = itemCount - 1; j >= 0; j--)
                {
                    String num = fileStream.GetValue(j).ToString("D" + maxRadix);
                    
                    radix[Int32.Parse(num[i].ToString())]--;
                    memoryStream.Insert(radix[Int32.Parse(num[i].ToString())], fileStream.GetValue(j));
                }

                for(int j = 0; j < itemCount; j++)
                {
                    fileStream.Insert(j, memoryStream.GetValue(j));
                }

                memoryStream.Close();
            }
        }

        public void Dispose()
        {
            fileStream.Close();
        }

    }
}
