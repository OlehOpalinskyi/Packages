using Microsoft.Extensions.DependencyInjection;
using WebApi.Common.Exception.Contracts;

namespace WebApi.Common.Exception
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddExceptionFactory(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IExceptionFactory, ExceptionFactory>();
            return serviceCollection;
        }

        public static IServiceCollection AddJsonExceptionStore(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IExceptionStore, JsonExceptionStore>();
            return serviceCollection;
        }
    }
}