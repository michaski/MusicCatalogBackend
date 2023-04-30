using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MusicCatalog.Application.Albums.Responses;
using MusicCatalog.Application.Dtos.Tracks;
using MusicCatalog.Application.Mappings;
using MusicCatalog.Domain.Entities;

namespace MusicCatalog.Application.Albums.Commands
{
    public class CreateNewAlbumCommand : IRequest<AlbumDetailsResponse>, IMap
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public Guid TypeId { get; set; }
        public IEnumerable<NewTrackDto> Tracks { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNewAlbumCommand, Album>();
        }
    }
}
