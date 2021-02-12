using System;

namespace Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] firstInput = Console.ReadLine().Split(" ");
            string name = $"{firstInput[0]} {firstInput[1]}";
            string address = firstInput[2];
            CustomTuple<string, string> firstTuple = new CustomTuple<string, string>(name, address);

            string[] secondInput = Console.ReadLine().Split(" ");
            string secondName = secondInput[0];
            int litres = int.Parse(secondInput[1]);
            CustomTuple<string, int> secondTuple = new CustomTuple<string, int>(secondName, litres);

            string[] thirdInput = Console.ReadLine().Split(" ");
            int integerValue = int.Parse(thirdInput[0]);
            double doubleValue = double.Parse(thirdInput[1]);
            CustomTuple<int, double> thirdTuple = new CustomTuple<int, double>(integerValue, doubleValue);

            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);

        }
    }
}
