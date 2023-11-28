using CallApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CallApp.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(i => i.UserProfile).WithOne(i => i.User).HasForeignKey<UserProfile>(i => i.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
