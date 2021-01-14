using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            string keyPattern = @"[SsTtAaRr]";
            string pattern = @"@(?<planet>[A-z]+)[^@:!\->]*:(?:[\d]+)[^@:!\->]*!(?<attackType>[AD])![^@:!\->]*->(?:[\d]+)(?:[\w]*)";
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> planets = new Dictionary<string, string>();
            
            for (int i = 0; i < n; i++)
            {
                string encryptedMessage = Console.ReadLine();

                var keys = Regex.Matches(encryptedMessage, keyPattern);
                int key = keys.Count;

                string decryptedMessage = "";
                foreach (var ch in encryptedMessage)
                {
                    decryptedMessage += (char)(ch - key);
                }

                Match match = Regex.Match(decryptedMessage, pattern);

                if (match.Success)
                {
                    string planet = match.Groups["planet"].Value;
                    string attackType = match.Groups["attackType"].Value;

                    planets.Add(planet, attackType);
                }                
            }

            Dictionary<string, string> attackedPlanets = planets.Where(a => a.Value == "A").ToDictionary(k => k.Key, v => v.Value);
            Dictionary<string, string> destroyedPlanets = planets.Where(a => a.Value == "D").ToDictionary(k => k.Key, v => v.Value);

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (var planet in attackedPlanets.OrderBy(a=>a.Key))
            {
                Console.WriteLine($"-> {planet.Key}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (var planet in destroyedPlanets.OrderBy(a => a.Key))
            {
                Console.WriteLine($"-> {planet.Key}");
            }

        }
    }
}
