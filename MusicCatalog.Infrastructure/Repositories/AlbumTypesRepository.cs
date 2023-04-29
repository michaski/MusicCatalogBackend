using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicCatalog.Domain.Entities;
using MusicCatalog.Domain.Interfaces;
using MusicCatalog.Infrastructure.Data;

namespace MusicCatalog.Infrastructure.Repositories
{
    public class AlbumTypesRepository : IAlbumTypesRepository
    {
        private readonly MusicCatalogDataContext _context;

        public AlbumTypesRepository(MusicCatalogDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AlbumType>> GetAllAsync()
        {
            return await _context.AlbumTypes.ToListAsync();
        }
    }
}
