using ERP.Domain.Entities.GeneralDefinitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Configurations
{
    public class ItemListConfiguration : IEntityTypeConfiguration<ItemList>
    {
        public void Configure(EntityTypeBuilder<ItemList> builder)
        {
            // Property configurations
            builder.Property(il => il.ItemName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(il => il.Unit)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(il => il.MinimumLevel)
                .HasDefaultValue(0);

            builder.Property(il => il.ItemOrder)
                .HasDefaultValue(0);

            // Foreign key relationships
            builder.HasOne(il => il.ItemCategory)
                .WithMany()
                .HasForeignKey(il => il.ItemCategoryId)
                .IsRequired();

            builder.HasOne(il => il.Unit)
                .WithMany()
                .HasForeignKey(il => il.UnitId)
                .IsRequired();
        }
    }
}
