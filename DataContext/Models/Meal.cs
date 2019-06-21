using System.Collections.Generic;

namespace DataContext.Models
{
    public class Meal
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public List<Recipe> Recipes { get; set; }
    }
}