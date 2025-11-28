using Manzili.Data;
using Manzili.Data.Models;
using Manzili.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Manzili.Repositories.UserRepository
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        public UserRepo(ManziliDbContext context) : base(context)
        {
        }
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<bool> EmailExists(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }
    }
}
