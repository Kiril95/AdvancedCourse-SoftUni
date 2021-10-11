using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public List<Ingredient> Ingredients;
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new List<Ingredient>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel => Ingredients.Sum(x => x.Alcohol);

        public void Add(Ingredient ingredient)
        {
            bool exists = Ingredients.Exists(x => x.Name == ingredient.Name);

            if (!exists && ingredient.Alcohol <= MaxAlcoholLevel && Ingredients.Count < this.Capacity)
            {
                Ingredients.Add(ingredient);
            }
        }
        public bool Remove(string name)
        {
            if (Ingredients.Any(x => x.Name == name))
            {
                var target = Ingredients.FirstOrDefault(x => x.Name == name);
                Ingredients.Remove(target);
                return true;
            }

            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            if (Ingredients.Any(x => x.Name == name))
            {
                return Ingredients.Find(x => x.Name == name);
            }

            return null;
        }
        public Ingredient GetMostAlcoholicIngredient()
        {
            if (Ingredients.Any())
            {
                var mostAlcohol = Ingredients.Select(x => x.Alcohol).Max();
                return Ingredients.FirstOrDefault(x => x.Alcohol == mostAlcohol);
            }

            return null;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var item in this.Ingredients)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
