using System;
using System.IO;

namespace Task5Sort
{
    #region helper
    public static class StreamHelper
    {

        public static void Insert(this Stream ms, int itemIntex, ushort val)
        {
            ms.Position = itemIntex * 2;
            byte[] byteVal = BitConverter.GetBytes(val);
            ms.Write(byteVal, 0, byteVal.Length);            
        }

        public static void InsertByte(this Stream ms, int itemIntex, byte[] val)
        {
            ms.Position = itemIntex * 2;
            ms.Write(val, 0, val.Length);
        }

        public static ushort GetValue(this Stream fs, int itemIndex)
        {
            fs.Position = itemIndex * 2;
            byte[] data = new byte[2];
            fs.Read(data, 0, data.Length);
            return BitConverter.ToUInt16(data);
        }

        public static byte[] GetByte(this Stream fs, int itemIndex)
        {
            fs.Position = itemIndex * 2;
            byte[] data = new byte[2];
            fs.Read(data, 0, data.Length);
            return data;
        }
    }
    #endregion

}
