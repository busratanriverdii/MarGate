using MarGate.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarGate.Order.Persistence.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<Domain.Entities.OrderItem>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.OrderItem> builder)
    {
        builder.HasKey(oi => oi.Id);
        builder.Property(oi => oi.Id).ValueGeneratedOnAdd();

        builder.Property(oi => oi.CreatedDate)
               .IsRequired()
               .HasDefaultValueSql("GETDATE()");

        builder.Property(oi => oi.ModifiedDate)
               .IsRequired()
               .ValueGeneratedOnAddOrUpdate()
               .HasDefaultValueSql("GETDATE()");

        builder.Property(oi => oi.IsDeleted).IsRequired();

        builder.HasOne(oi => oi.Order)
               .WithMany(o => o.OrderItems)
               .HasForeignKey(oi => oi.OrderId);

        builder.ToTable("OrderItems");
    }
}
