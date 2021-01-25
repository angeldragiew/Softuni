using System;
using System.Collections.Generic;
using System.Linq;

namespace _5SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = dimensions[0];
            int m = dimensions[1];

            char[,] matrix = new char[n, m];
            string wordInput = Console.ReadLine();
            Queue<char> word = new Queue<char>(wordInput);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        char currChar = word.Peek();
                        matrix[row, col] = currChar;
                        word.Enqueue(word.Dequeue());
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        char currChar = word.Peek();
                        matrix[row, col] = currChar;
                        word.Enqueue(word.Dequeue());
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
