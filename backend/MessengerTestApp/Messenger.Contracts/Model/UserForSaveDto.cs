namespace Messenger.Contracts.Model
{
    /// <summary>
    /// Пользователь для запроса сохранения
    /// </summary>
    public class UserForSaveDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public byte StateId { get; set; }
    }
}
