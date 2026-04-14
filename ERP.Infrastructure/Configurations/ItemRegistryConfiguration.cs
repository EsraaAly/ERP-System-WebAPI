using ERP.Domain.Entities.GeneralDefinitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Configurations
{
    public class ItemRegistryConfiguration : IEntityTypeConfiguration<ItemRegistry>
    {
        public void Configure(EntityTypeBuilder<ItemRegistry> builder)
        {
            // Property configurations
            builder.Property(ir => ir.ItemId)
                .IsRequired();

            builder.Property(ir => ir.PriceWithoutVat)
                .HasPrecision(18, 2);

            builder.Property(ir => ir.Price)
                .HasPrecision(18, 2);

            builder.Property(ir => ir.DiscountAmount)
                .HasPrecision(18, 2);

            builder.Property(ir => ir.PriceAfterDiscount)
                .HasPrecision(18, 2);

            builder.HasOne(ir => ir.Item)
                .WithMany()
                .HasForeignKey(ir => ir.ItemId)
                .IsRequired();

            builder.HasOne(ir => ir.ClientType)
                .WithMany()
                .HasForeignKey(ir => ir.ClientTypeId)
                .IsRequired();

            builder.HasOne(ir => ir.Region)
                .WithMany()
                .HasForeignKey(ir => ir.RegionId)
                .IsRequired();

            builder.HasOne(ir => ir.Store)
                .WithMany()
                .HasForeignKey(ir => ir.StoreId)
                .IsRequired();
        }
    }
}
