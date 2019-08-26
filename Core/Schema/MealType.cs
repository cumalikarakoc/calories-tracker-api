using DataContext.Models;
using GraphQL.Types;

namespace Core.Schema
{
    public class MealType : ObjectGraphType<Meal>
    {
        public MealType()
        {
            Field(m => m.Id);
            Field(m => m.Name);
        }
    }
}