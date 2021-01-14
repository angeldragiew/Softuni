using System;

namespace TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string presentationName = Console.ReadLine();

            double average = 0;
            double allAverage = 0;
            int count = 0;
            while (presentationName!= "Finish")
            {
                for (int i = 1; i <= n; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    average += grade;
                }
                average /= n;
                Console.WriteLine($"{presentationName} - {average:f2}.");
                allAverage += average;
                count++;
                average = 0;
                presentationName = Console.ReadLine();
            }

            Console.WriteLine($"Student's final assessment is {allAverage/count:f2}.");
        }
    }
}
