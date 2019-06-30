using Core.Schema.Data;
using Core.Services;
using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema
{
    public class SchemaMutation : ObjectGraphType<object>
    {
        public SchemaMutation(RecipeService recipeService, MealService mealService)
        {
            Name = "Mutation";
            Field<RecipeType>(
                "createRecipe",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<RecipeCreateInputType>> {Name = "recipe"}),
                resolve: context =>
                {
                    var recipe = context.GetArgument<Recipe>("recipe");
                    return recipeService.CreateAsync(recipe);
                }
            );

            Field<RecipeType>("updateRecipe", arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "recipeId"},
                    new QueryArgument<NonNullGraphType<RecipeCreateInputType>> {Name = "recipe"}),
                resolve: context =>
                {
                    return recipeService.UpdateAsync(context.GetArgument<int>(Name = "recipeId"),
                        context.GetArgument<Recipe>("recipe"));
                }
            );

            Field<RecipeType>("addRecipeToMeal", arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "recipeId"},
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "mealId"}),
                resolve: context =>
                {
                    return mealService.AddRecipeToMealAsync(context.GetArgument<int>(Name = "recipeId"),
                        context.GetArgument<int>(Name = "mealId"));
                }
            );

            Field<RecipeType>("addIngredientToRecipe", arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "ingredientId"},
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "recipeId"}),
                resolve: context =>
                {
                    return recipeService.AddIngredientAsync(context.GetArgument<int>(Name = "recipeId"),
                        context.GetArgument<int>(Name = "ingredientId"));
                }
            );
        }
    }
}