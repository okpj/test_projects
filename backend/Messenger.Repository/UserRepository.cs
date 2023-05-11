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

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await Context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User?> GetUserByIdAsTrackingAsync(int id)
        {
            return await Context.Users.AsTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User?> GetUserByNameAsync(string name)
        {
            return await Context.Users.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<List<User>> GetUsersByNameAsync(string name)
        {
            return await Context.Users.Where(x => x.Name.Contains(name)).ToListAsync();
        }

    }
}