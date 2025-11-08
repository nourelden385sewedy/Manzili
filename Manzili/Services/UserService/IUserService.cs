using Manzili.Models;

namespace Manzili.Services.UserService
{
    public interface IUserService
    {
        public Task<bool> RegisterAsync(User user, string password);
        public Task<User?> LoginAsync(string email, string password);
    }
}
