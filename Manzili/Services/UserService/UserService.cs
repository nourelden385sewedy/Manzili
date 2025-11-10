using Manzili.Models;
using Manzili.Repositories.AddressRepository;
using Manzili.Repositories.UserRepository;
using Manzili.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Manzili.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IAddressRepo _addressRepo;
        private readonly PasswordHasher<String> _hasher = new PasswordHasher<string>();

        public UserService(IUserRepo userRepo, IAddressRepo addressRepo)
        {
            _userRepo = userRepo;
            _addressRepo = addressRepo;
        }


        public async Task<bool> RegisterAsync(SignUpVM signVm, string password)
        {
            if (await _userRepo.EmailExists(signVm.Email))
                return false;

            var hash = _hasher.HashPassword(signVm.Email, signVm.Password);

            User user = new User
            {
                FullName = signVm.FName + " " + signVm.LName,
                Email = signVm.Email,
                PasswordHash = hash,
                Role = signVm.isSeller ? UserRole.Provider : UserRole.Buyer
            };

            await _userRepo.AddAsync(user);

            return true;
        }

        public async Task<User?> LoginAsync(LoginVM login)
        {
            var user = await _userRepo.GetByEmailAsync(login.Email);
            if (user == null) return null;

            var result =  _hasher.VerifyHashedPassword(login.Email, user.PasswordHash, login.Password);
            return result == PasswordVerificationResult.Success ? user : null;
        }

    }
}
