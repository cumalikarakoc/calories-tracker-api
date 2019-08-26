using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema
{
    public class ConsumptionType : ObjectGraphType<Consumption>
    {
        public ConsumptionType()
        {
            Field(x => x.Id);
            Field(x => x.Consumable, type: typeof(ConsumableType)).Description("consumable");
            Field(x => x.Meal, type: typeof(MealType)).Description("meal");
            Field(c => c.CreatedAt);
        }
    }
}