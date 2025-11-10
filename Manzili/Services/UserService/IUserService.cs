using Manzili.Models;
using Manzili.ViewModels;

namespace Manzili.Services.UserService
{
    public interface IUserService
    {
        public Task<bool> RegisterAsync(SignUpVM signVm, string password);
        public Task<User?> LoginAsync(LoginVM login);
    }
}
