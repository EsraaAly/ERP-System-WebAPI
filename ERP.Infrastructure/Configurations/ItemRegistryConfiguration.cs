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
            builder.Property(ir => ir.ItemName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(ir => ir.PriceWithoutVat)
                .HasPrecision(18, 2);

            builder.Property(ir => ir.Price)
                .HasPrecision(18, 2);

            builder.Property(ir => ir.DiscountAmount)
                .HasPrecision(18, 2);

            builder.Property(ir => ir.PriceAfterDiscount)
                .HasPrecision(18, 2);
        }
    }
}
