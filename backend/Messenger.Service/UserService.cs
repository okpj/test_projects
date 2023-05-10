using Messenger.Model;
using Messenger.Repository.Interfaces;
using Messenger.Service.Interfaces;

namespace Messenger.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _userRepository.FindByIdAsync(id);
        }
    }
}