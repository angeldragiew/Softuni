using System;

namespace _01SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {
           
            try
            {
                int n = int.Parse(Console.ReadLine());
                int nSquareRoot = CalculateSquareRoot(n);
                Console.WriteLine(nSquareRoot);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The number cannot be negative");
            }
            catch (OverflowException)
            {
                Console.WriteLine("The number is too big");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }

        private static int CalculateSquareRoot(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("The cannot be negative");
            }
            return n * n;
        }
    }
}
