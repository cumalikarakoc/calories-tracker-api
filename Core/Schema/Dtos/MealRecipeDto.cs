using System;
using System.Collections.Generic;
using System.Linq;
using DataContext.Models;

namespace Core.Schema.Dtos
{
    public class MealRecipeDto : Recipe
    {
        public DateTime CreatedAt { get; set; }
        public new List<IngredientRecipeDto> Ingredients { get; set; }

        public MealRecipeDto(Recipe recipe, DateTime createdAt)
        {
            Id = recipe.Id;
            Name = recipe.Name;
            Ingredients = recipe.Ingredients.Select(x => new IngredientRecipeDto(x.Ingredient, x.Quantity)).ToList();
            CreatedAt = createdAt;
        }
    }
}