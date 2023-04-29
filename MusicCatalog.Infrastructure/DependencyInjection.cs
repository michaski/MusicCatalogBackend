using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MusicCatalog.Domain.Interfaces;
using MusicCatalog.Infrastructure.Repositories;

namespace MusicCatalog.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<ITrackRepository, TrackRepository>();
            services.AddScoped<IAlbumTypesRepository, AlbumTypesRepository>();

            return services;
        }
    }
}
