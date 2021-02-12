using System;
using System.Collections.Generic;

namespace GenericCountMethodString
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> stringList = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string currString = Console.ReadLine(); ;
                stringList.Add(currString);
            }

            Box<string> element = new Box<string>(Console.ReadLine());
            Console.WriteLine(CountGreaterElements(stringList, element));
        }

        private static int CountGreaterElements<T>(List<T> list, Box<T> element)
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
