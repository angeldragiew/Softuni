﻿using System;
using System.Linq;

namespace _01AdvertisementMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Random rnd = new Random();

            string[] phrases = { "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can’t live without this product." };

            string[] events = { "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!" };

            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            for (int i = 0; i < n; i++)
            {
                string phrase = phrases[rnd.Next(phrases.Length)];
                string evint = events[rnd.Next(events.Length)];
                string author = authors[rnd.Next(authors.Length)];
                string city = cities[rnd.Next(cities.Length)];

                Console.WriteLine($"{phrase} {evint} {author} – {city}.");

            }

        }

    }
}


