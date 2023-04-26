using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MusicCatalog.Infrastructure.Data
{
    public class MusicCatalogDataContext : DbContext
    {
        public MusicCatalogDataContext(DbContextOptions<MusicCatalogDataContext> options)
            : base(options) { }
    }
}
