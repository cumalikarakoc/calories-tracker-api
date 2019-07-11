using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema
{
    public class IngredientRecipeType : ObjectGraphType<IngredientRecipe>
    {
        public IngredientRecipeType()
        {
            Field(x => x.Ingredient, type: typeof(IngredientType)).Description("ingredient");
            Field(x => x.Quantity);
        }
    }
}