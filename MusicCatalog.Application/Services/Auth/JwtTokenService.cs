using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MusicCatalog.Domain.Entities;

namespace MusicCatalog.Application.Services.Auth
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public JwtTokenService(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> GetJwtTokenAsync(User user)
        {
            var handler = new JwtSecurityTokenHandler();
            byte[] secret = Encoding.UTF8.GetBytes(_configuration["Authentication:JwtSecretKey"]);
            var userRole = (await _userManager.GetRolesAsync(user)).First();
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Role, userRole)
                }),
                Expires = DateTime.Now.AddHours(double.Parse(_configuration["Authentication:JwtExpireHours"])),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secret),
                    SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Authentication:JwtIssuer"],
                Audience = _configuration["Authentication:JwtIssuer"]
            };
            var token = handler.CreateToken(descriptor);
            return handler.WriteToken(token);
        }
    }
}
