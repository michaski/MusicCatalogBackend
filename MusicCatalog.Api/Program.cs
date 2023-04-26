using System.Reflection;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using MusicCatalog.Api.HealthChecks;
using MusicCatalog.Api.Installers;
using MusicCatalog.Api.Middleware;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.InstallServicesInAssembly(builder.Configuration, Assembly.GetExecutingAssembly());

// Add NLog
builder.Logging.ClearProviders();
builder.Host.UseNLog();

var app = builder.Build();

var apiVersionDescriptorProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = HealthCheckWriter.WriteHealthCheckResponseAsync
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var apiVersionDescription in apiVersionDescriptorProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{apiVersionDescription.GroupName}/swagger.json", 
                apiVersionDescription.GroupName.ToUpperInvariant());
        }
    });
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
