using System;
using System.Collections.Generic;
using System.Linq;

namespace _04Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();


            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] arr = input.Split("_", StringSplitOptions.RemoveEmptyEntries);

                Song song = new Song();

                song.TypeList = arr[0];
                song.Name = arr[1];
                song.Time = arr[2];

                songs.Add(song);
            }

            string command = Console.ReadLine();

            if (command == "all")
            {
                foreach (var song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                List<Song> filteredSongs = songs.Where(s => s.TypeList == command).ToList();

                foreach (var song in filteredSongs)
                {
                    Console.WriteLine(song.Name);
                }
            }
        }

        public class Song
        {
            public string TypeList { get; set; }
            public string Name { get; set; }
            public string Time { get; set; }
        }
    }
}
