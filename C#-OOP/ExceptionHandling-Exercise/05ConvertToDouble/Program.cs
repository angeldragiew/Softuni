using System;

namespace _05ConvertToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double number = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
