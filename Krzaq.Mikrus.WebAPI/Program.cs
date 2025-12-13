namespace Krzaq.Mikrus.WebAPI
{
    public class Program
    {
        private const string DOC_NAME = "swagger";
        public const string ENDPOINT = $"/openapi/{DOC_NAME}.json";

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddOpenApi(DOC_NAME);

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(opts => opts.SwaggerEndpoint(ENDPOINT, nameof(WebAPI)));
            }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
