using System;
using System.Linq;

namespace ListyIterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] collection = Console.ReadLine().Split();
            ListyIterator<string> listy = new ListyIterator<string>(collection.Skip(1).ToArray());

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                if (input == "HasNext")
                {
                    Console.WriteLine(listy.HasNext());
                }
                else if (input == "Move")
                {
                    Console.WriteLine(listy.Move());
                }
                else if (input == "Print")
                {
                    try
                    {
                        listy.Print();
                    }
                    catch(InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
