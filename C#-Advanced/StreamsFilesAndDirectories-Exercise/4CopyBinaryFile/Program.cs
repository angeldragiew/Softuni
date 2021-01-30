using System;
using System.IO;

namespace _4CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using FileStream readStream = new FileStream("../../../copyMe.png", FileMode.Open);
            using FileStream writeStream = new FileStream("../../../newCopy.png", FileMode.Create);

            while (readStream.Position != readStream.Length)
            {
                byte[] buffer = new byte[4096];
                readStream.Read(buffer, 0, buffer.Length);
                writeStream.Write(buffer);
            }
        }
    }
}
