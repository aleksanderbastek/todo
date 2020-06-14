using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TodoApp.Cqrs.Types;
using TodoApp.Domain.Handlers;

namespace TodoApp.Cqrs
{
	static public class Setup
	{
		public static IServiceCollection AddCqrsSetup(this IServiceCollection services)
		{
			services.AddMediatR(
				TodoDomainHandlers.GetAssembly()
			);
				
			services.AddCqrsTypesSetup();

			return services;
		}
	}
}
