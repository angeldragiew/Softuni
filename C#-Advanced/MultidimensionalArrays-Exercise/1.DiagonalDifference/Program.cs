using System;
using System.Linq;

namespace _1.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowsInput[col];
                }
            }

            int firstDiagonalSum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int col = row;
                firstDiagonalSum += matrix[row, col];
            }

            int secondDiagonalSum = 0;
            int column = matrix.GetLength(1) - 1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                secondDiagonalSum += matrix[row, column];
                column--;
            }

            Console.WriteLine(Math.Abs(firstDiagonalSum - secondDiagonalSum));
        }
    }
}
