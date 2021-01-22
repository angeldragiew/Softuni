using System;

namespace _7.PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] pascalTriangle = new long[n][];

            for (int row = 0; row < pascalTriangle.GetLength(0); row++)
            {
                pascalTriangle[row] = new long[row + 1];
                for (int col = 0; col < pascalTriangle[row].Length; col++)
                {
                    if (row - 1 >= 0 && pascalTriangle[row-1].Length > col)
                    {
                        pascalTriangle[row][col] += pascalTriangle[row - 1][col];
                    }
                    if(row-1>=1 && col - 1 >= 0)
                    {
                        pascalTriangle[row][col] += pascalTriangle[row - 1][col-1];
                    }
                    if (pascalTriangle[row][col] == 0)
                    {
                        pascalTriangle[row][col] = 1;
                    }
                }
            }

            for (int row = 0; row < pascalTriangle.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(" ", pascalTriangle[row]));
            }
        }
    }
}
