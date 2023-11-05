using ByteStreamProcessorLib.Data.Models;
using ByteStreamProcessorLib.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteStreamProcessorLib.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByIdAsync(Guid userId)
        {
            return await _context.Users
                .Include(u => u.Tags)
                .FirstOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<User?> GetUserByIdAndDomainAsync(Guid userId, string domain)
        {
            return await _context.Users
                .Include(u => u.Tags)
                .ThenInclude(t => t.Tags)
                .FirstOrDefaultAsync(u => u.UserId == userId && u.Domain == domain);
        }

        public async Task<IEnumerable<User?>> GetUsersByDomainAsync(string domain, int page, int pageSize)
        {
            return await _context.Users
                .Where(u => u.Domain == domain)
                .Include(u => u.Tags)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<User?>> GetUsersByTagAndDomainAsync(string tagValue, string domain)
        {
            return await _context.Tags
                .Where(t => t.Value == tagValue && t.Domain == domain)
                .SelectMany(t => t.Users)
                .Include(u => u.Tags)
                .ToListAsync();
        }
    }
}
