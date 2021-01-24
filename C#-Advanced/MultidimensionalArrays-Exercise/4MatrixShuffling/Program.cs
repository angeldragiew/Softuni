using System;
using System.Linq;

namespace _4MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string[,] matrix = new string[size[0], size[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = input.Split().ToArray();

                if (cmdArgs.Length != 5 || cmdArgs[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int firstRow = int.Parse(cmdArgs[1]);
                int firstCol = int.Parse(cmdArgs[2]);
                int secondRow = int.Parse(cmdArgs[3]);
                int secondCol = int.Parse(cmdArgs[4]);

                bool isValidIndex = firstRow >= 0 && firstRow < matrix.GetLength(0)
                    && secondRow >= 0 && secondRow < matrix.GetLength(0)
                    && firstCol >= 0 && firstCol < matrix.GetLength(1)
                    && secondCol >= 0 && secondCol < matrix.GetLength(1);
                if (isValidIndex)
                {
                    string firstValue = matrix[firstRow, firstCol];
                    matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
                    matrix[secondRow, secondCol] = firstValue;
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write(matrix[row, col] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
