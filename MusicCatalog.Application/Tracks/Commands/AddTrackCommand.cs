using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MusicCatalog.Application.Mappings;
using MusicCatalog.Application.Tracks.Responses;
using MusicCatalog.Domain.Entities;

namespace MusicCatalog.Application.Tracks.Commands
{
    public class AddTrackCommand : IRequest<TrackManipulationResponse>, IMap
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int DurationMinutes { get; set; }
        public int DurationSeconds { get; set; }
        public Guid AlbumId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddTrackCommand, Track>();
        }
    }
}
