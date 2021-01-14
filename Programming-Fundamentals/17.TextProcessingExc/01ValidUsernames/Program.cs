using System;
using System.Collections.Generic;
using System.Linq;

namespace _01ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<string> validUsernames = new List<string>();

            for (int i = 0; i < usernames.Length; i++)
            {
                bool isValid = true;
                string currUsername = usernames[i];

                if (currUsername.Length < 3 || currUsername.Length > 16)
                {
                    isValid = false;
                    goto Validation;
                }

                for (int z = 0; z < currUsername.Length; z++)
                {
                    char currChar = currUsername[z];

                    if (!Char.IsDigit(currChar) && !Char.IsLetter(currChar) && currChar != '-' && currChar != '_')
                    {
                        isValid = false;
                        break;
                    }
                }
                Validation:
                if (isValid)
                {
                    validUsernames.Add(currUsername);
                }
            }
            Console.WriteLine(string.Join(Environment.NewLine, validUsernames));


        }
    }
}
