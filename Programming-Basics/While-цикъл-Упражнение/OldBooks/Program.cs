using System;

namespace OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string wantedBook = Console.ReadLine();

            string currBook = Console.ReadLine(); ;

            bool isFound = true;
            int count = 0;
            while (wantedBook!=currBook)
            {
                
                if(currBook == "No More Books")
                {
                    isFound = false;
                    break;
                }
                count++;
                currBook = Console.ReadLine();
            }

            if (isFound)
            {
                Console.WriteLine($"You checked {count} books and found it.");
            }
            else
            {
                Console.WriteLine($"The book you search is not here!");
                Console.WriteLine($"You checked {count} books.");
            }
        }
    }
}
