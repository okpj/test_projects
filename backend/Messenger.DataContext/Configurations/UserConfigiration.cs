namespace Messenger.DataContext.Configurations;

public class UserConfigiration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasMany(x => x.UserContacts)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .IsRequired();

        builder
           .HasMany(x => x.Messages)
           .WithOne(x => x.User)
           .HasForeignKey(x => x.UserId)
           .IsRequired();

        builder.HasData(UserSeedData.Users);
    }
}
