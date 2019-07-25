using System;

namespace DataContext.Models
{
    public class IngredientMeal
    {
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        
        public DateTime CreatedAt { get; set; }
    }
}