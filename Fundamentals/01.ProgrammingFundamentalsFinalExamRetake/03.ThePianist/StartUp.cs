using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    class Pieces
    {
        public string Composer { get; set; }
        public string Key { get; set; }
    }
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Pieces> pieces = new Dictionary<string, Pieces>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split("|");

                pieces.Add(input[0], new Pieces());
                pieces[input[0]].Composer = input[1];
                pieces[input[0]].Key = input[2];
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Stop")
                {
                    break;
                }

                string[] command = line
                    .Split("|");


                if (command[0] == "Add")
                {
                    string piece = command[1];
                    string composer = command[2];
                    string key = command[3];

                    if (pieces.ContainsKey(piece))
                    {
                        Console.WriteLine($"{piece} is already in the collection!");
                    }
                    else
                    {
                        pieces.Add(piece, new Pieces());
                        pieces[piece].Composer = composer;
                        pieces[piece].Key = key;

                        Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                    }
                }
                else if (command[0] == "Remove")
                {
                    string piece = command[1];

                    if (pieces.ContainsKey(piece))
                    {
                        pieces.Remove(piece);

                        Console.WriteLine($"Successfully removed {piece}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (command[0] == "ChangeKey")
                {
                    string piece = command[1];
                    string newKey = command[2];

                    if (pieces.ContainsKey(piece))
                    {
                        pieces[piece].Key = newKey;

                        Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
            }

            pieces = pieces
                .OrderBy(x => x.Key)
                .ThenBy(x => x.Value.Composer)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in pieces)
            {
               Console.WriteLine($"{kvp.Key} -> Composer: {kvp.Value.Composer}, Key: {kvp.Value.Key}");
            }
        }
    }
}
