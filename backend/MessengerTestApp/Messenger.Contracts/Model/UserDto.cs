namespace Messenger.Contracts.Model;

/// <summary>
/// Пользователь
/// </summary>
public class UserDto
{
    public int? Id { get; set; }

    public string Name { get; set; }

    public string Password { get; set; }

    public StateDto State { get; set; }
}
