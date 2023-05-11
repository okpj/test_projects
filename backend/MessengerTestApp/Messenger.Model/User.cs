using System.ComponentModel.DataAnnotations;

namespace Messenger.Model;

/// <summary>
/// Пользователь
/// </summary>
public class User
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    [MaxLength(256)]
    public string Name { get; set; }

    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Состояние пользователя
    /// </summary>
    public UserState State { get; set; }

    /// <summary>
    /// Контакты пользователя
    /// </summary>
    public ICollection<UserContact> UserContacts { get; set; }

    /// <summary>
    /// Сообщения пользователя
    /// </summary>
    public ICollection<Message> Messages { get; set; }


    public User()
    {
        UserContacts = new HashSet<UserContact>();
    }
}