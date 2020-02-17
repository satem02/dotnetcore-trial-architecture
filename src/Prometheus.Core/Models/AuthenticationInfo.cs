namespace Prometheus.Core.Models
{
    public class AuthenticationInfo
    {
        public JwtBearer JwtBearer { get; set; }
    }

    public class JwtBearer
    {
        public string IsEnabled { get; set; }
        public string SecurityKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}