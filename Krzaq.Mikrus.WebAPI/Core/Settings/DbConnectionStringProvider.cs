using Microsoft.Extensions.Options;

namespace Krzaq.Mikrus.WebApi.Core.Settings
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
            return $"Server={cfg.Host};Port={cfg.Port};Uid={cfg.User};Pwd={cfg.Password};Database={cfg.Schema};";
        }
    }
}
