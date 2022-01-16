using System;
using System.Collections.Generic;
using System.Linq;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private List<IBunny> bunnies = new List<IBunny>();

        public IReadOnlyCollection<IBunny> Models
        {
            get => bunnies.AsReadOnly();
        }
        public void Add(IBunny model)
        {
            bunnies.Add(model);
        }

        public bool Remove(IBunny model)
        {
            if (bunnies.Contains(model))
            {
                bunnies.Remove(model);
                return true;
            }

            return false;
        }

        public IBunny FindByName(string name)
        {
            return bunnies.FirstOrDefault(x => x.Name == name);
        }
    }
}
