using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public List<Ingredient> Ingredients { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }

        public int CurrentAlcoholLevel
        {
            get
            {
                int alcoholSum = 0;

                foreach (var ingredient in Ingredients)
                {
                    alcoholSum += ingredient.Alcohol;
                }

                return alcoholSum;
            }
        }

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new List<Ingredient>();
        }

        public void Add(Ingredient ingredient)
        {
            if (!Ingredients.Any(x => x.Name == ingredient.Name
                && ingredient.Quantity <= Capacity
                && ingredient.Alcohol <= MaxAlcoholLevel))
            {
                Ingredients.Add(ingredient);
                Capacity -= ingredient.Quantity;
                MaxAlcoholLevel -= ingredient.Alcohol;
            }
        }

        public bool Remove(string name)
        {
            foreach (var ingredient in Ingredients)
            {
                if (ingredient.Name == name)
                {
                    Capacity += ingredient.Quantity;
                    MaxAlcoholLevel += ingredient.Alcohol;
                    Ingredients.Remove(ingredient);
                    return true;
                }
            }

            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            foreach (var ingredient in Ingredients)
            {
                if (ingredient.Name == name)
                {
                    return ingredient;
                }
            }

            return null;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();
        }


        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var ingredient in Ingredients)
            {
                sb.AppendLine(ingredient.ToString());

            }

            return sb.ToString().TrimEnd();
        }
    }
}
