using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicCatalog.Domain.Entities;
using MusicCatalog.Domain.Enums;
using MusicCatalog.Domain.Interfaces;
using MusicCatalog.Domain.Utils;
using MusicCatalog.Infrastructure.Data;
using MusicCatalog.Infrastructure.Extensions;

namespace MusicCatalog.Infrastructure.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly MusicCatalogDataContext _context;

        public AlbumRepository(MusicCatalogDataContext context)
        {
            _context = context;
        }

        public async Task<ResultPage<Album>> GetProvidersAlbumsAsync(string providerId, QueryFilters filters)
        {
            var providerAlbums = _context.Albums
                .Include(album => album.Type)
                .Where(album => album.ProviderId == providerId);

            providerAlbums = filters.SearchIn switch
            {
                AlbumFields.Artist => providerAlbums.SearchInField(album => album.Artist, filters.SearchPhrase),
                AlbumFields.Title => providerAlbums.SearchInField(album => album.Title, filters.SearchPhrase),
                AlbumFields.ReleaseYear => providerAlbums.SearchInField(album => album.ReleaseYear.ToString(),
                    filters.SearchPhrase),
                _ => providerAlbums
            };

            providerAlbums = filters.OrderBy switch
            {
                AlbumFields.Artist => providerAlbums.OrderBy(album => album.Artist, filters.Ordering),
                AlbumFields.Title => providerAlbums.OrderBy(album => album.Title, filters.Ordering),
                AlbumFields.ReleaseYear => providerAlbums.OrderBy(album => album.ReleaseYear, filters.Ordering),
                _ => providerAlbums
            };

            return await providerAlbums.ToResultPageAsync(filters);
        }

        public async Task<Album?> GetByIdAsync(Guid id)
        {
            return await _context.Albums
                .Include(album => album.Type)
                .Include(album => album.Tracks)
                .FirstOrDefaultAsync(album => album.Id == id);
        }

        public async Task<Album> CreateNewAlbumAsync(Album album)
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
