using System;
using Core.Services;
using GraphQL.Types;

namespace Core.Schema
{
    public class SchemaQuery : ObjectGraphType<object>
    {
        public SchemaQuery(RecipeService recipeService, MealService mealService, IngredientService ingredientService)
        {
            Name = "Query";
            Field<ListGraphType<RecipeType>>("recipes", resolve: context => recipeService.GetRecipesAsync());

            Field<RecipeType>("recipe", arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "recipeId"}),
                resolve: context =>
                    recipeService.GetRecipeByIdAsync(context.GetArgument<int>(Name = "recipeId")));

            Field<ListGraphType<MealType>>("meals", 
                arguments: new QueryArguments(new QueryArgument<DateGraphType> {Name = "createdAt"}),
                resolve: context => mealService.GetMealsAsync(context.GetArgument<DateTime>("createdAt")));

            Field<ListGraphType<IngredientType>>("ingredients",
                resolve: context => ingredientService.GetIngredientsAsync());

            Field<IngredientType>("ingredient",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>>
                    {Name = "ingredientId"}),
                resolve: context =>
                    ingredientService.GetIngredientByIdAsync(context.GetArgument<int>(Name = "ingredientId")));
        }
    }
}