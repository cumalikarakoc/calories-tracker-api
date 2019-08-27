using System;
using Core.Services;
using GraphQL.Types;

namespace Core.Schema
{
    public class SchemaQuery : ObjectGraphType<object>
    {
        public SchemaQuery(ConsumptionService consumptionService, ConsumableService consumableService, MealService mealService)
        {
            Name = "Query";
            
            Field<ListGraphType<ConsumptionType>>("consumptions", 
                arguments: new QueryArguments(new QueryArgument<DateGraphType> {Name = "createdAt"}),
                resolve: context => consumptionService.GetConsumptionsAsync(context.GetArgument<DateTime>("createdAt")));

            Field<ListGraphType<ConsumableType>>("consumables",
                resolve: context => consumableService.GetConsumablesAsync());

            Field<ListGraphType<MealType>>("meals",
                resolve: context => mealService.GetMealsAsync());
        }
    }
}