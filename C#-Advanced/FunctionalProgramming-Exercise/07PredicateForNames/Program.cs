using System;
using System.Linq;

namespace _07PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxLenght = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<string, int, bool> filter = (name, length) => name.Length <= length;
            names = names.Where(n => filter(n, maxLenght)).ToArray();

            Action<string[]> printArray = arr => Console.WriteLine(string.Join(Environment.NewLine, arr));
            printArray(names);
        }
    }
}
