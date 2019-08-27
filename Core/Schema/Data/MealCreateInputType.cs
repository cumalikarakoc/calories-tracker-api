using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema.Data
{
    public class MealCreateInputType : InputObjectGraphType<Meal>
    {
        public MealCreateInputType()
        {
            Name = "mealInput";

            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}