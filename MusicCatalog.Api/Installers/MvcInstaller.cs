using MusicCatalog.Application;
using MusicCatalog.Infrastructure;

namespace MusicCatalog.Api.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplication();
            services.AddInfrastructure();
            services.AddControllers();
        }
    }
}
