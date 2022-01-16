using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }

                name = value;
            }
        }
        public int Capacity { get; }
        public int Comfort => Decorations.Sum(x => x.Comfort);
        public ICollection<IDecoration> Decorations { get;}
        public ICollection<IFish> Fish { get; }

        public Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Decorations = new List<IDecoration>();
            Fish = new List<IFish>();
        }

        public void AddFish(IFish fish)
        {
            if (Fish.Count >= Capacity)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }

            Fish.Add(fish);
        }

        public bool RemoveFish(IFish fish)
        {
            if (Fish.Contains(fish))
            {
                Fish.Remove(fish);
                return true;
            }

            return false;
        }

        public void AddDecoration(IDecoration decoration)
        {
            Decorations.Add(decoration);
        }

        public void Feed()
        {
            foreach (var fish in Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} ({GetType().Name}):");

            if (Fish.Any())
            {
                List<string> fishNames = new List<string>();
                foreach (var fish in Fish)
                {
                    fishNames.Add(fish.Name);
                }
                sb.AppendLine($"Fish: {string.Join(", ",fishNames)}");
            }
            else
            {
                sb.AppendLine("Fish: none");
            }

            sb.AppendLine($"Decorations: {Decorations.Count}");
            sb.AppendLine($"Comfort: {Comfort}");

            return sb.ToString().TrimEnd();
        }
    }
}
