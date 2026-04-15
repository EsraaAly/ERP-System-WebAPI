using ERP.Domain.Entities.GeneralDefinitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Configurations
{
    public class SupplierItemConfiguration : IEntityTypeConfiguration<SupplierItem>
    {
        public void Configure(EntityTypeBuilder<SupplierItem> builder)
        {


            // Foreign key relationships
            builder.HasOne(si => si.Supplier)
                .WithMany(s => s.Items)
                .HasForeignKey(si => si.SupplierId)
                .IsRequired();

            builder.HasOne(si => si.ItemCategory)
                .WithMany()
                .HasForeignKey(si => si.ItemCategoryId)
                .IsRequired();

            builder.HasOne(si => si.ItemList)
                .WithMany()
                .HasForeignKey(si => si.ItemId)
                .IsRequired();
        }
    }
}
