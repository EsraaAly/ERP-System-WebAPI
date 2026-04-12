using ERP.Domain.Entities.GeneralDefinitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            // Property configurations
            builder.Property(c => c.CityName)
                .IsRequired()
                .HasMaxLength(100);

            // Unique constraints
            builder.HasIndex(c => c.CityName).IsUnique();
        }
    }
}
