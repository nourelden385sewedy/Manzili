using Manzili.Data.Models;
using Manzili.Repositories.GenericRepository;

namespace Manzili.Repositories.UserRepository
{
    public interface IUserRepo : IGenericRepo<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<bool> EmailExists(string email);
    }
}
