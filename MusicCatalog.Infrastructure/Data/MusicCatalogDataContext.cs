using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicCatalog.Domain.Entities;
using MusicCatalog.Infrastructure.SeedData;

namespace MusicCatalog.Infrastructure.Data
{
    public class MusicCatalogDataContext : IdentityDbContext<User>
    {
        public MusicCatalogDataContext(DbContextOptions<MusicCatalogDataContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var rolesSeed = RolesDbSeedData.SystemRoles;
            var superAdminSeed = AdminDbSeedData.SuperAdmin;
            modelBuilder.Entity<IdentityRole>()
                .HasData(rolesSeed);
            modelBuilder.Entity<User>()
                .HasData(superAdminSeed);
            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>
                {
                    RoleId = rolesSeed[0].Id,
                    UserId = superAdminSeed.Id
                });
        }
    }
}
