using System;
using System.Collections.Generic;
using System.Linq;

namespace _06ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input;
            while ((input=Console.ReadLine())!="end")
            {
                string[] tokens = input.Split();
                int num;
                int index;
                switch (tokens[0])
                {
                    case "Add":
                        num = int.Parse(tokens[1]);
                        nums.Add(num);
                        break;
                    case "Remove":
                        num = int.Parse(tokens[1]);
                        nums.Remove(num);
                        break;
                    case "RemoveAt":
                        index = int.Parse(tokens[1]);
                        nums.RemoveAt(index);
                        break;
                    case "Insert":
                        num = int.Parse(tokens[1]);
                        index = int.Parse(tokens[2]);
                        nums.Insert(index, num);
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
