using ERP.Domain.Entities.GeneralDefinitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Configurations
{
    public class SupplierItemConfiguration : IEntityTypeConfiguration<SupplierItem>
    {
        public void Configure(EntityTypeBuilder<SupplierItem> builder)
        {
            // Property configurations
            builder.Property(si => si.SupplierName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(si => si.ItemName)
                .IsRequired()
                .HasMaxLength(200);

            // Foreign key relationships
            builder.HasOne(si => si.Supplier)
                .WithMany()
                .HasForeignKey(si => si.SupplierID)
                .IsRequired();

            builder.HasOne(si => si.ItemCategory)
                .WithMany()
                .HasForeignKey(si => si.ItemCategoryId)
                .IsRequired();
        }
    }
}
