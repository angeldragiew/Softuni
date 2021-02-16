using System;
using System.Linq;

namespace Collection
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] collection = Console.ReadLine().Split();
            ListyIterator<string> listy = new ListyIterator<string>(collection.Skip(1).ToArray());

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "HasNext")
                {
                    Console.WriteLine(listy.HasNext());
                }
                else if (command == "Move")
                {
                    Console.WriteLine(listy.Move());
                }
                else if (command == "Print")
                {
                    try
                    {
                        listy.Print();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "PrintAll")
                {
                    Console.WriteLine(string.Join(" ", listy));
                }
            }
        }
    }
}
