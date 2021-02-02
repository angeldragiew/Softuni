using System;
using System.Collections.Generic;
using System.Linq;

namespace _09ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());
            List<int> dividers = Console.ReadLine().Split().Select(int.Parse).ToList();

            Func<int, List<int>, bool> divisibleByAll = (n, dividers) =>
            {
                if (dividers.All(d => n % d == 0))
                {
                    return true;
                }
                return false;
            };

            Func<int, List<int>> fillList = end =>
              {
                  List<int> list = new List<int>();
                  for (int i = 0; i < end; i++)
                  {
                      int currNum = i + 1;
                      if (divisibleByAll(currNum, dividers))
                      {
                          list.Add(currNum);
                      }
                  }
                  return list;
              };

            List<int> numbers = fillList(end);
            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
