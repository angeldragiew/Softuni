using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            int diff = DateModifier.GetDifferenceBetweenTwoDates(firstDate,secondDate);
            Console.WriteLine(diff);
        }
    }
}
