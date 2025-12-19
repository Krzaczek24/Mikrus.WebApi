using Krzaq.Mikrus.WebApi.Core.Settings;
using Microsoft.Extensions.Options;

namespace Krzaq.Mikrus.WebApi.Services
{
    public interface IDbConnectionStringProvider
    {
        string GetConnectionString();
    }

    public class DbConnectionStringProvider(IOptions<DatabaseConfig> config) : IDbConnectionStringProvider
    {
        public string GetConnectionString()
        {
            var cfg = config.Value;
            return $"Host={cfg.Host}:{cfg.Port};Password={cfg.Password}";
        }
    }
}
