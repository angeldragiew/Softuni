using System;
using System.Linq;

namespace _4SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] charMatrix = new char[size, size];

            for (int row = 0; row < charMatrix.GetLength(0); row++)
            {
                string charsInput = Console.ReadLine();
                for (int col = 0; col < charMatrix.GetLength(1); col++)
                {
                    charMatrix[row, col] = charsInput[col];
                }
            }
            char symbol = char.Parse(Console.ReadLine());
            bool isFound = false;

            for (int row = 0; row < charMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < charMatrix.GetLength(1); col++)
                {
                    if(charMatrix[row,col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        isFound = true;
                        break;
                    }
                }
                if (isFound)
                {
                    break;
                }
            }

            if (!isFound)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
