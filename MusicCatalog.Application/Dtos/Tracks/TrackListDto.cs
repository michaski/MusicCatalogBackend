using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MusicCatalog.Application.Mappings;
using MusicCatalog.Application.Mappings.CustomResolvers.Tracks;
using MusicCatalog.Domain.Entities;

namespace MusicCatalog.Application.Dtos.Tracks
{
    public class TrackListDto : IMap
    {
        public Guid Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Duration { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Track, TrackListDto>()
                .ForMember(dto => dto.Duration, opt => opt.MapFrom<TrackDurationResolver>());
        }
    }
}
