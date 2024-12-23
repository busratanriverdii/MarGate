using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarGate.Identity.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<Domain.Entities.User>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).ValueGeneratedOnAdd();
        builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(u => u.LastName).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Address).IsRequired().HasMaxLength(250);
        builder.Property(u => u.BirthDate).IsRequired();
        builder.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(15);
        builder.Property(u => u.EmailAddress).IsRequired().HasMaxLength(50);
        builder.HasIndex(u => u.EmailAddress).IsUnique();

        builder.Property(u => u.CreatedDate)
               .IsRequired()
               .HasDefaultValueSql("GETDATE()");

        builder.Property(u => u.ModifiedDate)
               .IsRequired()
               .ValueGeneratedOnAddOrUpdate()
               .HasDefaultValueSql("GETDATE()");

        builder.Property(u => u.IsDeleted).IsRequired();

        builder.ToTable("Users");
    }
}

