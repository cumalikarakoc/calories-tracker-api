using DataContext.Models;

namespace Core.Schema.Dtos
{
    public class IngredientRecipeDto : Ingredient
    {
        public int Quantity { get; set; }

        public IngredientRecipeDto(Ingredient ingredient, int quantity)
        {
            Id = ingredient.Id;
            Name = ingredient.Name;
            Calories = ingredient.Calories;
            Quantity = quantity;
        }
    }
}