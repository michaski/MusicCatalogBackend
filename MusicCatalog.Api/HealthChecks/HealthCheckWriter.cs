using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace MusicCatalog.Api.HealthChecks
{
    public static class HealthCheckWriter
    {
        public static async Task WriteHealthCheckResponseAsync(HttpContext context, HealthReport report)
        {
            context.Response.ContentType = "application/json";
            var response = new HealthCheckResponse
            {
                Status = report.Status.ToString(),
                Checks = report.Entries.Select(entry => new HealthCheck
                {
                    Component = entry.Key,
                    Status = entry.Value.Status.ToString(),
                    Description = entry.Value.Description
                }),
                Duration = report.TotalDuration
            };
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
