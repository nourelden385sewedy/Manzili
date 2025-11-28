using Manzili.Data.Models;
using Manzili.Repositories.AdressRepository;
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

        public async Task<bool> RegisterAsync(SignUpVM signVm)
        {
            if (await _userRepo.EmailExists(signVm.Email))
                return false;

            string hash = _hasher.HashPassword(null, signVm.Password);

            User user = new User
            {
                FullName = signVm.FName + " " + signVm.LName,
                Email = signVm.Email,
                PasswordHash = hash,
                Role = signVm.isSeller ? UserRole.Provider : UserRole.Buyer,
                UpdatedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow,
            };

            await _userRepo.AddAsync(user);
            await _userRepo.SaveChangesAsync();
            return true;
        }

        public async Task<User?> LoginAsync(SignInVM signVm)
        {
            var user = await _userRepo.GetByEmailAsync(signVm.Email);
            if (user == null) return null;

            var result = _hasher.VerifyHashedPassword(null, user.PasswordHash, signVm.Password);
            return result == PasswordVerificationResult.Success ? user : null;
        }
    }
}
