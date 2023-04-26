using System.Reflection;

namespace MusicCatalog.Api.Installers
{
    public static class InstallerExtensions
    {
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration, Assembly assembly)
        {
            var installers = assembly.GetTypes()
                .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IInstaller>()
                .ToList();
            foreach (var installer in installers)
            {
                installer.InstallServices(services, configuration);
            }
        }
    }
}
