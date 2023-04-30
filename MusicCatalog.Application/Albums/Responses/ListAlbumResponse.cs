using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MusicCatalog.Application.Mappings;
using MusicCatalog.Domain.Entities;

namespace MusicCatalog.Application.Albums.Responses
{
    public class ListAlbumResponse : IMap
    {
        public Guid Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Type { get; set; }
        public string Provider { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Album, ListAlbumResponse>()
                .ForMember(resp => resp.Type, opt => opt.MapFrom(album => album.Type.Name))
                .ForMember(resp => resp.Provider, opt => opt.MapFrom(album => album.Provider.UserName));
        }
    }
}
