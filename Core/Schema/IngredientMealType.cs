using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema
{
    public class IngredientMealType : ObjectGraphType<IngredientMeal>
    {
        public IngredientMealType()
        {
            Field(i => i.Ingredient.Id);
            Field(i => i.Ingredient.Name);
            Field(i => i.Ingredient.Calories);
            Field(i => i.CreatedAt);
        }
    }
}