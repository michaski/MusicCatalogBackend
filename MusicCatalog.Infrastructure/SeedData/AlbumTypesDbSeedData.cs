using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicCatalog.Domain.Entities;

namespace MusicCatalog.Infrastructure.SeedData
{
    public static class AlbumTypesDbSeedData
    {
        public static AlbumType[] AlbumTypes = new AlbumType[]
        {
            new AlbumType
            {
                Id = Guid.NewGuid(),
                Name = "Studio"
            },
            new AlbumType
            {
                Id = Guid.NewGuid(),
                Name = "LP"
            },
            new AlbumType
            {
                Id = Guid.NewGuid(),
                Name = "EP"
            },
            new AlbumType
            {
                Id = Guid.NewGuid(),
                Name = "Live"
            },
            new AlbumType
            {
                Id = Guid.NewGuid(),
                Name = "Soundtrack"
            },
            new AlbumType
            {
                Id = Guid.NewGuid(),
                Name = "Medley"
            }
        };
    }
}
