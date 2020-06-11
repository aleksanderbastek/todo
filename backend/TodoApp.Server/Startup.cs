using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoApp.Cqrs;
using TodoApp.Graphql;

namespace TodoApp.Server
{
	public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddCors(o => o.AddPolicy("AllowAll", builder =>
			{
				builder
					.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader();

			}));

			services.AddCqrsSetup();
			services.AddGraphQLSetup();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
			app.UseCors("AllowAll");

			if (env.IsDevelopment())
            {
                app
                    .UseDeveloperExceptionPage()
                    .UseRouting()
                    .UseEndpoints(endpoints => {
                        endpoints.MapGet("/", async context =>
                        {
                            await context.Response.WriteAsync(
                                "<html><body>" +
                                "<h1>This is a GraphQL backend</h1>" +
                                "<p style=\"font-size: 1.5rem\"> " + 
                                "GraphQL endpoint: <a href=\"/graphql\">/graphql</a>.<br />" +
                                "GraphQL Playground: <a href=\"/graphql/playground\">/graphql/playground</a>.<br />" +
                                "GraphQL Voyager: <a href=\"/graphql/voyager\">/graphql/voyager</a>.</p>" +
                                "</body></html>"
                            );
                        });
                    });
            }
            
            app.UseGraphQLSetup(env);
        }
    }
}
