namespace Messenger.Repository.Repositories
{
    public class ContactRepository : GenericRepository<UserContact, MessengerDataContext>, IContactRepository
    {

        public ContactRepository(MessengerDataContext messengerDataContext) : base(messengerDataContext) { }

        public async Task<UserContact?> GetContactWithUserInfoByUserId(int userId, int contactId)
        {
            return await Context.UserContacts
                .Include(x => x.Contact)
                .FirstOrDefaultAsync(x => x.UserId == userId && x.ContactId == contactId);
        }

        public async Task<UserContact?> GetContactByUserId(int userId, int contactId)
        {
            return await Context.UserContacts
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UserId == userId && x.ContactId == contactId);
        }

        public async Task<List<UserContact>> GetContactsListByUserId(int userId)
        {
            return await Context.UserContacts
                 .Include(x => x.Contact)
                 .Where(x => x.UserId == userId)
                 .ToListAsync();
        }

        public async Task<UserContact?> GetUserContactByContactName(int userId, string contactName)
        {
            return await Context.UserContacts
               .Include(x => x.Contact)
               .FirstOrDefaultAsync(x => x.UserId == userId && x.Contact.Name == contactName);
        }


        public async Task<bool> CreateNewContact(int userId, User contact)
        {
            var user = Context.Users.AsTracking()
                .FirstOrDefault(x => x.Id == userId);
            user!.UserContacts.Add(new UserContact { UserId = user.Id, Contact = contact });
            return await Context.SaveChangesAsync() > 0;

        }

        public async Task<bool> DeleteContactAsync(UserContact userContact)
        {
            var local = Context.Set<UserContact>()
               .Local
               .FirstOrDefault(entry => entry.UserId == userContact.UserId
               && entry.ContactId == userContact.ContactId);
            if (local is not null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }

            return await TryDeleteAsync(userContact);
        }
    }
}
