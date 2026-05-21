using Microsoft.EntityFrameworkCore;
using ChickenAPI.Model;
using Microsoft.Extensions.Options;
namespace ChickenAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<Model.FarmDbContext>(options =>
                options.UseSqlServer(Environment.GetEnvironmentVariable("SQL_CONNECTION_STRING")));

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            var app = builder.Build();
            if (true)
            {
                app.MapOpenApi();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/openapi/v1.json", "Chicken API V1");
                    options.RoutePrefix = "swagger";
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
