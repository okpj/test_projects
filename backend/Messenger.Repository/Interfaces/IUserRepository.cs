using Messenger.DataContext;
using Messenger.Model;
using Messenger.Repository.Base;

namespace Messenger.Repository.Interfaces;

public interface IUserRepository : IGenericRepository<User, MessengerDataContext>
{
    Task<User> GetUserByIdAsNoTracking(int id);
}
