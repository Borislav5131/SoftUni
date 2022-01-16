using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _09.PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split();

                if (tokens[0] == "Tournament")
                {
                    break;
                }
                else
                {
                    Trainer currTrainer = new Trainer(tokens[0]);
                    Pokemon currPokemon = new Pokemon(tokens[1], tokens[2], int.Parse(tokens[3]));

                    bool containsName = trainers.Any(x => x.Name == currTrainer.Name);

                    if (!containsName)
                    {
                        trainers.Add(currTrainer);
                    }

                    foreach (var trainer in trainers)
                    {
                        if (trainer.Name == currTrainer.Name)
                        {
                            trainer.Pokemons.Add(currPokemon);
                        }
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }
                else if (command == "Fire")
                {


                    foreach (var trainer in trainers)
                    {
                        int counter = 0;

                        foreach (var pokemon in trainer.Pokemons)
                        {
                            if (pokemon.Element == command)
                            {
                                counter++;
                                trainer.Badgets++;
                            }
                        }

                        if (counter == 0)
                        {
                            trainer.Pokemons.ForEach(x => x.Health -= 10);
                        }
                    }
                }
                else if (command == "Water")
                {
                    foreach (var trainer in trainers)
                    {
                        int counter = 0;

                        foreach (var pokemon in trainer.Pokemons)
                        {
                            if (pokemon.Element == command)
                            {
                                counter++;
                                trainer.Badgets++;
                            }
                        }

                        if (counter == 0)
                        {
                            trainer.Pokemons.ForEach(x => x.Health -= 10);
                        }
                    }

                    foreach (var trainer in trainers)
                    {

                    }
                }
                else if (command == "Electricity")
                {

                    foreach (var trainer in trainers)
                    {
                        int counter = 0;

                        foreach (var pokemon in trainer.Pokemons)
                        {
                            if (pokemon.Element == command)
                            {
                                counter++;
                                trainer.Badgets++;
                            }
                        }

                        if (counter == 0)
                        {
                            trainer.Pokemons.ForEach(x => x.Health -= 10);
                        }

                    }

                }
            }


        }
    }
}
