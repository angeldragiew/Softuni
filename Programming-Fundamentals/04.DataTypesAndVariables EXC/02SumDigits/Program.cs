using System;

namespace _02SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            //string input = Console.ReadLine();
            //int n1 = (int)Char.GetNumericValue(input[0]);
            //int n2 = int.Parse(input[1].ToString());
            //Console.WriteLine(n1+n2);


            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            int currNum = 0;
            while (number > 0)
            {
                currNum = number % 10;
                number /= 10;
                sum += currNum;
            }

            Console.WriteLine(sum);
        }
    }
}
