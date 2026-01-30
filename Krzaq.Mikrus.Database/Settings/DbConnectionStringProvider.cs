using Microsoft.Extensions.Options;

namespace Krzaq.Mikrus.Database.Settings
{
    public interface IDbConnectionStringProvider
    {
        string GetConnectionString();
    }

    internal class DbConnectionStringProvider(IOptions<DatabaseConfig> config) : IDbConnectionStringProvider
    {
        public string GetConnectionString()
        {
            var cfg = config.Value;
            return $"Server={cfg.Host};Port={cfg.Port};Uid={cfg.User};Pwd={cfg.Password};Database={cfg.Schema};";
        }
    }
}
