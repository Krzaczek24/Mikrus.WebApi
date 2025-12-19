using Krzaq.Mikrus.WebApi.Core.Settings;
using Krzaq.Mikrus.WebApi.Services;
using System.Collections.Frozen;

namespace Krzaq.Mikrus.WebAPI
{
    public class Program
    {
        private const string DOC_NAME = "swagger";
        public const string ENDPOINT = $"/openapi/{DOC_NAME}.json";

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile("config.json", optional: false);

            if (builder.Environment.IsDevelopment())
            {
                builder.Configuration.AddUserSecrets("9baf5575-8b9b-478c-bea8-aceb5802cbcb");
            }
            else
            {
                builder.Configuration.AddCommandLine(args, new Dictionary<string, string>
                {
                    ["--db-password"] = "database:mikrus:password"
                });
            }

            builder.Services.Configure<DatabaseConfig>(builder.Configuration.GetSection("database:mikrus"));

            builder.Services.AddSingleton<IDbConnectionStringProvider, DbConnectionStringProvider>();

            builder.Services.AddControllers();
            builder.Services.AddOpenApi(DOC_NAME);

            var app = builder.Build();

            app.MapOpenApi();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerUI(opts => opts.SwaggerEndpoint(ENDPOINT, nameof(WebAPI)));
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
