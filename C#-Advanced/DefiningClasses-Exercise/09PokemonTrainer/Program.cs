using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            string input;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] cmdArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = cmdArgs[0];
                string pokemonName = cmdArgs[1];
                string pokemonElement = cmdArgs[2];
                int pokemonHealth = int.Parse(cmdArgs[3]);

                Pokemon currPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                if (trainers.Any(t => t.Name == trainerName))
                {
                    Trainer trainer = trainers.Where(t => t.Name == trainerName).FirstOrDefault();
                    trainer.Pokemons.Add(currPokemon);
                }
                else
                {
                    Trainer currTrainer = new Trainer(trainerName);
                    currTrainer.Pokemons.Add(currPokemon);
                    trainers.Add(currTrainer);
                }
            }

            string secondInput;
            while ((secondInput = Console.ReadLine()) != "End")
            {
                string element = secondInput;

                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == element))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        DamageAllPokemons(trainer);
                        trainer.Pokemons = trainer.Pokemons.Where(p => p.Health > 0).ToList();
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(t => t.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }

        private static void DamageAllPokemons(Trainer trainer)
        {
            foreach (var pokemon in trainer.Pokemons)
            {
                pokemon.Health -= 10;
            }
        }
    }
}
