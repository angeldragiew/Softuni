using System;
using System.Collections.Generic;
using System.Linq;
namespace _02AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> gradebook = new Dictionary<string, List<decimal>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!gradebook.ContainsKey(name))
                {
                    gradebook.Add(name, new List<decimal>());
                }
                gradebook[name].Add(grade);
            }

            foreach (var name in gradebook)
            {
                Console.Write($"{name.Key} -> ");
                foreach (var grade in name.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.WriteLine($"(avg: {name.Value.Average():f2})");
            }
        }
    }
}
