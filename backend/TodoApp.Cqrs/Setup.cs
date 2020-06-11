using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TodoApp.Cqrs.Hello.Queries;
using TodoApp.Cqrs.Types;

namespace TodoApp.Cqrs
{
	static public class Setup
	{
		public static IServiceCollection AddCqrsSetup(this IServiceCollection services)
		{
			services.AddMediatR(typeof(GetHelloStringQuery).Assembly);
			services.AddCqrsTypesSetup();

			return services;
		}
	}
}
