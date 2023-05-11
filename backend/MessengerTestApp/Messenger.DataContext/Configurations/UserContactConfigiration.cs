namespace Messenger.DataContext.Configurations;

public class UserContactConfigiration : IEntityTypeConfiguration<UserContact>
{
    public void Configure(EntityTypeBuilder<UserContact> builder)
    {
        builder.HasKey(x => new { x.UserId, x.ContactId });

        builder
            .HasOne(x => x.User)
            .WithMany(x => x.UserContacts)
            .HasForeignKey(x => x.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.ClientCascade);

        builder.HasData(UserSeedData.Contacts);
    }
}
