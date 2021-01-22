using System;
using System.Linq;

namespace _5SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int biggestSquare = int.MinValue;
            int biggestRow = 0;
            int biggestCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currSquaereSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (currSquaereSum > biggestSquare)
                    {
                        biggestSquare = currSquaereSum;
                        biggestRow = row;
                        biggestCol = col;
                    }
                }
            }

            for (int row = biggestRow; row < biggestRow + 2; row++)
            {
                for (int col = biggestCol; col < biggestCol + 2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(biggestSquare);
        }
    }
}
