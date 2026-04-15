using ERP.Application.Common.Exceptions;
using ERP.Domain.Entities.GeneralDefinitions;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Validation
{
    public interface IEntityValidator<T> where T : BaseEntity
    {
        Task ValidateAsync(T entity, AppDbContext context);
    }

    public class CountryValidator : IEntityValidator<Country>
    {
        public async Task ValidateAsync(Country entity, AppDbContext context)
        {
            var errors = new List<string>();

            if (await context.Countries.AnyAsync(c => c.CountryCode == entity.CountryCode && c.Id != entity.Id && !c.IsDeleted))
                errors.Add("A country with this code already exists.");
            
            if (await context.Countries.AnyAsync(c => c.CountryName == entity.CountryName && c.Id != entity.Id && !c.IsDeleted))
                errors.Add("A country with this name already exists.");

            if (errors.Any())
                throw new ValidationException(errors);
        }
    }

    public class ClientValidator : IEntityValidator<Client>
    {
        public async Task ValidateAsync(Client entity, AppDbContext context)
        {
            var errors = new List<string>();

            if (await context.Clients.AnyAsync(c => c.FullName == entity.FullName && c.Id != entity.Id && !c.IsDeleted))
                errors.Add("A client with this name already exists.");
            
            if (!string.IsNullOrEmpty(entity.ReferenceNo) && 
                await context.Clients.AnyAsync(c => c.ReferenceNo == entity.ReferenceNo && c.Id != entity.Id && !c.IsDeleted))
                errors.Add("A client with this reference number already exists.");
           

            if (errors.Any())
                throw new ValidationException(errors);
        }
    }

    public class SupplierValidator : IEntityValidator<Supplier>
    {
        public async Task ValidateAsync(Supplier entity, AppDbContext context)
        {
            var errors = new List<string>();

            if (await context.Suppliers.AnyAsync(s => s.Name == entity.Name && s.Id != entity.Id && !s.IsDeleted))
                errors.Add("A supplier with this name already exists.");
            
            if (!string.IsNullOrEmpty(entity.CR) && 
                await context.Suppliers.AnyAsync(s => s.CR == entity.CR && s.Id != entity.Id && !s.IsDeleted))
                errors.Add("A supplier with this CR number already exists.");
            
            if (!string.IsNullOrEmpty(entity.VATNo) && 
                await context.Suppliers.AnyAsync(s => s.VATNo == entity.VATNo && s.Id != entity.Id && !s.IsDeleted))
                errors.Add("A supplier with this VAT number already exists.");
            
            if (!string.IsNullOrEmpty(entity.AccNo) && 
                await context.Suppliers.AnyAsync(s => s.AccNo == entity.AccNo && s.Id != entity.Id && !s.IsDeleted))
                errors.Add("A supplier with this account number already exists.");

            // Validate SupplierType relationship
            if (entity.SupplierTypeId > 0)
            {
                if (!await context.SupplierTypes.AnyAsync(st => st.Id == entity.SupplierTypeId && !st.IsDeleted))
                    errors.Add($"Supplier type with ID '{entity.SupplierTypeId}' does not exist.");
            }

            if (errors.Any())
                throw new ValidationException(errors);
        }
    }

    public class CityValidator : IEntityValidator<City>
    {
        public async Task ValidateAsync(City entity, AppDbContext context)
        {
            if (await context.Cities.AnyAsync(c => c.CityName == entity.CityName && c.Id != entity.Id && !c.IsDeleted))
                throw new ValidationException(new List<string> { "A city with this name already exists." });
        }
    }

    public class RegionValidator : IEntityValidator<Region>
    {
        public async Task ValidateAsync(Region entity, AppDbContext context)
        {
            if (await context.Regions.AnyAsync(r => r.RegionName == entity.RegionName && r.Id != entity.Id && !r.IsDeleted))
                throw new ValidationException(new List<string> { "A region with this name already exists." });
        }
    }

    public class UnitValidator : IEntityValidator<Unit>
    {
        public async Task ValidateAsync(Unit entity, AppDbContext context)
        {
            if (await context.Units.AnyAsync(u => u.UnitName == entity.UnitName && u.Id != entity.Id && !u.IsDeleted))
                throw new ValidationException(new List<string> { "A unit with this name already exists." });
        }
    }

    public class ItemCategoryValidator : IEntityValidator<ItemCategory>
    {
        public async Task ValidateAsync(ItemCategory entity, AppDbContext context)
        {
            var errors = new List<string>();

            if (await context.ItemCategories.AnyAsync(ic => ic.ItemCategoryName == entity.ItemCategoryName && ic.Id != entity.Id && !ic.IsDeleted))
                errors.Add("An item category with this name already exists.");
            
            if (!string.IsNullOrEmpty(entity.AccName) && 
                await context.ItemCategories.AnyAsync(ic => ic.AccName == entity.AccName && ic.Id != entity.Id && !ic.IsDeleted))
                errors.Add("An item category with this account name already exists.");

            if (errors.Any())
                throw new ValidationException(errors);
        }
    }

    public class ClientContactValidator : IEntityValidator<ClientContact>
    {
        public async Task ValidateAsync(ClientContact entity, AppDbContext context)
        {
            // ClientContact doesn't have unique constraints based on current structure
            // Add validation if needed in the future
            await Task.CompletedTask;
        }
    }

    public class ClientPriceListValidator : IEntityValidator<ClientPriceList>
    {
        public async Task ValidateAsync(ClientPriceList entity, AppDbContext context)
        {
            // ClientPriceList doesn't have unique constraints based on current structure
            // Add validation if needed in the future
            await Task.CompletedTask;
        }
    }

    public class ClientTypeValidator : IEntityValidator<ClientType>
    {
        public async Task ValidateAsync(ClientType entity, AppDbContext context)
        {
            if (await context.ClientTypes.AnyAsync(ct => ct.Type == entity.Type && ct.Id != entity.Id && !ct.IsDeleted))
                throw new ValidationException(new List<string> { "A client type with this name already exists." });
        }
    }

    public class ItemListValidator : IEntityValidator<ItemList>
    {
        public async Task ValidateAsync(ItemList entity, AppDbContext context)
        {
            // ItemList doesn't have unique constraints based on current structure
            // Add validation if needed in the future
            await Task.CompletedTask;
        }
    }

    public class ItemRegistryValidator : IEntityValidator<ItemRegistry>
    {
        public async Task ValidateAsync(ItemRegistry entity, AppDbContext context)
        {
            // ItemRegistry doesn't have unique constraints based on current structure
            // Add validation if needed in the future
            await Task.CompletedTask;
        }
    }

    public class SupplierContactValidator : IEntityValidator<SupplierContact>
    {
        public async Task ValidateAsync(SupplierContact entity, AppDbContext context)
        {
            // SupplierContact doesn't have unique constraints based on current structure
            // Add validation if needed in the future
            await Task.CompletedTask;
        }
    }

    public class SupplierItemValidator : IEntityValidator<SupplierItem>
    {
        public async Task ValidateAsync(SupplierItem entity, AppDbContext context)
        {
            // SupplierItem doesn't have unique constraints based on current structure
            // Add validation if needed in the future
            await Task.CompletedTask;
        }
    }

    public class SupplierTypeValidator : IEntityValidator<SupplierType>
    {
        public async Task ValidateAsync(SupplierType entity, AppDbContext context)
        {
            if (await context.SupplierTypes.AnyAsync(st => st.Type == entity.Type && st.Id != entity.Id && !st.IsDeleted))
                throw new ValidationException(new List<string> { "A supplier type with this name already exists." });
        }
    }

    public class DepartmentValidator : IEntityValidator<Department>
    {
        public async Task ValidateAsync(Department entity, AppDbContext context)
        {
            var errors = new List<string>();

            if (await context.Departments.AnyAsync(d => d.DepartmentName == entity.DepartmentName && d.Id != entity.Id && !d.IsDeleted))
                errors.Add("A department with this name already exists.");

            if (errors.Any())
                throw new ValidationException(errors);
        }
    }
}
