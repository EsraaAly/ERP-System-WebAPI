using ERP.Domain.Entities.GeneralDefinitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Configurations
{
    public class ClientPriceListConfiguration : IEntityTypeConfiguration<ClientPriceList>
    {
        public void Configure(EntityTypeBuilder<ClientPriceList> builder)
        {
            // Property configurations
            builder.Property(cpl => cpl.PriceWithoutVat)
                .HasPrecision(18, 2);

            builder.Property(cpl => cpl.Price)
                .HasPrecision(18, 2);

            // Foreign key relationships
            builder.HasOne(cpl => cpl.Client)
                .WithMany()
                .HasForeignKey(cpl => cpl.ClientId)
                .IsRequired();

            builder.HasOne(cpl => cpl.ItemList)
                .WithMany()
                .HasForeignKey(cpl => cpl.ItemId)
                .IsRequired();

            builder.HasOne(cpl => cpl.ItemCategory)
                .WithMany()
                .HasForeignKey(cpl => cpl.ItemCategoryId)
                .IsRequired();
        }
    }
}
