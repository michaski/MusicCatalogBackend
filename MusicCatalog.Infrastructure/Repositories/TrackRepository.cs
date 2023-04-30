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
    public class TrackRepository : ITrackRepository
    {
        private readonly MusicCatalogDataContext _context;

        public TrackRepository(MusicCatalogDataContext context)
        {
            _context = context;
        }

        public async Task<Track> GetTrackByIdAsync(Guid id)
        {
            return await _context.Tracks
                .FirstOrDefaultAsync(track => track.Id == id);
        }

        public async Task<Track> CreateTrackAsync(Track track)
        {
            _context.Tracks.Add(track);
            await _context.SaveChangesAsync();
            return track;
        }

        public async Task UpdateTrackAsync(Track track)
        {
            _context.Tracks.Update(track);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTrackAsync(Track track)
        {
            _context.Tracks.Remove(track);
            await _context.SaveChangesAsync();
        }
    }
}
