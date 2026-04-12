
using ERP.Domain.Entities.GeneralDefinitions;
using ERP.Infrastructure.Configurations;
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
        public DbSet<Department> Departments { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreCategory> StoreCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            #region BaseEntity Configuration
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
            #endregion

            #region Apply Entity Configurations
            // Apply all entity configurations from separate files
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new RegionConfiguration());
            modelBuilder.ApplyConfiguration(new UnitConfiguration());
            modelBuilder.ApplyConfiguration(new ItemCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ItemRegistryConfiguration());
            modelBuilder.ApplyConfiguration(new ClientPriceListConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new StoreConfiguration());
            modelBuilder.ApplyConfiguration(new StoreCategoryConfiguration());
            #endregion
        }
    }
}
