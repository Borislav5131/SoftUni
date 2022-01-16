using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Core.Contracts;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == "FreshwaterAquarium")
            {
                IAquarium aquarium = new FreshwaterAquarium(aquariumName);
                aquariums.Add(aquarium);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                IAquarium aquarium = new SaltwaterAquarium(aquariumName);
                aquariums.Add(aquarium);
            }
            else
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }

            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;

            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            else
            {
                throw new InvalidOperationException("IInvalid decoration type.");
            }

            decorations.Add(decoration);
            return $"Successfully added {decorationType}.";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = decorations.FindByType(decorationType);

            if (decoration == null)
            {
                throw new InvalidOperationException("There isn't a decoration of type {decorationType}.");
            }

            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.AddDecoration(decoration);
            decorations.Remove(decoration);

            return $"Successfully added { decorationType} to { aquariumName}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            bool canLive = false;

            if (fishType == "FreshwaterFish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType == "SaltwaterFish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            else
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

            string acType = aquarium.GetType().Name.Substring(0,8);
            string fiType = fish.GetType().Name.Substring(0,8);

            if (acType == fiType)
            {
                canLive = true;
                aquarium.AddFish(fish);
            }

            if (canLive)
            {
                return $"Successfully added {fishType} to {aquariumName}.";
            }
            else
            {
                return $"Water not suitable.";
            }
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.Feed();

            return $"Fish fed: {aquarium.Fish.Count}";
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(x => x.Name == aquariumName);
            decimal sum = 0;

            foreach (var fish in aquarium.Fish)
            {
                sum += fish.Price;
            }

            foreach (var aquariumDecoration in aquarium.Decorations)
            {
                sum += aquariumDecoration.Price;
            }

            return $"The value of Aquarium {aquariumName} is {sum:f2}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
