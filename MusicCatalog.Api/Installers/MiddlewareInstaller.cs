using MusicCatalog.Api.Middleware;

namespace MusicCatalog.Api.Installers
{
    public class MiddlewareInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ErrorHandlingMiddleware>();
        }
    }
}
