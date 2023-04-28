using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MusicCatalog.Application.Auth.Responses;
using MusicCatalog.Application.Mappings;
using MusicCatalog.Domain.Entities;

namespace MusicCatalog.Application.Auth.Commands.Register
{
    public class RegisterCommand : IRequest<RegisterResponse>, IMap
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<RegisterCommand, User>()
                .ForMember(u => u.UserName, cfg => cfg.MapFrom(cmd => cmd.Name));
        }
    }
}
