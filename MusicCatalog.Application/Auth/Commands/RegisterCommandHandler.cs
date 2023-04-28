using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MusicCatalog.Application.Auth.Responses;
using MusicCatalog.Domain.Entities;

namespace MusicCatalog.Application.Auth.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public RegisterCommandHandler(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<RegisterResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var mappedUser = _mapper.Map<RegisterCommand, User>(request);
            var result = await _userManager.CreateAsync(mappedUser, request.Password);
            if (!result.Succeeded)
            {
                return new RegisterResponse("Nie udało się utworzyć konta", result.Errors);
            }

            var createdUser = await _userManager.FindByEmailAsync(request.Email);
            result = await _userManager.AddToRoleAsync(createdUser, "User");
            if (!result.Succeeded)
            {
                return new RegisterResponse("Nie udało się utworzyć konta", result.Errors);
            }

            return new RegisterResponse(true, "Konto zostało utworzone. Proszę zaczekać na weryfikację przez Administratora.");
        }
    }
}
