using Core.Services;
using GraphQL.Types;

namespace Core.Schema
{
    public class SchemaQuery : ObjectGraphType<object>
    {
        public SchemaQuery(RecipeService recipeService, MealService mealService)
        {
            Name = "Query";
            Field<ListGraphType<RecipeType>>("recipes", resolve: context => recipeService.GetRecipesAsync());

            FieldAsync<MealType>("mealRecipes",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "mealId"}),
                resolve: async context =>
                {
                    return await context.TryAsyncResolve(
                            async c => await mealService.GetRecipesForMealIdAsync(c.GetArgument<int>("mealId"))
                        );
                });
        }
    }
}