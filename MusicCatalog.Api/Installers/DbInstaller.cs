using Microsoft.EntityFrameworkCore;
using MusicCatalog.Infrastructure.Data;

namespace MusicCatalog.Api.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MusicCatalogDataContext>(opt =>
                opt.UseNpgsql(configuration.GetConnectionString("DataConnection")));
        }
    }
}
