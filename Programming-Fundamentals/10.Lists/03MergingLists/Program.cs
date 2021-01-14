using System;
using System.Collections.Generic;
using System.Linq;

namespace _03MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> secondList = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int count = FindLongerCount(firstList, secondList);

            List<int> newList = new List<int>(count*2);

            for (int i = 0; i < count; i++)
            {
                newList.Add(firstList[i]);
                newList.Add(secondList[i]);
            }

            newList = AddRemainingitems(firstList, secondList, newList);

            Console.WriteLine(string.Join(" ", newList));

        }

        static int FindLongerCount(List<int> firstList, List<int> secondList)
        {
            int count = 0;
            if (firstList.Count <= secondList.Count)
            {
                count = firstList.Count;
            }
            else
            {
                count = secondList.Count;
            }
            return count;
        }

        static List<int> AddRemainingitems(List<int> firstList, List<int> secondList, List<int> newList)
        {
            if (firstList.Count <= secondList.Count)
            {
                for (int i = firstList.Count; i < secondList.Count; i++)
                {
                    newList.Add(secondList[i]);
                }
            }
            else
            {
                for (int i = secondList.Count; i < firstList.Count; i++)
                {
                    newList.Add(firstList[i]);
                }
            }

            return newList;
        }
    }
}
