
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace VetClinic
{
    public class Clinic
    {
        public List<Pet> Pets { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return Pets.Count;
            }
        }

        public Clinic(int capacity )
        {
            Capacity = capacity;
            Pets = new List<Pet>();
        }

        public void Add(Pet pet)
        {
            if (Capacity > Pets.Count)
            {
                Pets.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            var pet = Pets.Where(x => x.Name == name).FirstOrDefault();
            if (Pets.Contains(pet))
            {
                Pets.Remove(pet);
                return true;
            }

            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            return Pets.Where(x => x.Name == name && x.Owner == owner).FirstOrDefault();
        }

        public Pet GetOldestPet()
        {
            return Pets.OrderByDescending(x => x.Age).First();
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");

            foreach (var pet in Pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
