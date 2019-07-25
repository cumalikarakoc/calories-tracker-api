using System.Collections.Generic;

namespace DataContext.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MealRecipe> Recipes { get; set; }
        public List<IngredientMeal> Ingredients { get; set; }
    }
}