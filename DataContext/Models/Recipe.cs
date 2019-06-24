using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataContext.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<IngredientRecipe> Ingredients { get; set; }
        public Meal Meal { get; set; }
        
    }
}