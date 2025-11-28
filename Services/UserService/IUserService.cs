using Manzili.Data.Models;
using Manzili.ViewModels;

namespace Manzili.Services.UserService
{
    public interface IUserService
    {
        public Task<bool> RegisterAsync(SignUpVM signVm);
        public Task<User?> LoginAsync(SignInVM signVm);
    }
}
