using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Messenger.Model;

public class Message
{
    [Key]
    public int Id { get; set; }

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
    /// Дата и время отправки сообщения
    /// </summary>
    public DateTime SendTime { get; set; }

    /// <summary>
    /// Дата и время получения сообщения
    /// </summary>
    public DateTime DeliveryTime { get; set; }

    /// <summary>
    /// Текст сообщения
    /// </summary>
    public string Content { get; set; }
}
