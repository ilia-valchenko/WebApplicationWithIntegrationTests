using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebApplicationWithIntegrationTests.Repositories.Interfaces;

namespace WebApplicationWithIntegrationTests.Repositories.Infrastructure
{
    public static class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.TryAddScoped<IPersonRepository, PersonRepository>();
        }
    }
}