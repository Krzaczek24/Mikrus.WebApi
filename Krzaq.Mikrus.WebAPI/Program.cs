using Krzaq.Extensions.String.Notation;
using Krzaq.Mikrus.Database;
using Krzaq.Mikrus.Database.Settings;
using Krzaq.Mikrus.WebApi.Core.Authorization;
using Krzaq.Mikrus.WebApi.Core.Errors;
using Krzaq.Mikrus.WebApi.Core.Extensions;
using Krzaq.Mikrus.WebApi.Core.Middlewares;
using Krzaq.Mikrus.WebApi.Core.Providers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NLog.Extensions.Logging;
using System.Text.Json;

namespace Krzaq.Mikrus.WebAPI
{
    public class Program
    {
        private const string DOC_NAME = "swagger";
        public const string ENDPOINT = $"/openapi/{DOC_NAME}.json";

#if DEBUG
        public const bool IS_DEBUG = true;
#else
        public const bool IS_DEBUG = false;
#endif

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
                    ["--db-password"] = "database:mikrus:password",
                    ["--api-key"] = "apikey",
                });
            }

            /*
            x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            */

            builder.Services.AddTransient<IApiKeyProvider, ApiKeyProvider>();
            builder.Services.AddTransient<IJwtTokenPovider, JwtTokenProvider>();

            builder.Services.AddAuthentication().AddJwtBearer(opts =>
            {
                var keyProvider = new ApiKeyProvider(builder.Configuration);

                opts.RequireHttpsMetadata = false;
                opts.SaveToken = true;
                opts.MapInboundClaims = false;
                opts.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = keyProvider.GetApiKey(),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    //RoleClaimType = UserClaim.Role.ToString().ToCamelCase(),
                    NameClaimType = UserClaim.DisplayName.ToString().ToCamelCase()
                };
            });

            builder.Services.ConfigureHttpJsonOptions(opts =>
            {
                opts.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });

            builder.Services.AddHttpContextAccessor();

            builder.Services.Configure<DatabaseConfig>(builder.Configuration.GetSection("database:mikrus"));

            builder.Services.AddAppDatabase(IS_DEBUG ? new LoggerFactory([new NLogLoggerProvider()]) : null);

            builder.Services.AddMediator().AddHandlers().AddValidators();

            builder.Services.AddControllers();
            builder.Services.AddOpenApi(DOC_NAME);

            builder.Services.Configure<ApiBehaviorOptions>(opts =>
            {
                opts.SuppressModelStateInvalidFilter = true;
                opts.SuppressConsumesConstraintForFormFileParameters = true;
            });

            var app = builder.Build();

            app.MapOpenApi();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerUI(x => x.SwaggerEndpoint(ENDPOINT, nameof(WebAPI)));
            }

            app.UseWhen(
                context => !context.Request.Path.StartsWithSegments("/openapi"),
                app => app.UseLoggingMiddleware()
            );

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
