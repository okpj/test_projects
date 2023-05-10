using Messenger.DataContext;
using Messenger.Model;
using Messenger.Repository.Base;
using Messenger.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Repository
{
    public class UserRepository : GenericRepository<User, MessengerDataContext>, IUserRepository
    {

        public UserRepository(MessengerDataContext messengerDataContext) : base(messengerDataContext) { }

        public async Task<User?> GetUserByIdAsNoTracking(int id)
        {
            return await Context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }


    }
}