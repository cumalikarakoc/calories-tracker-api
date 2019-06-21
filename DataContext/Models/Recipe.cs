using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataContext.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public List<Ingredient> Ingredients { get; set; }
    }
}