using System;
using System.Linq;

namespace _6Jagged_ArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[][] jagged = new int[n][];

            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                int[] rowsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jagged[row] = new int[n];
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    jagged[row][col] = rowsInput[col];
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = input.Split().ToArray();

                string command = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if (row >= 0 && col >= 0 && row < jagged.GetLength(0) && col < jagged[row].Length)
                {
                    if (command == "Add")
                    {
                        jagged[row][col] += value;
                    }
                    else
                    {
                        jagged[row][col] -= value;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }

            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(" ", jagged[row]));
            }
        }
    }
}
