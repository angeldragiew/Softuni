using System;
using System.Linq;

namespace _6JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double[][] jagged = new double[n][];

            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                double[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                jagged[row] = rowData;
            }

            for (int row = 0; row < jagged.GetLength(0) - 1; row++)
            {
                if (jagged[row].Length == jagged[row + 1].Length)
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] *= 2;
                        jagged[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] /= 2;
                    }
                    for (int col = 0; col < jagged[row + 1].Length; col++)
                    {
                        jagged[row + 1][col] /= 2;
                    }
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = input.Split().ToArray();

                string command = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                double value = double.Parse(cmdArgs[3]);

                bool isValidIndex = row >= 0 && row < jagged.GetLength(0)
                    && col >= 0 && col < jagged[row].Length;

                if (isValidIndex && command == "Add")
                {
                    jagged[row][col] += value;
                }
                else if (isValidIndex && command == "Subtract")
                {
                    jagged[row][col] -= value;

                }
            }

            for (int row = 0; row < jagged.Length; row++)
            {
                Console.WriteLine(string.Join(" ", jagged[row]));
            }
        }
    }
}
