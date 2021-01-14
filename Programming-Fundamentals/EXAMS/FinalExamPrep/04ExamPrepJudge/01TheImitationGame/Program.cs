using System;

namespace _01TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();

            string input;

            while ((input = Console.ReadLine()) != "Decode")
            {
                string[] cmdArgs = input.Split("|");
                string command = cmdArgs[0];

                if (command == "Move")
                {
                    int numberOfLetters = int.Parse(cmdArgs[1]);

                    string substring = encryptedMessage.Substring(0, numberOfLetters);
                    encryptedMessage = encryptedMessage.Remove(0, numberOfLetters);
                    encryptedMessage += substring;
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(cmdArgs[1]);
                    string value = cmdArgs[2];

                    encryptedMessage = encryptedMessage.Insert(index, value);
                }
                else if (command == "ChangeAll")
                {
                    string substring = cmdArgs[1];
                    string replacement = cmdArgs[2];

                    encryptedMessage = encryptedMessage.Replace(substring, replacement);
                }
            }
            Console.WriteLine($"The decrypted message is: {encryptedMessage}");
        }
    }
}
