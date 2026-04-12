using ERP.Domain.Entities.GeneralDefinitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            // Property configurations
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(s => s.CR)
                .HasMaxLength(50);

            builder.Property(s => s.VATNo)
                .HasMaxLength(50);

            builder.Property(s => s.AccNo)
                .HasMaxLength(50);

            builder.Property(s => s.Email)
                .HasMaxLength(150);

            // Unique constraints
            builder.HasIndex(s => s.Name).IsUnique();
            builder.HasIndex(s => s.CR).IsUnique();
            builder.HasIndex(s => s.VATNo).IsUnique();
            builder.HasIndex(s => s.AccNo).IsUnique();

            // Relationships
            builder.HasMany(s => s.Contacts)
                .WithOne(sc => sc.Supplier)
                .HasForeignKey(sc => sc.SupplierID);

            builder.HasMany(s => s.Items)
                .WithOne(si => si.Supplier)
                .HasForeignKey(si => si.SupplierID);
        }
    }
}
