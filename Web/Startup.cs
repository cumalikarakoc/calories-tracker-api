using System;
using Core.Schema;
using Core.Schema.Data;
using Core.Services;
using DataContext.Data;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prometheus;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CaloriesContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddTransient<IDependencyResolver>(
                c => new FuncDependencyResolver(type => c.GetRequiredService(type)));

            
            //Services
            services.AddTransient<ConsumptionService>();
            services.AddTransient<MealService>();
            services.AddTransient<ConsumableService>();
            
            //Types
            services.AddTransient<MealType>();
            services.AddTransient<ConsumableType>();
            services.AddTransient<ConsumptionType>();
            
            //Input types
            services.AddTransient<ConsumableCreateInputType>();
            services.AddTransient<MealCreateInputType>();
            
            // Schema setup
            services.AddTransient<SchemaQuery>(); 
            services.AddTransient<SchemaMutation>();

            services.AddTransient<CaloriesTrackerSchema>();


            services.AddGraphQL(options =>
                {
                    options.EnableMetrics = true;
                    options.ExposeExceptions = true;
                })
                .AddWebSockets()
                .AddDataLoader();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMetricServer();
            app.UseHttpMetrics();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();
            app.UseGraphQLWebSockets<CaloriesTrackerSchema>();
            app.UseGraphQL<CaloriesTrackerSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
            {
                Path = "/ui/playground"
            });
            app.UseGraphiQLServer(new GraphiQLOptions
            {
                GraphiQLPath = "/ui/graphiql",
                GraphQLEndPoint = "/graphql"
            });
        }
    }
}