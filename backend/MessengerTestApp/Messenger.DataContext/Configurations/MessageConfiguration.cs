namespace Messenger.DataContext.Configurations;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder
          .HasOne(x => x.User)
          .WithMany(x => x.Messages)
          .HasForeignKey(x => x.UserId)
          .IsRequired()
          .OnDelete(DeleteBehavior.ClientCascade);
    }
}
