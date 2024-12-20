namespace MarGate.Payment.Persistence.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).ValueGeneratedOnAdd();

        builder.Property(p => p.Amount)
            .IsRequired(); 

        builder.Property(p => p.PaymentDate)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()"); 

        builder.Property(p => p.Status)
            .IsRequired(); 

        builder.Property(p => p.TransactionId)
            .IsRequired()
            .HasMaxLength(100);

        builder.OwnsOne(p => p.PaymentMethod, method =>
        {
            method.Property(m => m.Type)
                .IsRequired()
                .HasMaxLength(50); 

            method.Property(m => m.Token)
                .IsRequired()
                .HasMaxLength(255); 
        });

        builder.ToTable("Payments");
    }
}
