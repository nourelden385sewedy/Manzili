using Manzili.Models;
using Manzili.Repositories.AddressRepository;
using Manzili.Repositories.UserRepository;
using Microsoft.AspNetCore.Identity;

namespace Manzili.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IAddressRepo _addressRepo;
        private readonly PasswordHasher<User> _hasher = new();

        public UserService(IUserRepo userRepo, IAddressRepo addressRepo)
        {
            _userRepo = userRepo;
            _addressRepo = addressRepo;
        }


        public async Task<bool> RegisterAsync(User user, string password)
        {
            if (await _userRepo.EmailExists(user.Email))
                return false;

            user.PasswordHash = _hasher.HashPassword(user, password);
            await _userRepo.AddAsync(user);

            return true;
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            var user = await _userRepo.GetByEmailAsync(email);
            if (user == null) return null;

            var result =  _hasher.VerifyHashedPassword(user, user.PasswordHash, password);
            return result == PasswordVerificationResult.Success ? user : null;
        }

    }
}
