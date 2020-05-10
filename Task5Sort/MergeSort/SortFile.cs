using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task5Sort
{
    class SortFile : IDisposable
    {
        private FileStream fileStream;
        private string resultFile;
        private int itemCount;
        public SortFile(string filePath, int itemCount)
        {
            this.itemCount = itemCount;
            resultFile = filePath.Replace(".in", ".out") + "_mergeSortFileResult" + this.itemCount;

            //string resultFileArr = filePath + "_mergeSortFileResultArr" + itemCount;
            if (File.Exists(resultFile))
            {
                File.Delete(resultFile);
                //File.Delete(resultFileArr);
            }
            File.Copy(filePath, resultFile);
            fileStream = File.Open(resultFile, FileMode.Open);
        }
        public void MergreSort()
        {         
            mergesort(0, itemCount - 1);
            /*
            fileStream.Position = 0;
            while (fileStream.Position < fileStream.Length)
            {
                //fileStream.Position = i;
                byte[] data = new byte[2];
                fileStream.Read(data, 0, data.Length);
                ushort val = BitConverter.ToUInt16(data);
                File.AppendAllText(resultFileArr, val.ToString() + " ");
            }
            */
        }

        public void QuicksorMergetSort(int partFile)
        {
            int i = 0;
            while(i < itemCount-1)
            {
                if (i + partFile < itemCount-1)
                    quicksort(i, partFile);
                else
                    quicksort(i, itemCount-1);
                i += partFile;
            }
            MergreSort();
        }

        private void quicksort(int left, int right)
        {
            if (left >= right)
                return;
            int center = partition(left, right);
            quicksort(left, center - 1);
            quicksort(center + 1, right);
        }

        private int partition(int left, int right)
        {
            int i = left - 1;
            ushort pivot = fileStream.GetValue(right);
            for (int j = left; j <= right; j++)
            {
                if (fileStream.GetValue(j) <= pivot)
                {
                    i++;
                    ushort tmp = fileStream.GetValue(i);
                    fileStream.Insert(i, fileStream.GetValue(j));
                    fileStream.Insert(j, tmp);
                }
            }
            return i;
        }

        void mergesort(int left, int right)
        {
            if (left >= right)
                return;
            int center = left + (right - left) / 2;
            mergesort(left, center);
            mergesort(center + 1, right);
            merge(left, center, right);
        }

        void merge(int left, int center, int right)
        {
            int a = left;
            int b = center + 1;
            int r = 0;
            MemoryStream memoryStream = new MemoryStream();
            while (a <= center && b <= right)
            {
                ushort val1 = fileStream.GetValue(a);
                ushort val2 = fileStream.GetValue(b);
                if (val1 < val2)
                {
                    memoryStream.Insert(r++, val1);
                    a++;
                }
                else
                {
                    memoryStream.Insert(r++, val2);
                    b++;
                }
            }

            while (a <= center)
                memoryStream.Insert(r++, fileStream.GetValue(a++));
            while (b <= right)
                memoryStream.Insert(r++, fileStream.GetValue(b++));

            for (int i = left; i <= right; i++)
            {
                byte[] val = memoryStream.GetByte(i - left);
                fileStream.InsertByte(i, val);
            }
            memoryStream.Close();
        }

        public void Dispose()
        {
            fileStream.Close();
        }
    }
}
