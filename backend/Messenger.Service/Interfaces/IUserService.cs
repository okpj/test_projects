using Messenger.Model;

namespace Messenger.Service.Interfaces;

public interface IUserService
{
    public Task<User?> GetUserById(int id);
}
