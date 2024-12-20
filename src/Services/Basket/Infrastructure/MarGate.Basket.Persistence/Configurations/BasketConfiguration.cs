using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarGate.Basket.Persistence.Configurations;

public class BasketConfiguration : IEntityTypeConfiguration<Basket>
{
    public void Configure(EntityTypeBuilder<Basket> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.Property(b => b.CreatedDate).IsRequired().HasDefaultValueSql("GETDATE()");
        builder.Property(b => b.ModifiedDate)
               .IsRequired()
               .ValueGeneratedOnAddOrUpdate()
               .HasDefaultValueSql("GETDATE()"); 

        builder.Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);

        builder.HasOne(b => b.User)
               .WithOne(u => u.Basket)
               .HasForeignKey<Basket>(b => b.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Baskets");
    }
}
