using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            string command = Console.ReadLine();

            while (command != "Tournament")
            {
                string[] operations = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = operations[0];
                string pokeName = operations[1];
                string element = operations[2];
                int health = int.Parse(operations[3]);
                Trainer trainer = new Trainer(trainerName, 0, new List<Pokemon>());
                Pokemon pokemon = new Pokemon(pokeName, element, health);

                if (!trainers.Any(x => x.Name == trainerName))
                {
                    trainers.Add(trainer);
                }
                trainers.First(x => x.Name == trainerName).Pokemons.Add(pokemon);

                command = Console.ReadLine();
            }

            string elem = Console.ReadLine();

            while (elem != "End")
            {
                foreach (Trainer trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == elem))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {
                            trainer.Pokemons[i].Health -= 10;
                            if (trainer.Pokemons[i].Health <= 0)
                            {
                                trainer.Pokemons.Remove(trainer.Pokemons[i]);
                                i--;
                            }
                        }
                    }
                }
                elem = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, trainers.OrderByDescending(t => t.Badges)));
        }
    }
}
