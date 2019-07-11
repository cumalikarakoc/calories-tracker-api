using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema.Data
{
    public class IngredientRecipeInputType : InputObjectGraphType<IngredientRecipe>
    {
        public IngredientRecipeInputType()
        {
            Name = "RecipeInput";
            Field<NonNullGraphType<IntGraphType>>("recipeId");  
            Field<NonNullGraphType<IntGraphType>>("ingredientId");  
            Field<NonNullGraphType<IntGraphType>>("quantity");  
        }
    }
}