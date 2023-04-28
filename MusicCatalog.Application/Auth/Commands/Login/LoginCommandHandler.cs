using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MusicCatalog.Application.Auth.Responses;
using MusicCatalog.Application.Services.Auth;
using MusicCatalog.Domain.Entities;

namespace MusicCatalog.Application.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtTokenService _jwtTokenService;

        public LoginCommandHandler(UserManager<User> userManager, IJwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new LoginResponse
                {
                    Succeeded = false,
                    Message = "Zły email lub hasło"
                };
            }

            if (!user.IsActivated)
            {
                return new LoginResponse
                {
                    Succeeded = false,
                    Message = "Konto nie zostało aktywowane."
                };
            }

            var passwordIsCorrect = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!passwordIsCorrect)
            {
                return new LoginResponse
                {
                    Succeeded = false,
                    Message = "Zły email lub hasło"
                };
            }

            var token = await _jwtTokenService.GetJwtTokenAsync(user);

            return new LoginResponse
            {
                Succeeded = true,
                Token = token
            };
        }
    }
}
