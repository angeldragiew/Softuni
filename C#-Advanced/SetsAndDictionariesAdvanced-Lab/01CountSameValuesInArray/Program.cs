using System;
using System.Collections.Generic;
using System.Linq;

namespace _01CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> values = new Dictionary<double, int>();

            double[] numbersInput = Console.ReadLine().Split().Select(double.Parse).ToArray();

            for (int i = 0; i < numbersInput.Length; i++)
            {
                double currNumber = numbersInput[i];

                if (!values.ContainsKey(currNumber))
                {
                    values.Add(currNumber, 0);
                }
                values[currNumber]++;
            }

            foreach (var number in values)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
