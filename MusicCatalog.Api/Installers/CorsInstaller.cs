namespace MusicCatalog.Api.Installers
{
    public class CorsInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("MusicCatalogCorsPolicy", builder =>
                    builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithOrigins(configuration["AllowedOrigins"])
                );
            });
        }
    }
}
