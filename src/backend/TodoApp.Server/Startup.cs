using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TodoApp.Cqrs;
using TodoApp.Domain.Contexts;
using TodoApp.Domain.Repositories.Abstractions.Readable;
using TodoApp.Domain.Repositories.Abstractions.Writable;
using TodoApp.Domain.Repositories.Concretes.Readable;
using TodoApp.Domain.Repositories.Concretes.Writable;
using TodoApp.Graphql;

namespace TodoApp.Server
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<TodoDbContext>(optionsBuilder => optionsBuilder.UseNpgsql(
				Environment.GetEnvironmentVariable("MAIN_DB_CONNECTION_STRING")
			), ServiceLifetime.Transient);

			services
				// Board repositories
				.AddTransient<IWritableBoardRepository, WritableBoardRepository>()
				.AddTransient<IReadableBoardRepository, ReadableBoardRepository>()
				// Todo repositories
				.AddTransient<IWritableTodoRepository, WritableTodoRepository>()
				.AddTransient<IReadableTodoRepository, ReadableTodoRepository>();

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
			using (var serviceScope = app.ApplicationServices.CreateScope())
			{
				var logger = serviceScope.ServiceProvider.GetService<ILogger<Startup>>();
				var context = serviceScope.ServiceProvider.GetService<TodoDbContext>();

				var pendingMigrationsCount = context.Database.GetPendingMigrations().Count();
				var migrationsPluralForm = "migration" + (pendingMigrationsCount > 1 ? "s" : "");

				if (pendingMigrationsCount > 0)
				{
					logger.LogWarning(
						$"Merging {pendingMigrationsCount} pending " +
						$"{migrationsPluralForm} into database"
					);

					context.Database.Migrate();

					logger.LogWarning("Database migration complete");
				}

				var migrationsAssembly = context.GetService<IMigrationsAssembly>();
				var differ = context.GetService<IMigrationsModelDiffer>();

				var modelSnapshotIsDifferent = differ.HasDifferences(
					migrationsAssembly.ModelSnapshot.Model,
					context.Model
				);

				if (modelSnapshotIsDifferent)
				{
					var errorMessage =
						"Actual model snapshot differs ModelSnapshot applied to database!\n" +
						"Model must be up to date with the latest ModelSnapshot to run this application.\n" +
						"Review your changes and add missing migration using following command:\n" +
						"dotnet ef migrations add MigrationName -p TodoApp.Domain.Contexts --startup-project TodoApp.Server";

					logger.LogCritical(errorMessage);
					throw new Exception(errorMessage);
				}
			}

			app.UseCors("AllowAll");

			if (env.IsDevelopment())
			{
				app
					.UseDeveloperExceptionPage()
					.UseRouting()
					.UseEndpoints(endpoints =>
					{
						endpoints.MapGet("/", async context =>
						{
							await context.Response.WriteAsync(
								"<html><body>" +
								"<h1>This is a GraphQL backend</h1>" +
								"<p style=\"font-size: 1.5rem\"> " +
								"GraphQL endpoint: <a href=\"/graphql\">/graphql</a>.<br />" +
								"GraphQL Playground: <a href=\"/graphql/playground\">/graphql/playground</a>.<br />" +
								"GraphQL Voyager: <a href=\"/graphql/voyager\">/graphql/voyager</a>.<br />" +
								"PgAdmin 4: <a href=\"http://localhost:5050/\">http://localhost:5050</a>.</p>" +
								"</body></html>"
							);
						});
					});
			}

			app.UseGraphQLSetup(env);
		}
	}
}
