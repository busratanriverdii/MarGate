using MarGate.Order.Domain.Entities;

namespace MarGate.Order.Persistence.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
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

        builder.HasOne<Product>(oi => oi.Product)
               .WithMany(p => p.OrderItems)
               .HasForeignKey(oi => oi.ProductId);

        builder.HasOne<Order>(oi => oi.Order)
               .WithMany(o => o.OrderItems)
               .HasForeignKey(oi => oi.OrderId);

        builder.ToTable("OrderItems");
    }
}
