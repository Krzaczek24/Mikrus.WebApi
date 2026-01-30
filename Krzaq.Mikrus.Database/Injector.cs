using Krzaq.Mikrus.Database.Entities.User;
using Krzaq.Mikrus.Database.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Krzaq.Mikrus.Database
{
    public static class Injector
    {
        public static IServiceCollection AddAppDatabase(this IServiceCollection services, ILoggerFactory? loggerFactory = null)
            => services
                .AddConnectionStringProvider()
                .AddAppDbContext(loggerFactory)
                .AddTransactionManager()
                .AddAppDbAccesses();

        public static IServiceCollection AddConnectionStringProvider(this IServiceCollection services)
            => services.AddTransient<IDbConnectionStringProvider, DbConnectionStringProvider>();

        public static IServiceCollection AddAppDbContext(this IServiceCollection services, ILoggerFactory? loggerFactory = null)
            => services.AddDbContext<AppDbContext>((sp, opts) =>
            {
                var connStringProvider = sp.GetRequiredService<IDbConnectionStringProvider>();
                opts.UseMySQL(connStringProvider.GetConnectionString());
                opts.UseLoggerFactory(loggerFactory);
            });

        public static IServiceCollection AddTransactionManager(this IServiceCollection services)
            => services.AddTransient<ITransactionManager, TransactionManager>();

        public static IServiceCollection AddAppDbAccesses(this IServiceCollection services)
            => services
                .AddTransient<IDbUserAccess, DbUserAccess>();
    }
}
