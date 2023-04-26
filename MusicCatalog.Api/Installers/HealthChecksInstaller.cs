using MusicCatalog.Infrastructure.Data;

namespace MusicCatalog.Api.Installers
{
    public class HealthChecksInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddDbContextCheck<MusicCatalogDataContext>();
        }
    }
}
