using System;
using System.Collections.Generic;
using System.Linq;

namespace _03ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, ComposerAndKey> pieces = new Dictionary<string, ComposerAndKey>();

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split("|");

                string piece = cmdArgs[0];
                string composer = cmdArgs[1];
                string key = cmdArgs[2];

                pieces.Add(piece, new ComposerAndKey { Composer = composer, Key = key });
            }

            string input;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] cmdArgs = input.Split("|");
                string command = cmdArgs[0];


                if (command == "Add")
                {
                    string piece = cmdArgs[1];
                    string composer = cmdArgs[2];
                    string key = cmdArgs[3];

                    if (pieces.ContainsKey(piece))
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                    else
                    {
                        pieces.Add(piece, new ComposerAndKey { Composer = composer, Key = key });
                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                }
                else if (command == "Remove")
                {
                    string piece = cmdArgs[1];

                    if (pieces.ContainsKey(piece))
                    {
                        pieces.Remove(piece);
                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (command == "ChangeKey")
                {
                    string piece = cmdArgs[1];
                    string newKey = cmdArgs[2];

                    if (pieces.ContainsKey(piece))
                    {
                        pieces[piece].Key = newKey;
                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
            }
            foreach (var piece in pieces.OrderBy(n=>n.Key).ThenBy(n=>n.Value.Composer))
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value.Composer}, Key: {piece.Value.Key}");
            }
        }

        class ComposerAndKey
        {
            public string Composer { get; set; }
            public string Key { get; set; }
        }
    }
}
