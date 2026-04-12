using ERP.Domain.Entities.GeneralDefinitions;

namespace ERP.Infrastructure.Validation
{
    public static class ValidationFactory
    {
        private static readonly Dictionary<Type, object> _validators = new()
        {
            { typeof(Country), new CountryValidator() },
            { typeof(Client), new ClientValidator() },
            { typeof(Supplier), new SupplierValidator() },
            { typeof(City), new CityValidator() },
            { typeof(Region), new RegionValidator() },
            { typeof(Unit), new UnitValidator() },
            { typeof(ItemCategory), new ItemCategoryValidator() },
            { typeof(ClientContact), new ClientContactValidator() },
            { typeof(ClientPriceList), new ClientPriceListValidator() },
            { typeof(ClientType), new ClientTypeValidator() },
            { typeof(ItemList), new ItemListValidator() },
            { typeof(ItemRegistry), new ItemRegistryValidator() },
            { typeof(SupplierContact), new SupplierContactValidator() },
            { typeof(SupplierItem), new SupplierItemValidator() },
            { typeof(SupplierType), new SupplierTypeValidator() },
            { typeof(Department), new DepartmentValidator() }
        };

        public static IEntityValidator<TEntity>? GetValidator<TEntity>() where TEntity : BaseEntity
        {
            if (_validators.TryGetValue(typeof(TEntity), out var validator))
            {
                return validator as IEntityValidator<TEntity>;
            }
            return null;
        }
    }
}
