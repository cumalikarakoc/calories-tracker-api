using System;

namespace DataContext.Models
{
    public class Consumption
    {
        public int Id { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get; set; }
        public int ConsumableId { get; set; }
        public Consumable Consumable { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}