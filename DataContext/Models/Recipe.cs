using System.Collections.Generic;

namespace DataContext.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Ingredient> ingeridents { get; set; }
    }
}