using System.Linq;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TodoApp.Cqrs.Types.Abstract;
using TodoApp.Cqrs.Types.Concretes;

namespace TodoApp.Cqrs.Types
{
	public static class CqrsTypesSetup
	{
		public static IServiceCollection AddCqrsTypesSetup(this IServiceCollection services)
		{
			services.AddScoped<IQueryProcessor, QueryProcessor>();
			services.AddScoped<ICommandProcessor, CommandProcessor>();

			return services;
		}

		public static IServiceCollection AddMediatorHandlers(this IServiceCollection services, Assembly assembly)
		{
			var classTypes = assembly.ExportedTypes
				.Select(t => t.GetTypeInfo())
				.Where(t => t.IsClass && !t.IsAbstract);

			foreach (var type in classTypes)
			{
				var requestHandlers = type.ImplementedInterfaces
					.Select(i => i.GetTypeInfo())
					.Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>));

				foreach (var handlerType in requestHandlers)
				{
					services.AddTransient(handlerType.AsType(), type.AsType());
				}
			}

			return services;
		}
	}
}
