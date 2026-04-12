using ERP.Domain.Entities.GeneralDefinitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            // Property configurations
            builder.Property(d => d.DepartmentName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(d => d.DepartmentNameAr)
                .IsRequired()
                .HasMaxLength(200);

            // Unique constraints
            builder.HasIndex(d => d.DepartmentName).IsUnique();
        }
    }
}
