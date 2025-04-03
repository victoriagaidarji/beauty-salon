using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Beauty.Data.Maps;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Username).IsRequired();
        builder.Property(u => u.Email).IsRequired();
        builder.Property(u => u.Phone).IsRequired();
        builder.Property(u => u.PasswordHash).IsRequired();
        builder.HasMany(u => u.Appointments).WithOne(a => a.User).HasForeignKey(a => a.UserId);
    }
}