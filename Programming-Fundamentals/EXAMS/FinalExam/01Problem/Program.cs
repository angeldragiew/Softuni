using System;

namespace _01Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "Sign up")
            {
                string[] cmdArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = cmdArgs[0];

                if (command == "Case")
                {
                    string lowerOrUpper = cmdArgs[1];

                    if (lowerOrUpper == "lower")
                    {
                        username = username.ToLower();
                    }
                    else
                    {
                        username = username.ToUpper();
                    }
                    Console.WriteLine(username);
                }
                else if (command == "Reverse")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);
                    if (startIndex >= 0 && startIndex < username.Length && endIndex >= 0 && endIndex < username.Length)
                    {
                        string substring = username.Substring(startIndex, endIndex - startIndex + 1);
                        char[] reverse = substring.ToCharArray();
                        Array.Reverse(reverse);
                        string reversedSubstring = new string(reverse);

                        Console.WriteLine(reversedSubstring);
                    }
                }
                else if (command == "Cut")
                {
                    string substring = cmdArgs[1];

                    if (username.Contains(substring))
                    {
                        int index = username.IndexOf(substring);
                        username = username.Remove(index, substring.Length);
                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The word {username} doesn't contain {substring}.");
                    }
                }
                else if (command == "Replace")
                {
                    string charToReplace = cmdArgs[1];
                    username = username.Replace(charToReplace, "*");
                    Console.WriteLine(username);
                }
                else if (command == "Check")
                {
                    string charToContatin = cmdArgs[1];

                    if (username.Contains(charToContatin))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {charToContatin}.");
                    }
                }
            }
        }
    }
}
