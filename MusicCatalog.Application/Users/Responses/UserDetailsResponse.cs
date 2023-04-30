using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MusicCatalog.Application.Mappings;
using MusicCatalog.Domain.Entities;

namespace MusicCatalog.Application.Users.Responses
{
    public class UserDetailsResponse : IMap
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailsResponse>()
                .ForMember(res => res.Name, opt => opt.MapFrom(u => u.UserName))
                .ForMember(res => res.Id, opt => opt.MapFrom(u => Guid.Parse(u.Id)));
        }
    }
}
