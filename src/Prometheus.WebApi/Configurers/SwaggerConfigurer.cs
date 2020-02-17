using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag;
using NSwag.Generation.Processors.Security;
using Prometheus.Core.Models;

namespace Prometheus.WebApi.Configurers
{
    public static class SwaggerConfigurer
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration , AppConfiguration appConfiguration)
        {
            var swaggerInfo = appConfiguration.SwaggerInfo;

            services.AddOpenApiDocument(configure =>
            {
                configure.Version = swaggerInfo.Version;
                configure.Title = swaggerInfo.Title;
                configure.Description = swaggerInfo.Description;
                configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = swaggerInfo.Name,
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = swaggerInfo.Description
                });

                configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });
        }        
    }
}