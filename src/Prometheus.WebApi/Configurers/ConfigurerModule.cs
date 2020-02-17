using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prometheus.Core.Models;

namespace Prometheus.WebApi.Configurers
{
    public static class ConfigurerModule
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppConfiguration>(configuration);
            var appConfiguration = configuration.Get<AppConfiguration>();

            SwaggerConfigurer.Configure(services,configuration,appConfiguration);
            AuthConfigurer.Configure(services,configuration,appConfiguration);
        }        
    }
}