using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodInteger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<int>> boxList = new List<Box<int>>();

            for (int i = 0; i < n; i++)
            {
                Box<int> currBox = new Box<int>(int.Parse(Console.ReadLine()));
                boxList.Add(currBox);
            }
            int[] indexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            SwapIndexes(boxList, firstIndex, secondIndex);

            foreach (var box in boxList)
            {
                Console.WriteLine(box.ToString());
            }
        }

        private static void SwapIndexes<T>(List<Box<T>> boxList, int firstIndex, int secondIndex)
        {
            Box<T> firstBox = boxList[firstIndex];
            boxList[firstIndex] = boxList[secondIndex];
            boxList[secondIndex] = firstBox;
        }
    }
}
