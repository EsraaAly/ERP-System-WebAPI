using ERP.Domain.Entities.GeneralDefinitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Configurations
{
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            // Property configurations
            builder.Property(u => u.UnitName)
                .IsRequired()
                .HasMaxLength(50);

            // Unique constraints
            builder.HasIndex(u => u.UnitName).IsUnique();
        }
    }
}
