using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
using Template.Core.Dependency;

namespace Template.Web.Host.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection service)
        {
            var assembly = Assembly.Load(new AssemblyName("Template.Core"));

            var types = assembly.GetTypes()
                .Where(type => type.GetInterface(nameof(ITransientDependency)) != null ||
                    type.GetInterface(nameof(IScopedDependency)) != null ||
                    type.GetInterface(nameof(ISingletonDependency)) != null)
                .Where(type => type.IsClass);

            foreach (var type in types)
            {
                var @interface = type.GetInterfaces()
                    .Where(inter => inter.Name != nameof(ITransientDependency) &&
                        inter.Name != nameof(IScopedDependency) &&
                        inter.Name != nameof(ISingletonDependency))
                    .SingleOrDefault();

                if (type.GetInterface(nameof(ITransientDependency)) != null)
                {
                    service.AddTransient(@interface, type);
                }

                if (type.GetInterface(nameof(ISingletonDependency)) != null)
                {
                    service.AddSingleton(@interface, type);
                }

                if (type.GetInterface(nameof(IScopedDependency)) != null)
                {
                    service.AddScoped(@interface, type);
                }
            }
        }
    }
}
