﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicCatalog.Domain.Entities;

namespace MusicCatalog.Domain.Interfaces
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<Album>> GetProvidersAlbumsAsync(string providerId);
        Task<Album?> GetByIdAsync(Guid id);
        Task<Album> CreateNewAlbumAsync(Album album);
        Task UpdateAlbumAsync(Album album);
        Task DeleteAlbumAsync(Album album);
    }
}
