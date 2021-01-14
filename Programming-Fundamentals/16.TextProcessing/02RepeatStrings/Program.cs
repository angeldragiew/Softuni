using System;
using System.Linq;
using System.Text;

namespace _02RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                .Split()
                .ToArray();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < arr.Length; i++)
            {
                int currWordLength = arr[i].Length;

                for (int z = 0; z < currWordLength; z++)
                {
                    sb.Append(arr[i]);
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
