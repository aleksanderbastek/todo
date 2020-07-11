using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoApp.GraphQL.Types;
using TodoApp.Api.Query;
using TodoApp.Api.Mutation;
using GraphQLUi = GraphQL.Server.Ui;

namespace TodoApp.Graphql
{
	public static class GraphQLServiceSetup
	{
		public static IServiceCollection AddGraphQLSetup(this IServiceCollection services)
		{
			var schemaBuilder = SchemaBuilder.New()
				.AddQueryType(d => d.Name("Query"))
				.AddMutationType(d => d.Name("Mutation"))
				.AddRoot<TodoQueryRoot>(services)
				.AddRoot<TodoMutationRoot>(services);

			services.AddGraphQL(sp => schemaBuilder
				.AddServices(sp)
				.Create()
			);

			return services;
		}

		public static IApplicationBuilder UseGraphQLSetup(this IApplicationBuilder app, IHostEnvironment env)
		{
			app.UseGraphQL("/graphql");

			if (env.IsDevelopment())
			{
				GraphQLUi.Playground.PlaygroundExtensions.UseGraphQLPlayground(app,
					new GraphQLUi.Playground.GraphQLPlaygroundOptions
					{
						GraphQLEndPoint = "/graphql",
						Path = "/graphql/playground"
					}
				);

				GraphQLUi.Voyager.VoyagerExtensions.UseGraphQLVoyager(app,
					new GraphQLUi.Voyager.GraphQLVoyagerOptions
					{
						GraphQLEndPoint = "/graphql",
						Path = "/graphql/voyager"
					}
				);
			}

			return app;
		}
	}
}
