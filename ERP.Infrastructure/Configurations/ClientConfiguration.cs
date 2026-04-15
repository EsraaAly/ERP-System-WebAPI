using ERP.Domain.Entities.GeneralDefinitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ERP.Infrastructure.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            // Property configurations
            builder.Property(c => c.FullName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.FullNameAr)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Supervisor)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Tele)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.ReferenceNo)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Email)
                .HasMaxLength(150);

            builder.Property(c => c.CashLimit)
                .HasPrecision(18, 2);

            builder.Property(c => c.AccNo)
                .HasMaxLength(50);

            // Unique constraints
            builder.HasIndex(c => c.FullName).IsUnique();
            builder.HasIndex(c => c.ReferenceNo).IsUnique();
            builder.HasIndex(c => c.AccNo).IsUnique();

            // Relationships
            builder.HasMany(c => c.Contacts)
                .WithOne(cc => cc.Client)
                .HasForeignKey(cc => cc.ClientId);

            builder.HasMany(c => c.PriceList)
                .WithOne(cpl => cpl.Client)
                .HasForeignKey(cpl => cpl.ClientId);

            // Foreign Key Relationships
            builder.HasOne(c => c.Region)
                .WithMany()
                .HasForeignKey(c => c.RegionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Country)
                .WithMany()
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.City)
                .WithMany()
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.ClientType)
                .WithMany()
                .HasForeignKey(c => c.ClientTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
