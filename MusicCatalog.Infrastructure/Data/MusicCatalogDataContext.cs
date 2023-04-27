using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicCatalog.Domain.Entities;

namespace MusicCatalog.Infrastructure.Data
{
    public class MusicCatalogDataContext : IdentityDbContext<User>
    {
        public MusicCatalogDataContext(DbContextOptions<MusicCatalogDataContext> options)
            : base(options) { }
    }
}
