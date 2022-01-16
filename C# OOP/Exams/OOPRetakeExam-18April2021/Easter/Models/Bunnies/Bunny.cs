using System.Linq;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;

namespace Easter.Models.Bunnies
{
    using System;
    using System.Collections.Generic;
    using Utilities.Messages;

    public abstract class Bunny : IBunny
    {
        private string name;

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }

                name = value;
            }

        }
        public int Energy { get; protected set; }
        public ICollection<IDye> Dyes { get; }

        public Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;
            Dyes = new List<IDye>();
        }
        public virtual void Work()
        {
            Energy -= 10;
            if (Energy < 0)
            {
                Energy = 0;
            }

            while (Dyes.Any())
            {
                if (!Dyes.First().IsFinished())
                {
                    Dyes.First().Use();
                    break;
                }

                Dyes.Remove(Dyes.First());
            }
        }

        public void AddDye(IDye dye)
        {
            Dyes.Add(dye);
        }
    }
}
