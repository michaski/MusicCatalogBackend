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
    public class AlbumRepository : IAlbumRepository
    {
        private readonly MusicCatalogDataContext _context;

        public AlbumRepository(MusicCatalogDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Album>> GetProvidersAlbumsAsync(Guid providerId)
        {
            return await _context.Albums
                .Where(album => album.ProviderId == providerId)
                .ToListAsync();
        }

        public async Task<Album?> GetByIdAsync(Guid id)
        {
            return await _context.Albums
                .FirstOrDefaultAsync(album => album.Id == id);
        }

        public async Task<Album> InsertNewAlbumAsync(Album album)
        {
            _context.Albums.Add(album);
            await _context.SaveChangesAsync();
            return album;
        }

        public async Task UpdateAlbumAsync(Album album)
        {
            _context.Albums.Update(album);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAlbumAsync(Album album)
        {
            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();
        }
    }
}
