using System;
using System.Collections.Generic;
using System.Linq;

namespace _8Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] field = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    field[row, col] = rowData[col];
                }
            }

            string[] bombsCordinates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            for (int i = 0; i < bombsCordinates.Length; i++)
            {
                string[] cordinates = bombsCordinates[i].Split(',', StringSplitOptions.RemoveEmptyEntries).ToArray();
                int row = int.Parse(cordinates[0]);
                int col = int.Parse(cordinates[1]);
                Explode(row, col, field);

            }

            int sum = 0;
            int activeCells = 0;

            foreach (var item in field)
            {
                if (item > 0)
                {
                    sum += item;
                    activeCells++;
                }
            }

            Console.WriteLine($"Alive cells: {activeCells}");
            Console.WriteLine($"Sum: {sum}");
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write($"{field[row, col]} ");

                }
                Console.WriteLine();
            }

        }

        public static void Explode(int row, int col, int[,] field)
        {
            int power = field[row, col];

            for (int currRow = row - 1; currRow <= row + 1; currRow++)
            {
                for (int currCol = col - 1; currCol <= col + 1; currCol++)
                {
                    if (currRow >= 0 && currRow < field.GetLength(0) && currCol >= 0 && currCol < field.GetLength(1))
                    {
                        if (field[currRow, currCol] <= 0 || power < 0)
                        {
                            continue;
                        }
                        field[currRow, currCol] -= power;
                    }

                }
            }
        }
    }
}