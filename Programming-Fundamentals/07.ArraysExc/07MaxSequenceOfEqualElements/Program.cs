using System;
using System.Linq;

namespace _07MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int count = 1;
            int sequence = 0;
            string s = string.Empty;

            string biggestSequence= string.Empty;

            for (int i = 0; i < arr.Length-1; i++)
            {
                
                if (arr[i] == arr[i + 1])
                {
                    count++;
                    s = s + $"{arr[i].ToString()} ";
                    if (count > sequence)
                    {
                        biggestSequence = s+arr[i].ToString();
                        sequence = count;
                    }
                }
                else
                {
                    s = string.Empty;
                    count = 1;
                }
            }

            Console.WriteLine(biggestSequence);
        }
    }
}
