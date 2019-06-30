using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema
{
    public class MealRecipeType : ObjectGraphType<MealRecipe>
    {
        public MealRecipeType()
        {
            Field(x => x.Recipe, type: typeof(RecipeType)).Description("recipe");
            Field(x => x.CreatedAt);
        }
    }
}