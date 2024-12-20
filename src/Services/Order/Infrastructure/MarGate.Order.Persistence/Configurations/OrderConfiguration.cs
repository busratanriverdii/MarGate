namespace MarGate.Order.Persistence.Configurations;

public void Configure(EntityTypeBuilder<Order> builder)
{
    builder.HasKey(o => o.Id);
    builder.Property(o => o.Id).ValueGeneratedOnAdd();
    builder.Property(o => o.Address).IsRequired().HasMaxLength(250);
    builder.Property(o => o.Description).IsRequired().HasMaxLength(150);

    builder.Property(o => o.CreatedDate)
           .IsRequired()
           .HasDefaultValueSql("GETDATE()");

    builder.Property(o => o.ModifiedDate)
           .IsRequired()
           .ValueGeneratedOnAddOrUpdate()
           .HasDefaultValueSql("GETDATE()");

    builder.Property(o => o.IsDeleted).IsRequired();

    builder.HasOne<User>(o => o.User)
           .WithMany(u => u.Orders)
           .HasForeignKey(o => o.UserId);

    builder.ToTable("Orders");
}
