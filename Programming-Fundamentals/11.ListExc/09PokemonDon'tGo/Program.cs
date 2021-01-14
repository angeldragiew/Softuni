using System;
using System.Collections.Generic;
using System.Linq;

namespace _09PokemonDon_tGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemonList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> caughtPokemons = new List<int>();
            while (pokemonList.Count>0)
            {
                int index = int.Parse(Console.ReadLine());

                if (index < 0)
                {
                    int number = pokemonList[0];
                    caughtPokemons.Add(number);
                    pokemonList.RemoveAt(0);
                    pokemonList.Insert(0, pokemonList[pokemonList.Count - 1]);
                    IncreaseAndDecrease(pokemonList, number);
                }
                else if (index >= pokemonList.Count)
                {
                    int number = pokemonList[pokemonList.Count - 1];
                    caughtPokemons.Add(number);
                    pokemonList.RemoveAt(pokemonList.Count-1);
                    pokemonList.Add(pokemonList[0]);
                    IncreaseAndDecrease(pokemonList, number);
                }
                else
                {
                    int number = pokemonList[index];
                    caughtPokemons.Add(number);
                    pokemonList.RemoveAt(index);

                    IncreaseAndDecrease(pokemonList, number);
                }
            }
            Console.WriteLine(caughtPokemons.Sum());
        }

        static List<int> IncreaseAndDecrease (List<int> pokemonList, int number)
        {
            for (int i = 0; i < pokemonList.Count; i++)
            {
                if (pokemonList[i] <= number)
                {
                    pokemonList[i] += number;
                }
                else
                {
                    pokemonList[i] -= number;
                }
            }

            return pokemonList;
        }
    }
}
