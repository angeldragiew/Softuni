using System;
using System.Collections.Generic;
using System.Linq;

namespace _06CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstDeck = Console.ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToList();

            List<int> secondDeck = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int index = 0;
            while (firstDeck.Count>0 && secondDeck.Count>0)
            {
                int firstPlayerCard = firstDeck[index];
                int secondPlayerCard = secondDeck[index];

                firstDeck.Remove(firstPlayerCard);
                secondDeck.Remove(secondPlayerCard);

                if (firstPlayerCard>secondPlayerCard)
                {
                    firstDeck.Add(firstPlayerCard);
                    firstDeck.Add(secondPlayerCard);
                }
                else if (secondPlayerCard > firstPlayerCard)
                {
                    secondDeck.Add(secondPlayerCard);
                    secondDeck.Add(firstPlayerCard);
                }
            }
            List<string> winnerAndSum = WinningDeck(firstDeck, secondDeck);

            Console.WriteLine($"{winnerAndSum[0]} player wins! Sum: {winnerAndSum[1]}");
        }

        static List<string> WinningDeck(List<int> firstDeck, List<int> secondDeck)
        {
            List<string> winnerAndSum= new List<string>(2);
            string winner;
            int sum;
            if (firstDeck.Count > secondDeck.Count)
            {
                sum = firstDeck.Sum();
                winner = "First";

                winnerAndSum.Add(winner);
                winnerAndSum.Add(sum.ToString());                
            }
            else
            {
                sum = secondDeck.Sum();
                winner = "Second";

                winnerAndSum.Add(winner);
                winnerAndSum.Add(sum.ToString());
            }
            
            return winnerAndSum;
        }
    }
}
