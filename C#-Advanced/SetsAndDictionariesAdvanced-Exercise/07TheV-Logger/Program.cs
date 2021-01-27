using System;
using System.Collections.Generic;
using System.Linq;

namespace _07TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> theVLogger = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            string input;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] cmdArgs = input.Split();
                string vlogger = cmdArgs[0];
                string command = cmdArgs[1];
                string secVlogger = cmdArgs[2];
                if (command == "joined" && !theVLogger.ContainsKey(vlogger))
                {
                    theVLogger.Add(vlogger, new Dictionary<string, SortedSet<string>>());
                    theVLogger[vlogger].Add("following", new SortedSet<string>());
                    theVLogger[vlogger].Add("followers", new SortedSet<string>());
                }
                else if (command == "followed" && theVLogger.ContainsKey(vlogger) && theVLogger.ContainsKey(secVlogger))
                {
                    if (vlogger == secVlogger)
                    {
                        continue;
                    }

                    theVLogger[vlogger]["following"].Add(secVlogger);
                    theVLogger[secVlogger]["followers"].Add(vlogger);
                }
            }

            Console.WriteLine($"The V-Logger has a total of {theVLogger.Count} vloggers in its logs.");
            theVLogger = theVLogger.OrderByDescending(f => f.Value["followers"].Count).ThenBy(f => f.Value["following"].Count).ToDictionary(k => k.Key, k => k.Value);

            Console.WriteLine($"1. {theVLogger.First().Key} : {theVLogger.First().Value["followers"].Count} followers, {theVLogger.First().Value["following"].Count} following");
            foreach (var follower in theVLogger.First().Value["followers"].OrderBy(x => x))
            {
                Console.WriteLine($"*  {follower}");
            }

            int counter = 2;
            foreach (var vlogger in theVLogger.Skip(1))
            {
                Console.WriteLine($"{counter++}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");
            }
        }
    }
}
