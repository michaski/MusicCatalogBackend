using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MusicCatalog.Infrastructure.SeedData
{
    public static class RolesDbSeedData
    {
        public static IdentityRole[] SystemRoles => new IdentityRole[]
        {
            new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "User",
                NormalizedName = "USER"
            }
        };
    }
}
