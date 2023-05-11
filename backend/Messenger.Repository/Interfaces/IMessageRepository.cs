namespace Messenger.Repository.Interfaces;

public interface IMessageRepository : IGenericRepository<Message, MessengerDataContext>
{
    /// <summary>
    /// Получить список сообщения пользователя
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<List<Message>> GetMessagesListByUserId(int userId);

    /// <summary>
    /// Получить список сообщения пользователя по строке
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="text"></param>
    /// <returns></returns>
    Task<List<Message>> GetMessagesListByUserIdAndText(int userId, string text);
}
