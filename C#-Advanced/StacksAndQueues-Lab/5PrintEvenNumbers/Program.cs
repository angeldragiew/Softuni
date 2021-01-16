using System;
using System.Collections.Generic;
using System.Linq;

namespace _5PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> evenNumbers = new Queue<int>(numbers);
            int count = evenNumbers.Count;

            for (int i = 0; i < count; i++)
            {
                if (evenNumbers.Peek() % 2 == 0)
                {
                    evenNumbers.Enqueue(evenNumbers.Dequeue());
                }
                else
                {
                    evenNumbers.Dequeue();
                }
            }

            Console.WriteLine(string.Join(", ", evenNumbers.ToList()));
        }
    }
}
