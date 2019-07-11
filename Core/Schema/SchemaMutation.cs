using System;
using Core.Schema.Data;
using Core.Services;
using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema
{
    public class SchemaMutation : ObjectGraphType<object>
    {
        public SchemaMutation(RecipeService recipeService, MealService mealService, IngredientService ingredientService)
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
                resolve: context => recipeService.UpdateAsync(context.GetArgument<int>(Name = "recipeId"),
                    context.GetArgument<Recipe>("recipe")));

            Field<RecipeType>("removeRecipe",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "recipeId"}),
                resolve: context => recipeService.RemoveAsync(context.GetArgument<int>(Name = "recipeId")));

            Field<MealType>("addRecipeToMeal", arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "recipeId"},
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "mealId"}),
                resolve: context => mealService.AddRecipeToMealAsync(context.GetArgument<int>(Name = "recipeId"),
                    context.GetArgument<int>(Name = "mealId")));

            Field<MealType>("removeRecipeFromMeal", arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "recipeId"},
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "mealId"},
                    new QueryArgument<NonNullGraphType<DateTimeGraphType>> {Name = "createdAt"}),
                resolve: context => mealService.RemoveRecipeFromMealAsync(context.GetArgument<int>(Name = "recipeId"),
                    context.GetArgument<int>(Name = "mealId"), context.GetArgument<DateTime>(Name = "createdAt")));

            Field<RecipeType>("addIngredientToRecipe", arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IngredientRecipeInputType>> {Name = "ingredientRecipe"}),
                resolve: context =>
                    recipeService.AddIngredientAsync(context.GetArgument<IngredientRecipe>(Name = "ingredientRecipe")));

            Field<RecipeType>("removeIngredientFromRecipe", arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "recipeId"},
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "ingredientId"}),
                resolve: context =>
                    recipeService.RemoveIngredientAsync(context.GetArgument<int>(Name = "recipeId"),
                        context.GetArgument<int>(Name = "ingredientId")));
            
            Field<RecipeType>("updateIngredientQuantityOfRecipe", arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IngredientRecipeInputType>> {Name = "ingredientRecipe"}),
                resolve: context =>
                    recipeService.UpdateIngredientQuantityAsync(context.GetArgument<IngredientRecipe>(Name = "ingredientRecipe")));

            Field<IngredientType>("createIngredient", arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IngredientCreateInputType>> {Name = "ingredient"}),
                resolve: context =>
                    ingredientService.CreateAsync(context.GetArgument<Ingredient>(Name = "ingredient")));

            Field<IngredientType>("updateIngredient", arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "ingredientId"},
                    new QueryArgument<NonNullGraphType<IngredientCreateInputType>> {Name = "ingredient"}),
                resolve: context =>
                    ingredientService.UpdateAsync(context.GetArgument<int>(Name = "ingredientId"),
                        context.GetArgument<Ingredient>(Name = "ingredient")));

            Field<IngredientType>("removeIngredient", arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "ingredientId"}),
                resolve: context =>
                    ingredientService.RemoveAsync(context.GetArgument<int>(Name = "ingredientId")));
        }
    }
}