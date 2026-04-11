
using ERP.Domain.Entities.GeneralDefinitions;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // GeneralDefinitions Entities
        public DbSet<City> Cities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientContact> ClientContacts { get; set; }
        public DbSet<ClientPriceList> ClientPriceLists { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<ItemList> ItemLists { get; set; }
        public DbSet<ItemRegistry> ItemRegistries { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierContact> SupplierContacts { get; set; }
        public DbSet<SupplierItem> SupplierItems { get; set; }
        public DbSet<SupplierType> SupplierTypes { get; set; }
        public DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply soft delete filter to all entities that inherit from BaseEntity
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                                .HasKey(nameof(BaseEntity.Id));

                    var parameter = Expression.Parameter(entityType.ClrType, "e");

                    var propertyMethodInfo = typeof(BaseEntity).GetProperty(nameof(BaseEntity.IsDeleted));
                    var propertyAccess = Expression.Property(parameter, propertyMethodInfo);

                    var equalExpression = Expression.Equal(propertyAccess, Expression.Constant(false));

                    var lambda = Expression.Lambda(equalExpression, parameter);

                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
                }
            }

            // Configure entity relationships and constraints

            // Client configurations
            modelBuilder.Entity<Client>()
                .HasMany(c => c.Contacts)
                .WithOne(cc => cc.Client)
                .HasForeignKey(cc => cc.ClientID);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.PriceList)
                .WithOne(cpl => cpl.Client)
                .HasForeignKey(cpl => cpl.ClientID);

            // Supplier configurations
            modelBuilder.Entity<Supplier>()
                .HasMany(s => s.Contacts)
                .WithOne(sc => sc.Supplier)
                .HasForeignKey(sc => sc.SupplierID);

            modelBuilder.Entity<Supplier>()
                .HasMany(s => s.Items)
                .WithOne(si => si.Supplier)
                .HasForeignKey(si => si.SupplierID);

            // Configure string properties with appropriate max lengths
            modelBuilder.Entity<Client>()
                .Property(c => c.FullName)
                .HasMaxLength(200);

            modelBuilder.Entity<Client>()
                .Property(c => c.Email)
                .HasMaxLength(150);

            modelBuilder.Entity<Supplier>()
                .Property(s => s.Name)
                .HasMaxLength(200);

            modelBuilder.Entity<Supplier>()
                .Property(s => s.Email)
                .HasMaxLength(150);

            // Configure decimal properties with appropriate precision
            modelBuilder.Entity<Client>()
                .Property(c => c.CashLimit)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ItemRegistry>()
                .Property(ir => ir.PriceWithoutVat)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ItemRegistry>()
                .Property(ir => ir.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ClientPriceList>()
                .Property(cpl => cpl.PriceWithoutVat)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ClientPriceList>()
                .Property(cpl => cpl.Price)
                .HasPrecision(18, 2);
        }
    }
}
