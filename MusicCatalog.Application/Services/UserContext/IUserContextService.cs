using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MusicCatalog.Application.Services.UserContext
{
    public interface IUserContextService
    {
        ClaimsPrincipal User { get; }
        Guid? UserId { get; }
        IdentityRole Role { get; }
    }
}
