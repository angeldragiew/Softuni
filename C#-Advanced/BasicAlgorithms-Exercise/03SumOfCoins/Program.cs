using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = new[] { 1, 2, 5 };
        var targetSum = 2031154123;

        Dictionary<int, int> selectedCoins = new Dictionary<int, int>();
        try
        {
            selectedCoins = ChooseCoins(availableCoins, targetSum);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        coins = coins.OrderByDescending(c => c).ToList();
        Dictionary<int, int> wallet = new Dictionary<int, int>();
        int sum = 0;
        for (int i = 0; i < coins.Count; i++)
        {
            int currCoin = coins[i];
            if (currCoin + sum > targetSum)
            {
                continue;
            }

            int coinsToTake = (targetSum - sum) / currCoin;
            sum += currCoin * coinsToTake;

            wallet.Add(currCoin, coinsToTake);

            if (targetSum == sum)
            {
                return wallet;
            }
        }

        throw new Exception("Error");

    }
}