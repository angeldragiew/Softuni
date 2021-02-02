using System;
using System.Collections.Generic;
using System.Linq;

namespace _04FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int start = range[0];
            int end = range[1];
            string condition = Console.ReadLine();

            Predicate<int> filter = null;
            if (condition == "even")
            {
                filter = n => n % 2 == 0;
            }
            else if (condition == "odd")
            {
                filter = n => n % 2 != 0;
            }

            List<int> filteredNumbers = new List<int>();
            for (int i = start; i <= end; i++)
            {
                if (filter(i))
                {
                    filteredNumbers.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", filteredNumbers));
        }
    }
}
