using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MusicCatalog.Application.Dtos.Tracks;
using MusicCatalog.Domain.Entities;

namespace MusicCatalog.Application.Mappings.CustomResolvers.Tracks
{
    public class TrackDurationResolver : IValueResolver<Track, TrackListDto, string>
    {
        public string Resolve(Track source, TrackListDto destination, string destMember, ResolutionContext context)
        {
            return $"{source.DurationMinutes}:{source.DurationSeconds:00}";
        }
    }
}
