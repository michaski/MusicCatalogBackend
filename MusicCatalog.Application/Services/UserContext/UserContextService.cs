using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace MusicCatalog.Application.Services.UserContext
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserContextService(IHttpContextAccessor httpContextAccessor, RoleManager<IdentityRole> roleManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _roleManager = roleManager;
        }

        public ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;

        public Guid? UserId => User is null
            ? null
            : Guid.Parse(User.FindFirst(claim => claim.Type == ClaimTypes.NameIdentifier).Value);

        public IdentityRole Role => User is null
            ? null
            : _roleManager.FindByNameAsync(User.FindFirst(claim => claim.Type == ClaimTypes.Role).Value).Result;
    }
}
