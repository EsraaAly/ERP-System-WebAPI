using ERP.Application.Common.Interfaces.IPersistence;
using ERP.Domain.Entities.GeneralDefinitions;

namespace ERP.Infrastructure
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"),
                sqlOptions => sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

            // Register generic repositories for all entities
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            // Register specific entity repositories
            services.AddScoped<IGenericRepository<City>, GenericRepository<City>>();
            services.AddScoped<IGenericRepository<Client>, GenericRepository<Client>>();
            services.AddScoped<IGenericRepository<ClientContact>, GenericRepository<ClientContact>>();
            services.AddScoped<IGenericRepository<ClientPriceList>, GenericRepository<ClientPriceList>>();
            services.AddScoped<IGenericRepository<ClientType>, GenericRepository<ClientType>>();
            services.AddScoped<IGenericRepository<Country>, GenericRepository<Country>>();
            services.AddScoped<IGenericRepository<ItemCategory>, GenericRepository<ItemCategory>>();
            services.AddScoped<IGenericRepository<ItemList>, GenericRepository<ItemList>>();
            services.AddScoped<IGenericRepository<ItemRegistry>, GenericRepository<ItemRegistry>>();
            services.AddScoped<IGenericRepository<Region>, GenericRepository<Region>>();
            services.AddScoped<IGenericRepository<Supplier>, GenericRepository<Supplier>>();
            services.AddScoped<IGenericRepository<SupplierContact>, GenericRepository<SupplierContact>>();
            services.AddScoped<IGenericRepository<SupplierItem>, GenericRepository<SupplierItem>>();
            services.AddScoped<IGenericRepository<SupplierType>, GenericRepository<SupplierType>>();
            services.AddScoped<IGenericRepository<Unit>, GenericRepository<Unit>>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
