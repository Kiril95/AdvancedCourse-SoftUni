﻿using System.Text;

namespace CocktailParty
{
    public class Ingredient
    {
        public Ingredient(string name, int alcohol, int quantity)
        {
            Name = name;
            Alcohol = alcohol;
            Quantity = quantity;
        }
        public string Name { get; set; }
        public int Alcohol { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder
                .AppendLine($"Ingredient: {this.Name}")
                .AppendLine($"Quantity: {this.Quantity}")
                .AppendLine($"Alcohol: {this.Alcohol}");

            return builder.ToString().TrimEnd();
        }
    }
}
