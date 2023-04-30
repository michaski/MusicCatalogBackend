using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MusicCatalog.Application.Mappings;
using MusicCatalog.Domain.Entities;

namespace MusicCatalog.Application.Dtos.Tracks
{
    public class NewTrackDto : IMap
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public int DurationMinutes { get; set; }
        public int DurationSeconds { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewTrackDto, Track>();
        }
    }
}
