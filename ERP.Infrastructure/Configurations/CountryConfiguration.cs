using ERP.Domain.Entities.GeneralDefinitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            // Property configurations
            builder.Property(c => c.CountryCode)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(c => c.CountryName)
                .IsRequired()
                .HasMaxLength(100);

            // Unique constraints
            builder.HasIndex(c => c.CountryCode).IsUnique();
            builder.HasIndex(c => c.CountryName).IsUnique();
        }
    }
}
