using System;
using Easter.Models.Eggs;
using Easter.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using Easter.Models.Eggs.Contracts;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private List<IEgg> eggs = new List<IEgg>();

        public IReadOnlyCollection<IEgg> Models
        {
            get => eggs;
        }
        public void Add(IEgg model)
        {
            eggs.Add(model);
        }

        public bool Remove(IEgg model)
        {
            if (eggs.Contains(model))
            {
                eggs.Remove(model);
                return true;
            }

            return false;
        }

        public IEgg FindByName(string name)
        {
            return eggs.FirstOrDefault(x => x.Name == name);
        }
    }
}
