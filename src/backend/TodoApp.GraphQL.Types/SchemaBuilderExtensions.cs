using System.Linq;
using System;
using HotChocolate;
using Microsoft.Extensions.DependencyInjection;

namespace TodoApp.GraphQL.Types
{
    public static class SchemaBuilderExtensions
    {
        public static ISchemaBuilder AddRoot<TRootType>(this ISchemaBuilder schemaBuilder, IServiceCollection services) {
			ConfigureDependencyInjectionForType(typeof(TRootType), services);
			schemaBuilder.AddType<TRootType>();
			return schemaBuilder;
		}

		private static void ConfigureDependencyInjectionForType(Type type, IServiceCollection services) {
			if (services.Any(s => s.ServiceType == type)) {
				return; // prevent adding the same type again
			}

			var numberOfCtors = type.GetConstructors().Length;

			if (numberOfCtors > 1) {
				throw new Exception(
					$"Cannot configure dependency injection for {type.FullName} " +
					"because type has more than one constructor"
				);
			}

			if (numberOfCtors == 0) {
				services.AddTransient(type);
				return;
			}

			var ctor = type.GetConstructors().First();

			if (ctor.GetParameters().Length < 1) {
				services.AddTransient(type);
				return;
			}

			foreach (var param in ctor.GetParameters()) {
				if (param.ParameterType.IsInterface) {
					continue;
				}

				ConfigureDependencyInjectionForType(param.ParameterType, services);
			}

			services.AddTransient(type);
		}
    }
}
