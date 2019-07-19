using System;
using DataContext.Models;

namespace Core.Schema.Dtos
{
    public class MealRecipeDto : Recipe
    {
        public DateTime CreatedAt { get; set; }

        public MealRecipeDto(Recipe recipe, DateTime createdAt)
        {
            Id = recipe.Id;
            Name = recipe.Name;
            Ingredients = recipe.Ingredients;
            CreatedAt = createdAt;
        }
    }
}