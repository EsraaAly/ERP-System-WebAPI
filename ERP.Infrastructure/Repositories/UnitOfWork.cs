


namespace ERP.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        // Private backing fields for lazy initialization
        private IGenericRepository<City> _cities;
        private IGenericRepository<Client> _clients;
        private IGenericRepository<ClientContact> _clientContacts;
        private IGenericRepository<ClientPriceList> _clientPriceLists;
        private IGenericRepository<ClientType> _clientTypes;
        private IGenericRepository<Country> _countries;
        private IGenericRepository<ItemCategory> _itemCategories;
        private IItemListRepository _itemLists;
        private IGenericRepository<ItemRegistry> _itemRegistries;
        private IGenericRepository<Region> _regions;
        private IGenericRepository<Supplier> _suppliers;
        private IGenericRepository<SupplierContact> _supplierContacts;
        private IGenericRepository<SupplierItem> _supplierItems;
        private IGenericRepository<SupplierType> _supplierTypes;
        private IGenericRepository<Unit> _unit;
        private IGenericRepository<Department> _departments;
        private IGenericRepository<Store> _stores;
        private IGenericRepository<StoreCategory> _storeCategories;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }


        // Repository properties for all entities
        public IGenericRepository<City> Cities => _cities ??= new GenericRepository<City>(_context);
        public IGenericRepository<Client> Clients => _clients ??= new GenericRepository<Client>(_context);
        public IGenericRepository<ClientContact> ClientContacts => _clientContacts ??= new GenericRepository<ClientContact>(_context);
        public IGenericRepository<ClientPriceList> ClientPriceLists => _clientPriceLists ??= new GenericRepository<ClientPriceList>(_context);
        public IGenericRepository<ClientType> ClientTypes => _clientTypes ??= new GenericRepository<ClientType>(_context);
        public IGenericRepository<Country> Countries => _countries ??= new GenericRepository<Country>(_context);
        public IGenericRepository<ItemCategory> ItemCategories => _itemCategories ??= new GenericRepository<ItemCategory>(_context);
        public IItemListRepository ItemLists => _itemLists ??= new ItemListRepository(_context);
        public IGenericRepository<ItemRegistry> ItemRegistries => _itemRegistries ??= new GenericRepository<ItemRegistry>(_context);
        public IGenericRepository<Region> Regions => _regions ??= new GenericRepository<Region>(_context);
        public IGenericRepository<Supplier> Suppliers => _suppliers ??= new GenericRepository<Supplier>(_context);
        public IGenericRepository<SupplierContact> SupplierContacts => _supplierContacts ??= new GenericRepository<SupplierContact>(_context);
        public IGenericRepository<SupplierItem> SupplierItems => _supplierItems ??= new GenericRepository<SupplierItem>(_context);
        public IGenericRepository<SupplierType> SupplierTypes => _supplierTypes ??= new GenericRepository<SupplierType>(_context);
        public IGenericRepository<Unit> Unit => _unit ??= new GenericRepository<Unit>(_context);
        public IGenericRepository<Department> Departments => _departments ??= new GenericRepository<Department>(_context);
        public IGenericRepository<Store> Stores => _stores ??= new GenericRepository<Store>(_context);
        public IGenericRepository<StoreCategory> StoreCategories => _storeCategories ??= new GenericRepository<StoreCategory>(_context);

        public async Task CommitAsync() => await _context.SaveChangesAsync();

        //public async void Dispose() => await _context.DisposeAsync();
    }
}
