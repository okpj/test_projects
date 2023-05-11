namespace Messenger.Repository.Repositories
{
    public class MessageRepository : GenericRepository<Message, MessengerDataContext>, IMessageRepository
    {
        public MessageRepository(MessengerDataContext context) : base(context) { }

        public async Task<List<Message>> GetMessagesListByUserId(int userId)
        {
            return await Context.Messages.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<List<Message>> GetMessagesListByUserIdAndText(int userId, string text)
        {
            return await Context.Messages.Where(x => x.UserId == userId && x.Content.Contains(text)).ToListAsync();
        }
    }
}
