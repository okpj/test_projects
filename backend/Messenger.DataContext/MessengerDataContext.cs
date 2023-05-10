namespace Messenger.DataContext;

public class MessengerDataContext : DbContext
{
    public MessengerDataContext(DbContextOptions<MessengerDataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MessengerDataContext).Assembly);
    }

    #region Tables
    /// <summary>
    /// Пользователи
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// Контакты
    /// </summary>
    public DbSet<UserContact> UserContacts { get; set; }

    /// <summary>
    /// Сообщения
    /// </summary>
    public DbSet<Message> Messages { get; set; }
    #endregion

}