using System;
using System.Linq;

namespace _01ExamPrepLection
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawActivationKey = Console.ReadLine();

            string input;
            while ((input = Console.ReadLine()) != "Generate")
            {
                string[] cmdArgs = input.Split(">>>", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = cmdArgs[0];

                if (command == "Contains")
                {
                    string substring = cmdArgs[1];

                    if (rawActivationKey.Contains(substring))
                    {
                        Console.WriteLine($"{rawActivationKey} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (command == "Flip")
                {
                    string upperOrLower = cmdArgs[1];
                    int startIndex = int.Parse(cmdArgs[2]);
                    int endIndex = int.Parse(cmdArgs[3]);

                    if (upperOrLower == "Upper")
                    {
                        string substringToUpper = rawActivationKey.Substring(startIndex, endIndex - startIndex);
                        rawActivationKey = rawActivationKey.Replace(substringToUpper, substringToUpper.ToUpper());
                        Console.WriteLine(rawActivationKey);
                    }
                    else
                    {
                        string substringToLower = rawActivationKey.Substring(startIndex, endIndex - startIndex);
                        rawActivationKey = rawActivationKey.Replace(substringToLower, substringToLower.ToLower());
                        Console.WriteLine(rawActivationKey);
                    }
                }
                else if (command == "Slice")
                {
                    int startIndex = int.Parse(cmdArgs[1]);
                    int endIndex = int.Parse(cmdArgs[2]);

                    rawActivationKey = rawActivationKey.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(rawActivationKey);
                }

            }
            Console.WriteLine($"Your activation key is: { rawActivationKey}");
        }
    }
}
