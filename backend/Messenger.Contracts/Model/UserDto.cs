namespace Messenger.Contracts.Model;

public class UserDto
{
    public int? Id { get; set; }

    public string Name { get; set; }

    public string Password { get; set; }

    public StateDto State { get; set; }
}
