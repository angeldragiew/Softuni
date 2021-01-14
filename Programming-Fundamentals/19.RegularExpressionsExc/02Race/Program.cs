using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] givenParticipants = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Dictionary<string, int> participants = new Dictionary<string, int>();

            foreach (var participant in givenParticipants)
            {
                participants.Add(participant, 0);
            }

            string namePattern = @"[\W\d]";
            string distancePattern = @"[\D]";
            
            

            string input = Console.ReadLine();

            while (input!= "end of race")
            {
                string name = Regex.Replace(input, namePattern, "");
                string distanceDigits = Regex.Replace(input, distancePattern, "");

                int distance = 0;

                foreach (var digit in distanceDigits)
                {
                    distance += int.Parse(digit.ToString());
                }

                if (participants.ContainsKey(name))
                {
                    participants[name] += distance;
                }

                input = Console.ReadLine();
            }

            int counter = 1;
           

            foreach (var kvp in participants.OrderByDescending(d=>d.Value))
            {
                string outer = counter == 1 ? "st" : counter == 2 ? "nd" : "rd";
                Console.WriteLine($"{counter}{outer} place: {kvp.Key}");
                counter++;
                if (counter > 3)
                {
                    break;
                }
            }
        }
    }
}
