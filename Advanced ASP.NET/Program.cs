using Advanced_ASP.NET.HealthChecks;
using Advanced_ASP.NET.Models;
using Advanced_ASP.NET.Services;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

namespace Advanced_ASP.NET
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRateLimiter(options =>

            {
                options.AddFixedWindowLimiter(policyName: "fixed", options =>
                {
                    options.PermitLimit = 3;
                    options.Window = TimeSpan.FromMinutes(1);
                    options.QueueLimit = 2;
                    options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                });
            });

            builder.Services.AddControllers();
            builder.Services.AddScoped<SpellsService>();
            builder.Services.AddScoped<SpellsModel>();
            builder.Services.AddScoped<TeacherModel>();
            builder.Services.AddScoped<TeacherService>();
            builder.Services.AddScoped<SpellService>();
            builder.Services.AddScoped<SpellModel>();

            builder.Services.AddHealthChecks()
                 .AddCheck<ProductHealthCheck>("teachers_exist_health_check",
                     failureStatus: HealthStatus.Unhealthy,
                     tags: new[] { "file" });
            
            var app = builder.Build();

            app.UseRouting();

            app.UseRateLimiter();

            app.UseHealthChecks("/health");

            app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapControllers();  // discard pattern '_' ignores the return value of 'MapControllers' because no further configuration of the endpoints is required
            });

            app.Run();
        }
    }
}

