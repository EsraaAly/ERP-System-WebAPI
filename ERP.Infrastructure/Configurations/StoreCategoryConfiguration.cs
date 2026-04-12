using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Domain.Entities.GeneralDefinitions;

namespace ERP.Infrastructure.Configurations
{
    public class StoreCategoryConfiguration : IEntityTypeConfiguration<StoreCategory>
    {
        public void Configure(EntityTypeBuilder<StoreCategory> builder)
        {
            // Property configurations
            builder.Property(sc => sc.CategoryName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(sc => sc.CategoryNameAr)
                .IsRequired()
                .HasMaxLength(200);

            // Unique constraints
            builder.HasIndex(sc => sc.CategoryName).IsUnique();
        }
    }
}
