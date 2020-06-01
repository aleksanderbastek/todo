using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoApp.Graphql;

namespace TodoApp.Server
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGraphQLSetup();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
                                "<h1>This is a GraphQL backend</h1> <p style=\"font-size: 1.5rem\">Access GraphQL endpoint under /graphql " + 
                                "or if you want to play with it go to <a href=\"/graphql/playground\">/graphql/playground</a>.</p>" +
                                "</body></html>"
                            );
                        });
                    });
            }
            
            app.UseGraphQLSetup(env);
        }
    }
}
