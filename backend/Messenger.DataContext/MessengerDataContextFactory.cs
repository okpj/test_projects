namespace Messenger.DataContext;

public class MessengerDataContextFactory : IDesignTimeDbContextFactory<MessengerDataContext>
{
    public MessengerDataContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("dbsettings.json", true, true)
             .Build();

        var connectionString = config.GetConnectionString("MessengerDB");

        var optionsBuilder = new DbContextOptionsBuilder<MessengerDataContext>();

        optionsBuilder.UseSqlServer(connectionString);

        return new MessengerDataContext(optionsBuilder.Options);
    }
}
