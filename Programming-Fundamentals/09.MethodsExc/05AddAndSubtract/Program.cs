using System;

namespace _05AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int sum = AddAndSubstract(firstNum, secondNum, thirdNum);

            Console.WriteLine(sum);
        }

        static int AddAndSubstract(int firstNum, int secondNum, int thirdNum)
        {
            int sum = (firstNum+secondNum) - thirdNum;

            return sum;
        }
    }
}
