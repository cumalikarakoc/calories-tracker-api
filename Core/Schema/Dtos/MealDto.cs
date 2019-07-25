using System;
using System.Collections.Generic;
using System.Linq;
using DataContext.Models;

namespace Core.Schema.Dtos
{
    public class MealDto : Meal
    {
        public new List<MealRecipeDto> Recipes { get; set; }
        public new List<IngredientMeal> Ingredients { get; set; }

        public MealDto(Meal meal)
        {
            Id = meal.Id;
            Name = meal.Name;
            Recipes = meal.Recipes.Select(x => new MealRecipeDto(x.Recipe, x.CreatedAt)).ToList();
            Ingredients = meal.Ingredients;
        }
        
        public MealDto(){}
    }
}