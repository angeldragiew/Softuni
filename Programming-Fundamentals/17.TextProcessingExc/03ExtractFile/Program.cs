using System;
using System.Linq;

namespace _03ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string fullPath = Console.ReadLine();

            int index = fullPath.LastIndexOf(@"\");

            string[] fileArgs = fullPath.Substring(index+1).Split(".", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Console.WriteLine($"File name: {fileArgs[0]}");
            Console.WriteLine($"File extension: {fileArgs[1]}");
        }
    }
}
