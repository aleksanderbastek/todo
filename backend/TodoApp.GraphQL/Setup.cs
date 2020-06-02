using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TodoApp.GraphQL.Hello;
using TodoApp.GraphQL.Hello.Mutations;
using TodoApp.GraphQL.Hello.Queries;
using HotChocolate.AspNetCore.Voyager;

namespace TodoApp.Graphql
{
	public static class GraphQLServiceSetup
    {
        public static IServiceCollection AddGraphQLSetup(this IServiceCollection services)
        {
			services.AddSingleton<ITestingHelloWordProvider>(new TestingHelloWordProvider());

			services.AddGraphQL(sp => SchemaBuilder.New()
                .AddServices(sp)
                .AddQueryType(d => d.Name("Query"))
                .AddMutationType(d => d.Name("Mutation"))
                .AddType<HelloQuery>()
                .AddType<UserQuery>()
                .AddType<HelloMutation>()
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
