using System;

namespace CustomStack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();
            Console.WriteLine(stack.IsEmpty());

            string[] collection = { "Angel", "Ivan", "Pesho" };
            Console.WriteLine(string.Join(", ", stack.AddRange(collection)));
        }
    }
}
