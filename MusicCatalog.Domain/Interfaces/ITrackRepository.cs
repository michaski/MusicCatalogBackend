using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicCatalog.Domain.Entities;

namespace MusicCatalog.Domain.Interfaces
{
    public interface ITrackRepository
    {
        Task<IEnumerable<Track>> InsertTracksAsync(IEnumerable<Track> tracks);
        Task UpdateTrackAsync(Track track);
        Task DeleteTrackAsync(Track track);
    }
}
