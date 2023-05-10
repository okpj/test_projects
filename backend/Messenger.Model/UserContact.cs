using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger.Model;

/// <summary>
/// Контакты
/// </summary>
public class UserContact
{
    #region User
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    [ForeignKey(nameof(User))]
    public int UserId { get; set; }

    /// <summary>
    /// Пользователь
    /// </summary>
    public User User { get; set; }
    #endregion

    #region Contact

    /// <summary>
    ///  Идентификатор контакта
    /// </summary>
    [ForeignKey(nameof(Contact))]
    public int ContactId { get; set; }

    /// <summary>
    /// Контакт
    /// </summary>
    public User Contact { get; set; }

    #endregion

    /// <summary>
    /// Дата и время последней беседы с контактом
    /// </summary>
    public DateTime? LastUpdateTime { get; set; }

    /// <summary>
    /// Сообщения
    /// </summary>
    public ICollection<Message> Messages { get; set; }

    public UserContact()
    {
        Messages = new HashSet<Message>();
    }
}
