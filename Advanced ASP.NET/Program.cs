using Advanced_ASP.NET.HealthChecks;
using Advanced_ASP.NET.Models;
using Advanced_ASP.NET.Services;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Advanced_ASP.NET
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddScoped<SpellsService>();
            builder.Services.AddScoped<SpellsModel>();

            builder.Services.AddHealthChecks()
                 .AddCheck<ProductHealthCheck>("teachers_exist_health_check",
                     failureStatus: HealthStatus.Unhealthy,
                     tags: new[] { "file" });
            
            var app = builder.Build();

            app.UseHealthChecks("/health");

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapControllers();  // discard pattern '_' ignores the return value of 'MapControllers' because no further configuration of the endpoints is required
            });

            app.Run();
        }
    }
}

