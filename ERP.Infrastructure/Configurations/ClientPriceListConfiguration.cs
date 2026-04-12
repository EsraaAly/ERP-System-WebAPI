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

            builder.Property(cpl => cpl.ItemName)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
