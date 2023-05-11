class Program
{
    static JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions()
    {
        WriteIndented = true,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
        ReferenceHandler = ReferenceHandler.IgnoreCycles
        
    };

    static MessengerDataContextFactory _messengerDataContextFactory;

    static async Task Main(string[] args)
    {

        _messengerDataContextFactory = new MessengerDataContextFactory();
        MigrateDatabase();


        await TestUserRepository();

        await TestContactRepository();

        await TestMessageRepository();

        Console.ReadLine();
    }


    public static void MigrateDatabase()
    {
        var context = _messengerDataContextFactory.CreateDbContext();
        WriteLineLable("Проверка миграций", ConsoleColor.DarkCyan);

        var migrationList = context.Database.GetPendingMigrations().ToList();
        WriteLineLable("Миграций ожидающих применения: " + migrationList.Count, ConsoleColor.DarkCyan);
        migrationList.ForEach(Console.WriteLine);

        if (migrationList.Count > 0)
        {
            context.Database.Migrate();
            context.SaveChanges();
            WriteLineLable("Миграции применены", ConsoleColor.DarkCyan);
        }
        Console.ResetColor();

    }


    static async Task TestUserRepository()
    {
        WriteLineLable("ТЕСТ UserRepository", ConsoleColor.Blue);

        var userRepository = new UserRepository(_messengerDataContextFactory.CreateDbContext());

        WriteLineLable("Получить пользователя по id");
        var user = await userRepository.GetUserByIdAsync(1);
        Console.WriteLine(JsonSerializer.Serialize(user, JsonSerializerOptions));


        WriteLineLable("Получить пользователя по имени");

        user = await userRepository.GetUserByNameAsync("FirstStaticUser");
        Console.WriteLine(JsonSerializer.Serialize(user, JsonSerializerOptions));


        WriteLineLable("Получить пользователей по имени");

        var users = await userRepository.GetUsersListByNameAsync("user");
        Console.WriteLine(JsonSerializer.Serialize(users, JsonSerializerOptions));


        WriteLineLable("Добавить пользователя");
        user = new User
        {
            Name = "Олег",
            Password = "password",
            State = UserState.online,
        };

        var newUser = await userRepository.CreateAsync(user);
        Console.WriteLine($"UserId: {newUser.Id}");
        Console.WriteLine(JsonSerializer.Serialize(newUser, JsonSerializerOptions));

        WriteLineLable("Обновить пользователя");
        newUser.State = UserState.offline;
        newUser.Name = "Пётр";
        var result = await userRepository.UpdateAsync(newUser);
        Console.WriteLine($"Результат: {result}");
        newUser = await userRepository.GetUserByIdAsync(newUser.Id);
        Console.WriteLine(JsonSerializer.Serialize(newUser, JsonSerializerOptions));
    }

    static async Task TestContactRepository()
    {
        WriteLineLable("ТЕСТ ContactRepository", ConsoleColor.Blue);

        var contactRepository = new ContactRepository(_messengerDataContextFactory.CreateDbContext());

        WriteLineLable("Получение контакта пользователя");
        var contact = await contactRepository.GetContactWithUserInfoByUserId(1, 2);
        Console.WriteLine(JsonSerializer.Serialize(contact, JsonSerializerOptions));

        WriteLineLable("Получение списка контактов пользователя");
        var contacts = await contactRepository.GetContactsListByUserId(1);
        Console.WriteLine(JsonSerializer.Serialize(contacts, JsonSerializerOptions));

        WriteLineLable("Получение контакта по имени из списка пользователя");
        contact = await contactRepository.GetUserContactByContactName(1, "SecondStaticUser");
        Console.WriteLine(JsonSerializer.Serialize(contact, JsonSerializerOptions));


        WriteLineLable("Добавление нового контакта");

        var newContact = new User
        {
            Name = "Дмитрий",
            Password = "password",
            State = UserState.offline,
        };


        var result = await contactRepository.CreateNewContact(1, newContact);
        Console.WriteLine($"Результат: {result}");

        WriteLineLable("Обновление данных контакта");

        contact!.LastUpdateTime = DateTime.Now;
        await contactRepository.TryUpdateAsync(contact);
        contact = await contactRepository.GetContactWithUserInfoByUserId(1, contact.ContactId);
        Console.WriteLine(JsonSerializer.Serialize(contact, JsonSerializerOptions));

        WriteLineLable("Удаление контакта");
        var contactForDelete = await contactRepository.GetContactByUserId(1, newContact.Id);
        result = await contactRepository.DeleteContactAsync(contactForDelete!);
        Console.WriteLine($"Результат: {result}");
    }


    static async Task TestMessageRepository()
    {
        WriteLineLable("ТЕСТ MessageRepository", ConsoleColor.Blue);

        var messageRepository = new MessageRepository(_messengerDataContextFactory.CreateDbContext());

        WriteLineLable("Добавление сообщения");
        var newMessage = new Message
        {
            UserId = 1,
            ContactId = 2,
            SendTime = DateTime.Now,
            Content = "Привет! Вот твои новые документы"
        };

        var resultSaveMessage = await messageRepository.CreateAsync(newMessage);
        Console.WriteLine($"MessageId: {resultSaveMessage.Id}");

        WriteLineLable("Получение сообщений");
        var messages  = await messageRepository.GetMessagesListByUserId(1);
        Console.WriteLine(JsonSerializer.Serialize(messages, JsonSerializerOptions));

        WriteLineLable("Получение сообщений по строке");
        messages = await messageRepository.GetMessagesListByUserIdAndText(1, "новые");
        Console.WriteLine(JsonSerializer.Serialize(messages, JsonSerializerOptions));
    }

    static void WriteLineLable(string text, ConsoleColor consoleColor = ConsoleColor.Yellow)
    {
        Console.ForegroundColor = consoleColor;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}
