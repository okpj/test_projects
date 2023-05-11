using Messenger.DataContext;
using Messenger.Model;
using Messenger.Repository.Base;

namespace Messenger.Repository.Interfaces;

public interface IUserRepository : IGenericRepository<User, MessengerDataContext>
{
    /// <summary>
    /// Получить пользователя по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<User?> GetUserByIdAsync(int id);

    /// <summary>
    /// Получить пользователя по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<User?> GetUserByIdAsTrackingAsync(int id);

    /// <summary>
    /// Получить пользователя по имени
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<User?> GetUserByNameAsync(string name);

    /// <summary>
    /// Поиск пользователей по имени
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<List<User>> GetUsersByNameAsync(string name);
}
