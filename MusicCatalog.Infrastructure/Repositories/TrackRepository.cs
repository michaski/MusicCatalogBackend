using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Track>> CreateTracksAsync(IEnumerable<Track> tracks)
        {
            _context.Tracks.AddRange(tracks);
            await _context.SaveChangesAsync();
            return tracks;
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
