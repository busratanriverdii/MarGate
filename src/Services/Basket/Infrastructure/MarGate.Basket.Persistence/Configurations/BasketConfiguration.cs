using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarGate.Basket.Persistence.Configurations;

public class BasketConfiguration : IEntityTypeConfiguration<Domain.Entities.Basket>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Basket> builder)
    {
        builder.ToTable("Baskets");

        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).ValueGeneratedOnAdd();
        builder.Property(b => b.CreatedDate).IsRequired().HasDefaultValueSql("GETDATE()");
        builder.Property(b => b.ModifiedDate)
               .IsRequired()
               .ValueGeneratedOnAddOrUpdate()
               .HasDefaultValueSql("GETDATE()");

        builder.Property(b => b.IsDeleted).IsRequired().HasDefaultValue(false);
    }
}
