using System;

namespace DataContext.Models
{
    public class MealRecipe
    {
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        
        public DateTime CreatedAt { get; set; }

    }
}