using ERP.Domain.Entities.GeneralDefinitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Configurations
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            // Property configurations
            builder.Property(r => r.RegionName)
                .IsRequired()
                .HasMaxLength(100);

            // Unique constraints
            builder.HasIndex(r => r.RegionName).IsUnique();
        }
    }
}
