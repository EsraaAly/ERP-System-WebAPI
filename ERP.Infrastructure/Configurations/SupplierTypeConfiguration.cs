using ERP.Domain.Entities.GeneralDefinitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Configurations
{
    public class SupplierTypeConfiguration : IEntityTypeConfiguration<SupplierType>
    {
        public void Configure(EntityTypeBuilder<SupplierType> builder)
        {
            // Property configurations
            builder.Property(s => s.Type)
                .IsRequired()
                .HasMaxLength(200);

            // Unique constraints
            builder.HasIndex(s => s.Type).IsUnique();

        }
    }
}
