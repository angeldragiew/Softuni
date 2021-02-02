using System;
using System.Collections.Generic;
using System.Linq;

namespace _05AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            Func<int, int> func = num => num;
            Action<List<int>> printNumbers = l => Console.WriteLine(string.Join(" ", l));

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "print")
                {
                    printNumbers(numbers);
                    continue;
                }
                func = GetArithmeticFunction(input);
                numbers = numbers.Select(func).ToList();
            }
        }

        static Func<int, int> GetArithmeticFunction(string command)
        {
            Func<int, int> func = num => num;
            if (command == "add")
            {
                func = n => n + 1;
            }
            else if (command == "multiply")
            {
                func = n => n * 2;
            }
            else if (command == "subtract")
            {
                func = n => n - 1;
            }
            return func;
        }

    }
}
