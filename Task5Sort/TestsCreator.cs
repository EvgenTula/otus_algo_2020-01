using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task5Sort
{
    class TestsCreator
    {
        /// <summary>
        /// Создает файл с рандомизированным массивом
        /// </summary>
        /// <param name="size">размер массива</param>
        /// <param name="testNum">номер теста для системы тестирования</param>
        /// <param name="testFolder">путь к папке с тестами</param>
        /// <param name="createOriginalFile">нужно создавать не бинарные файлы ({test_file_name}_original)</param>
        public static void Create(int size, int testNum, string testFolder, bool createOriginalFile = false)
        {
            ushort[] arr = new ushort[size];
            Random random = new Random();
            String filePathIn = $"{testFolder}test.{testNum}.in";
            String filePathOut = $"{testFolder}test.{testNum}.out";
            if (File.Exists(filePathIn))
                File.Delete(filePathIn);
            if (File.Exists(filePathOut))
                File.Delete(filePathOut);

            StringBuilder stringBuilder = new StringBuilder();

            FileStream streamWriter = File.OpenWrite(filePathIn);
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = (ushort)random.Next(0, ushort.MaxValue);
                var val = BitConverter.GetBytes(arr[i]);
                streamWriter.Write(val, 0, val.Length);
                stringBuilder.Append(arr[i] + " ");
            }
            streamWriter.Close();

            if (createOriginalFile)
                File.AppendAllText(filePathIn+"_original", stringBuilder.ToString().TrimEnd());

            Array.Sort(arr);
            stringBuilder.Clear();
            streamWriter = File.OpenWrite(filePathOut);
            for (int i = 0; i < arr.Length; i++)
            {
                var val = BitConverter.GetBytes(arr[i]);
                streamWriter.Write(val, 0, val.Length);
                stringBuilder.Append(arr[i] + " ");
            }
            streamWriter.Close();
            if (createOriginalFile)
                File.AppendAllText(filePathOut + "_original", stringBuilder.ToString().TrimEnd());
        }
    }
}
