using Microsoft.Extensions.DependencyInjection;
using WebApplicationWithIntegrationTests.Services.Interfaces;

namespace WebApplicationWithIntegrationTests.Services.Infrastructure
{
    public static class Bootstrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();

            Repositories.Infrastructure.Bootstrapper.RegisterServices(services);
        }
    }
}