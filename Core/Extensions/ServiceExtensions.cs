using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection
            AddDependencyResolvers(this IServiceCollection services, params ICoreModule[] modules)
        {
            foreach (var module in modules)
                module.Load(services);
            return ServiceTool.Create(services);
        }
    }
}
