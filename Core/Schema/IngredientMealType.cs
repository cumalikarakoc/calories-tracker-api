using Core.Schema.Dtos;
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
            Field(i => i.CreatedAt);
        }
    }
}