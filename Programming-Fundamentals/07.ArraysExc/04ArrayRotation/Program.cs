using System;
using System.Linq;

namespace _04ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotations; i++)
            {
                for (int z = 0; z < arr.Length-1; z++)
                {
                    int firstNum = arr[z];
                    arr[z] = arr[z + 1];
                    arr[z+1] = firstNum;
                }
                
            }

            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
