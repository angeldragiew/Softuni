using System;
using System.Collections.Generic;
using System.Linq;

namespace _02Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            List<FlowerCoordinates> flowers = new List<FlowerCoordinates>();
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = dimensions[0];
            int m = dimensions[1];
            int[,] garden = new int[n, m];

            string command;
            while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] positionCoordinates = command.Split().Select(int.Parse).ToArray();
                int currRow = positionCoordinates[0];
                int currCol = positionCoordinates[1];

                if (IsPositionValid(currRow, currCol, garden))
                {
                    garden[currRow, currCol] = 1;
                    FlowerCoordinates currFlower = new FlowerCoordinates(currRow, currCol);
                    flowers.Add(currFlower);
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
            }

            foreach (var flower in flowers)
            {
                BloomUp(flower.Row, flower.Col, garden);
                BloomDown(flower.Row, flower.Col, garden);
                BloomLeft(flower.Row, flower.Col, garden);
                BloomRight(flower.Row, flower.Col, garden);
            }

            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    Console.Write(garden[row,col] + " ");
                }
                Console.WriteLine();
            }
        }

        class FlowerCoordinates
        {
            public FlowerCoordinates(int row, int col)
            {
                Row = row;
                Col = col;
            }
            public int Row { get; set; }
            public int Col { get; set; }
        }

        public static void BloomUp(int row, int col, int[,] garden)
        {
            row--;
            while (row >= 0)
            {
                garden[row, col]++;
                row--;
            }
        }

        public static void BloomDown(int row, int col, int[,] garden)
        {
            row++;
            while (row < garden.GetLength(0))
            {
                garden[row, col]++;
                row++;
            }
        }

        public static void BloomLeft(int row, int col, int[,] garden)
        {
            col--;
            while (col >=0)
            {
                garden[row, col]++;
                col--;
            }
        }

        public static void BloomRight(int row, int col, int[,] garden)
        {
            col++;
            while (col < garden.GetLength(1))
            {
                garden[row, col]++;
                col++;
            }
        }
        public static bool IsPositionValid(int row, int col, int[,] garden)
        {
            if (row >= 0 && row < garden.GetLength(0) && col >= 0 && col < garden.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}
