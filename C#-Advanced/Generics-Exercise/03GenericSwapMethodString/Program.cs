using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<string>> boxList = new List<Box<string>>();

            for (int i = 0; i < n; i++)
            {
                Box<string> currBox = new Box<string>(Console.ReadLine());
                boxList.Add(currBox);
            }
            int[] indexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int firstIndex = indexes[0];
            int secondIndex = indexes[1];

            SwapIndexes(boxList,firstIndex,secondIndex);

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
