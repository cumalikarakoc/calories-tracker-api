using GraphQL;

namespace Core.Schema
{
    public class CaloriesTrackerSchema : GraphQL.Types.Schema
    {
        public CaloriesTrackerSchema(SchemaQuery query, SchemaMutation mutation, IDependencyResolver resolver)
        {
            Query = query;
            Mutation = mutation;
            DependencyResolver = resolver;
        }
    }
}