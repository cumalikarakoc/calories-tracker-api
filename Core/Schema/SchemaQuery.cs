using Core.Services;
using GraphQL.Types;

namespace Core.Schema
{
    public class SchemaQuery : ObjectGraphType<object>
    {
        public SchemaQuery(RecipeService recipeService, MealService mealService)
        {
            Name = "Query";
            Field<ListGraphType<RecipeType>>("recipes",resolve: context => recipeService.GetRecipesAsync());

            Field<ListGraphType<MealType>>("meals", resolve: context => mealService.GetMealsAsync());
        }
    }
}