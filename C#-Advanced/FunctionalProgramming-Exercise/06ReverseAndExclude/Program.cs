using System;
using System.Collections.Generic;
using System.Linq;

namespace _06ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int divisor = int.Parse(Console.ReadLine());

            Func<List<int>, List<int>> reverseList = l =>
            {
                List<int> reversedList = new List<int>();
                for (int i = l.Count - 1; i >= 0; i--)
                {
                    reversedList.Add(l[i]);
                }
                return reversedList;
            };

            numbers = reverseList(numbers);

            Func<int, bool> nonDivisibleBy = n => n % divisor != 0;
            numbers = numbers.Where(nonDivisibleBy).ToList();
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
