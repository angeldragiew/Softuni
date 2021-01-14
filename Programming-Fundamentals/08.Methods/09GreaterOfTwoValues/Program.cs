using System;

namespace _09GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            string a = Console.ReadLine();
            string b = Console.ReadLine();

            if (type == "int")
            {
               int larger = GetMax(int.Parse(a), int.Parse(b));
                Console.WriteLine(larger);
            }
            else if(type == "string")
            {
                string larger = GetMax(a, b);
                Console.WriteLine(larger);
            }
            else if (type == "char")
            {
                char larger = GetMax(char.Parse(a), char.Parse(b));
                Console.WriteLine(larger);
            }
            
        }

        static int GetMax(int a, int b)
        {
            int biggerValue = 0;
            if (a > b)
            {
                biggerValue = a;
            }
            else
            {
                biggerValue = b;
            }
            return biggerValue;
        }

        static char GetMax(char a, char b)
        {
            char biggerValue;
            if (a > b)
            {
                biggerValue = a;
            }
            else
            {
                biggerValue = b;
            }
            return biggerValue;
        }

        static string GetMax(string a, string b)
        {
            string biggerValue = string.Empty;
            if (a.CompareTo(b)>=0)
            {
                biggerValue = a;
            }
            else
            {
                biggerValue = b;
            }
            return biggerValue;
        }
    }
}
