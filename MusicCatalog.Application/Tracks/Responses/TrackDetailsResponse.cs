using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MusicCatalog.Application.Mappings;
using MusicCatalog.Domain.Entities;

namespace MusicCatalog.Application.Tracks.Responses
{
    public class TrackDetailsResponse : IMap
    {
        public Guid Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int DurationMinutes { get; set; }
        public int DurationSeconds { get; set; }
        public Guid AlbumId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Track, TrackDetailsResponse>();
        }
    }
}
