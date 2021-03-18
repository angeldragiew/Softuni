using System;

namespace _02EnterNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter 10 numbers");
                try
                {
                    for (int i = 0; i < 10; i++)
                    {
                        ReadNumber(1, 100);
                    }
                    Console.WriteLine("You successfully entered all the numbers");
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void ReadNumber(int start, int end)
        {
            int number = int.Parse(Console.ReadLine());
            if (number < start || number > end)
            {
                throw new ArgumentException($"The number must be in [{start}...{end}]");
            }
        }
    }
}
