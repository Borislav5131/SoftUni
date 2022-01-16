using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Songs
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> songs = new List<string>();

            while (n > 0)
            {
                string[] input = Console.ReadLine()
                     .Split("_");

                string type = input[0];
                string name = input[1];
                string time = input[2];

                Song song = new Song();

                song.Type = type;
                song.Name = name;
                song.Time = time;

                songs.Add(song);
            }

            string typeList = Console.ReadLine();

            if (typeList == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }

        }
    }
    class Song
    {
        public string Type { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }
    }
}
