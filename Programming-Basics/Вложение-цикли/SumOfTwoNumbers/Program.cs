using System;

namespace SumOfTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int counter = 0;
            int placeOfTheMagicNum = 0;

            int firstNum = 0;
            int secondNum = 0;
            bool foundMagicNum = false;

            for (int x = start; x <= end; x++)
            {
                for (int z = start; z <= end; z++)
                {
                    counter++;
                    if (x + z == magicNumber)
                    {
                        firstNum = x;
                        secondNum = z;
                        foundMagicNum = true;
                        placeOfTheMagicNum = counter;
                        goto exit;
                    }
                }
            }
            exit:
            if (foundMagicNum)
            {
                Console.WriteLine($"Combination N:{placeOfTheMagicNum} ({firstNum} + {secondNum} = {magicNumber})");
            }
            else
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicNumber}");
            }
            
        }
    }
}
