using System;
using System.Linq;

namespace _09KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {

            int dnaArraysLength = int.Parse(Console.ReadLine());

            string input = string.Empty;
            int bestLength=0;
            int bestIndex=0;
            int bestSum=0;
            int[] bestDna = new int[dnaArraysLength];
            int sample = 0;
            int bestSample = 0;
            while ((input = Console.ReadLine())!="Clone them!")
            {
                
                int[] dna = input.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                sample++;
                int length=0;
                int index=0;
                int sum=0;
                for (int z = 0; z < dnaArraysLength; z++)
                {
                    if (dna[z] == 1)
                    {
                        sum++;
                    }
                }
                for (int i = 0; i < dnaArraysLength; i++)
                {
                    
                    if (dna[i] == 1)
                    {
                        length++;    
                        if (length == 1)
                        {
                            index = i;
                        }
                        
                     }
                    else
                    {
                        length = 0;
                    }
                    if ((length > bestLength) ||
                            (length == bestLength && index < bestIndex) ||
                            (length == bestLength && index == bestIndex && sum > bestSum) ||
                            sample==1)
                    {
                        bestLength = length;
                        bestIndex = index;
                        bestSum = sum;
                        bestDna = dna;
                        bestSample = sample;
                    }
                }
            }

            Console.WriteLine($"Best DNA sample {bestSample} with sum: {bestSum}.");
            Console.WriteLine($"{string.Join(" ", bestDna)}");

        }
    }
}
