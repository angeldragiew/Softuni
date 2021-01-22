using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int operations = int.Parse(Console.ReadLine());

            StringBuilder text = new StringBuilder();
            Stack<string> savedChanges = new Stack<string>();
            savedChanges.Push(text.ToString());
            for (int i = 0; i < operations; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split().ToArray();
                string command = cmdArgs[0];

                if (command == "1")
                {
                    string textToAdd = cmdArgs[1];
                    text.Append(textToAdd);
                    savedChanges.Push(text.ToString());
                }
                else if (command == "2")
                {
                    int count = int.Parse(cmdArgs[1]);

                    text.Remove(text.Length - count, count);

                    savedChanges.Push(text.ToString());
                }
                else if (command == "3")
                {
                    int index = int.Parse(cmdArgs[1]) - 1;
                    Console.WriteLine(text[index]);
                }
                else if (command == "4")
                {
                    text.Clear();
                    savedChanges.Pop();
                    text.Append(savedChanges.Peek());
                }
            }
        }
    }
}
