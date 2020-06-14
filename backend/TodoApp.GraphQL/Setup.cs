using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TodoApp.GraphQL.Types;
using HotChocolate.AspNetCore.Voyager;
using TodoApp.Api.Boards;
using TodoApp.Api.Todos;

namespace TodoApp.Graphql
{
	public static class GraphQLServiceSetup
    {
        public static IServiceCollection AddGraphQLSetup(this IServiceCollection services)
        {
			var schemaBuilder = SchemaBuilder.New()
				.AddQueryType(d => d.Name("Query"))
				.AddMutationType(d => d.Name("Mutation"))

				.AddRoot<BoardsQueryRoot>(services)
				.AddRoot<BoardsMutationRoot>(services)

				.AddRoot<TodosQueryRoot>(services)
				.AddRoot<TodosMutationRoot>(services);


			services.AddGraphQL(sp => schemaBuilder
                .AddServices(sp)
                .Create()
            );

            return services;
        }

        public static IApplicationBuilder UseGraphQLSetup(this IApplicationBuilder app, IHostEnvironment env) {
            app.UseGraphQL("/graphql");

            if (env.IsDevelopment()) {
                app
                    .UsePlayground("/graphql", "/graphql/playground")
                    .UseVoyager("/graphql", "/graphql/voyager");
            }

            return app;
        }
    }
}
