using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataContext.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<IngredientRecipe> Ingredients { get; set; }

        
        [NotMapped]
        public int MealId { get; set; }
        [ForeignKey("MealId")]
        public Meal Meal { get; set; }
        
    }
}