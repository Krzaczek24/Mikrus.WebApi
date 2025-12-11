namespace Krzaq.Mikrus.WebAPI
{
    public class Program
    {
        private const string documentName = "swagger";

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddOpenApi(documentName);

            var app = builder.Build();

            app.MapOpenApi();
            app.UseSwaggerUI(opts => opts.SwaggerEndpoint($"/openapi/{documentName}.json", nameof(Krzaq.Mikrus.WebAPI)));

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
