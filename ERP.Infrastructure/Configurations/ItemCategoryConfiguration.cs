using ERP.Domain.Entities.GeneralDefinitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Configurations
{
    public class ItemCategoryConfiguration : IEntityTypeConfiguration<ItemCategory>
    {
        public void Configure(EntityTypeBuilder<ItemCategory> builder)
        {
            // Property configurations
            builder.Property(ic => ic.ItemCategoryName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(ic => ic.AccName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(ic => ic.AccNo)
                .HasMaxLength(50);

            // Unique constraints
            builder.HasIndex(ic => ic.ItemCategoryName).IsUnique();
            builder.HasIndex(ic => ic.AccName).IsUnique();
        }
    }
}
