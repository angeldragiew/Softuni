using System;
using System.Collections.Generic;
using System.Linq;

namespace _12TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();
            Func<string, int, bool> func = (name, length) =>
            {
                int sum = 0;
                foreach (var ch in name)
                {
                    sum += ch;
                }
                return sum > length;
            };


            foreach (var name in names)
            {
                if (func(name, n))
                {
                    Console.WriteLine(name);
                    break;
                }
            }
        }
    }
}
