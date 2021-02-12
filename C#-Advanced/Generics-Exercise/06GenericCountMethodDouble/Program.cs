using System;
using System.Collections.Generic;

namespace GenericCountMethodDouble
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Box<double>> doubleList = new List<Box<double>>();
            for (int i = 0; i < n; i++)
            {
                Box<double> currBox = new Box<double>(double.Parse(Console.ReadLine()));
                doubleList.Add(currBox);
            }

            Box<double> element = new Box<double>(double.Parse(Console.ReadLine()));
            Console.WriteLine(CountGreaterElements(doubleList, element));
        }


        private static int CountGreaterElements<T>(List<Box<T>> list, Box<T> element)
            where T : IComparable
        {
            int count = 0;
            foreach (var item in list)
            {
                if (element.Compare(item) < 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
