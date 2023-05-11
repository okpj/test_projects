namespace Messenger.Repository.Interfaces;

public interface IContactRepository : IGenericRepository<UserContact, MessengerDataContext>
{
    /// <summary>
    /// Получить контакт и информацию о пользователе контакта
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="contactId"></param>
    /// <returns></returns>
    Task<UserContact?> GetContactWithUserInfoByUserId(int userId, int contactId);

    /// <summary>
    /// Получить контакт
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="contactId"></param>
    /// <returns></returns>
    Task<UserContact?> GetContactByUserId(int userId, int contactId);

    /// <summary>
    /// Получить список контактов пользователя
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<List<UserContact>> GetContactsListByUserId(int userId);

    /// <summary>
    /// Получить список контакта пользователя по имени контакта
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="contactName"></param>
    /// <returns></returns>
    Task<UserContact?> GetUserContactByContactName(int userId, string contactName);

    /// <summary>
    /// Создать контакт
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="contact"></param>
    /// <returns></returns>
    Task<bool> CreateNewContact(int userId, User contact);

    /// <summary>
    /// Удалить контакт
    /// </summary>
    /// <param name="userContact"></param>
    /// <returns></returns>
    Task<bool> DeleteContactAsync(UserContact userContact);
}
