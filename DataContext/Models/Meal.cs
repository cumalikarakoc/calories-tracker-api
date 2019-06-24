using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataContext.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Recipe> Recipes { get; set; }
    }
}