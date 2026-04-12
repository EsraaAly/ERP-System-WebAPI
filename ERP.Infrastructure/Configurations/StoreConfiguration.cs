using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Domain.Entities.GeneralDefinitions;

namespace ERP.Infrastructure.Configurations
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            // Property configurations
            builder.Property(s => s.StoreName)
                .IsRequired()
                .HasMaxLength(200);

            // Unique constraints
            builder.HasIndex(s => s.StoreName).IsUnique();
            builder.HasIndex(s => s.StoreId).IsUnique();

            // Foreign key relationships
            builder.HasOne<StoreCategory>()
                .WithMany()
                .HasForeignKey(s => s.StoreCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
