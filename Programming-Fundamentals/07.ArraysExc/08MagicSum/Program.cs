using System;
using System.Linq;

namespace _08MagicSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < arr.Length; i++)
            {
                for (int z = i+1; z < arr.Length; z++)
                {
                    if (arr[i] + arr[z] == num)
                    {
                        Console.WriteLine($"{arr[i]} {arr[z]}");
                    }
                }
            }
        }
    }
}
