using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TodoApp.GraphQL.Types;
using HotChocolate.AspNetCore.Voyager;
using TodoApp.GraphQL.Hello.Providers;
using TodoApp.GraphQL.Hello.Roots;

namespace TodoApp.Graphql
{
	public static class GraphQLServiceSetup
    {
        public static IServiceCollection AddGraphQLSetup(this IServiceCollection services)
        {
			services.AddSingleton<ITestingHelloWordProvider>(new TestingHelloWordProvider());

			var schemaBuilder = SchemaBuilder.New()
                .AddQueryType(d => d.Name("Query"))
                .AddMutationType(d => d.Name("Mutation"))
				.AddRoot<HelloQueryRoot>(services)
				.AddRoot<HelloMutationRoot>(services);


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
