

namespace ERP.Application.Common.Interfaces.IPersistence
{
    public interface IUnitOfWork
    {
        // Repository properties for all entities
        IGenericRepository<City> Cities { get; }
        IGenericRepository<Client> Clients { get; }
        IGenericRepository<ClientContact> ClientContacts { get; }
        IGenericRepository<ClientPriceList> ClientPriceLists { get; }
        IGenericRepository<ClientType> ClientTypes { get; }
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<ItemCategory> ItemCategories { get; }
        IGenericRepository<ItemRegistry> ItemRegistries { get; }
        IGenericRepository<Region> Regions { get; }
        IGenericRepository<Supplier> Suppliers { get; }
        IGenericRepository<SupplierContact> SupplierContacts { get; }
        IGenericRepository<SupplierItem> SupplierItems { get; }
        IGenericRepository<SupplierType> SupplierTypes { get; }
        IGenericRepository<Domain.Entities.GeneralDefinitions.Unit> Unit { get; }
        IGenericRepository<Department> Departments { get; }
        IGenericRepository<Store> Stores { get; }
        IGenericRepository<StoreCategory> StoreCategories { get; }

        IItemListRepository ItemLists { get; }

        Task CommitAsync();
        //public void Dispose();
    }
}
