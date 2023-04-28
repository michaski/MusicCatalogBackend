using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MusicCatalog.Domain.Entities;

namespace MusicCatalog.Infrastructure.SeedData
{
    public static class AdminDbSeedData
    {
        public static User SuperAdmin {
            get
            {
                var admin = new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    EmailConfirmed = true,
                    IsActivated = true
                };
                var passwordHasher = new PasswordHasher<User>();
                admin.PasswordHash = passwordHasher.HashPassword(admin, "admin");
                return admin;
            }
        }
    }
}
