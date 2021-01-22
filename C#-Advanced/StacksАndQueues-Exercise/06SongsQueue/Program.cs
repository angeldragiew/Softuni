using System;
using System.Collections.Generic;
using System.Linq;

namespace _06SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songsInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Queue<string> songs = new Queue<string>(songsInput);

            while (songs.Any())
            {
                string[] cmdArgs = Console.ReadLine().Split().ToArray();
                string command = cmdArgs[0];

                if (command == "Play")
                {
                    songs.Dequeue();
                }
                else if (command == "Add")
                {
                   
                    string song = string.Empty;
                    for (int i = 1; i < cmdArgs.Length; i++)
                    {
                        song += $"{cmdArgs[i]} "; 
                    }
                    song = song.TrimEnd();
                    if (songs.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(song);
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
