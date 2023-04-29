using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicCatalog.Domain.Entities;
using MusicCatalog.Domain.Interfaces;
using MusicCatalog.Infrastructure.Data;

namespace MusicCatalog.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MusicCatalogDataContext _context;

        public UserRepository(MusicCatalogDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUnactivatedAsync()
        {
            return await _context.Users
                .Where(user => !user.IsActivated)
                .ToListAsync();
        }
    }
}
