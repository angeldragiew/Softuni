using System;

namespace _01Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfVagons = int.Parse(Console.ReadLine());

            int[] people = new int[numberOfVagons];
            int sum = 0;
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = int.Parse(Console.ReadLine());
                sum += people[i];
            }

                Console.WriteLine(string.Join(" ", people));
                Console.WriteLine(sum);
        }
    }
}
