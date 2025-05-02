using Microsoft.EntityFrameworkCore;
using ProductCatalogApp.Application.Interfaces;
using ProductCatalogApp.Application.Services;
using ProductCatalogApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogApp.Infrastructure.Data
{    
    public class UserRepository :IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }

}
