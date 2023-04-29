using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MusicCatalog.Application.Mappings;
using MusicCatalog.Domain.Entities;

namespace MusicCatalog.Application.AlbumTypes.Responses
{
    public class ListAlbumTypesResponse : IMap
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AlbumType, ListAlbumTypesResponse>();
        }
    }
}
