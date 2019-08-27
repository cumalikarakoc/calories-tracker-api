using System;
using Core.Schema.Data;
using Core.Services;
using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema
{
    public class SchemaMutation : ObjectGraphType<object>
    {
        public SchemaMutation(ConsumptionService consumptionService, ConsumableService consumableService, MealService mealService)
        {
            Name = "Mutation";
            
            Field<ConsumptionType>("createConsumption", arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "consumableId"},
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "mealId"}),
                resolve: context => consumptionService.CreateAsync(context.GetArgument<int>(Name = "consumableId"),
                    context.GetArgument<int>(Name = "mealId")));

            Field<ConsumptionType>("removeConsumption", arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "consumptionId"}),
                resolve: context => consumptionService.RemoveAsync(context.GetArgument<int>(Name = "consumptionId")));

            Field<ConsumableType>("createConsumable", arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ConsumableCreateInputType>> {Name = "consumable"}),
                resolve: context =>
                    consumableService.CreateAsync(context.GetArgument<Consumable>(Name = "consumable")));

            Field<ConsumableType>("updateConsumable", arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "consumableId"},
                    new QueryArgument<NonNullGraphType<ConsumableCreateInputType>> {Name = "consumable"}),
                resolve: context =>
                    consumableService.UpdateAsync(context.GetArgument<int>(Name = "consumableId"),
                        context.GetArgument<Consumable>(Name = "consumable")));

            Field<ConsumableType>("removeConsumable", arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "consumableId"}),
                resolve: context =>
                    consumableService.RemoveAsync(context.GetArgument<int>(Name = "consumableId")));

            Field<MealType>("createMeal", arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<MealCreateInputType>> {Name = "meal"}),
                resolve: context => mealService.CreateAsync(context.GetArgument<Meal>(Name = "meal")));

            Field<MealType>("removeMeal",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "id"}),
                resolve: context => mealService.RemoveAsync(context.GetArgument<int>(Name = "id"))
            );
        }
    }
}