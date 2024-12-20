namespace Advanced_ASP.NET.HealthChecks
{
    using Microsoft.Extensions.Diagnostics.HealthChecks;
    using System.Text.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public class ProductHealthCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var jsonFilePath = "Resources\\Teachers.json";

            var jsonData = await File.ReadAllTextAsync(jsonFilePath);

            var teachersData = JsonSerializer.Deserialize<List<Teacher>>(jsonData);

            int teachers = teachersData.Count();

            if (teachers > 0)
            {
                return HealthCheckResult.Healthy($"There are {teachers} teachers available.");
            }
            else
            {
                return HealthCheckResult.Unhealthy($"There are {teachers} teachers available.");
            }
        }
    }
}
