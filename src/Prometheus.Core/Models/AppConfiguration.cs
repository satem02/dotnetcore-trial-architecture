namespace Prometheus.Core.Models
{
    public class AppConfiguration
    {
        public SwaggerInfo SwaggerInfo { get; set; }

        public AuthenticationInfo AuthenticationInfo { get; set; }

        public DatabaseInfo ConnectionStrings { get; set; }
    }
}