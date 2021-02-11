using System;

namespace GenericArrayCreator
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            int[] array = ArrayCreator.Create(5, 2);

            Console.WriteLine(string.Join(" ", array));
        }
    }
}
