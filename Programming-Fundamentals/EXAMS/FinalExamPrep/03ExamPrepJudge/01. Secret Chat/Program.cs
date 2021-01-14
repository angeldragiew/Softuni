using System;
using System.Linq;

namespace _01._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string concealedMessage = Console.ReadLine();

            string input;

            while ((input = Console.ReadLine()) != "Reveal")
            {
                string[] cmdArgs = input.Split(":|:", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = cmdArgs[0];

                if (command == "InsertSpace")
                {
                    int index = int.Parse(cmdArgs[1]);

                    concealedMessage = concealedMessage.Insert(index, " ");
                    Console.WriteLine(concealedMessage);
                }
                else if (command == "Reverse")
                {
                    string substring = cmdArgs[1];

                    if (concealedMessage.Contains(substring))
                    {
                        char[] reversed = substring.ToCharArray();
                        Array.Reverse(reversed);
                        int index = concealedMessage.IndexOf(substring);
                        concealedMessage = concealedMessage.Remove(index, substring.Length);
                        string newString = new string(reversed);
                        concealedMessage += Convert.ToString(newString);
                        Console.WriteLine(concealedMessage);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                   
                }
                else if (command == "ChangeAll")
                {
                    string substring = cmdArgs[1];
                    string replaces = cmdArgs[2];

                    concealedMessage = concealedMessage.Replace(substring, replaces);
                    Console.WriteLine(concealedMessage);
                }
            }

            Console.WriteLine($"You have a new text message: {concealedMessage}");
        }
    }
}
