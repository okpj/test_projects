namespace Messenger.DataContext.SeedData;

/// <summary>
/// Предзаполненные данные пользователей
/// </summary>
public static class UserSeedData
{
    public static List<User> Users => new List<User> { FirstStaticUser, SecondStaticUser };
    public static List<UserContact> Contacts => new List<UserContact> { FirstStaticUserContact, SecondStaticUserContact };

    public const int FirstStaticUserId = 1;
    public const int SecondStaticUserId = 2;

    public static readonly User FirstStaticUser = new()
    {
        Id = FirstStaticUserId,
        Name = "FirstStaticUser",
        State = UserState.offline,
        Password = "ef797c8118f02dfb649607dd5d3f8c7623048c9c063d532cc95c5ed7a898a64f",
    };

    public static readonly User SecondStaticUser = new()
    {
        Id = SecondStaticUserId,
        Name = "SecondStaticUser",
        State = UserState.offline,
        Password = "15e2b0d3c33891ebb0f1ef609ec419420c20e320ce94c65fbc8c3312448eb225",
    };

    public static readonly UserContact FirstStaticUserContact = new()
    {
        UserId = FirstStaticUserId,
        ContactId = SecondStaticUserId
    };

    public static readonly UserContact SecondStaticUserContact = new()
    {
        UserId = SecondStaticUserId,
        ContactId = FirstStaticUserId
    };


}
