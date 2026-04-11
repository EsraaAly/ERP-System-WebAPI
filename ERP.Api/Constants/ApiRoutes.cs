namespace ERP.Api.Constants
{
    public class ApiRoutes
    {
        public const string Version = "v1";

        public static class GeneralDefinitions
        {
            public static class Cities
            {
                public const string GetAllCities = $"api/{Version}/cities/GetAll";
                public const string GetCityById = $"api/{Version}/cities/GetById";
                public const string AddCity = $"api/{Version}/cities/Add";
                public const string UpdateCity = $"api/{Version}/cities/Update";
                public const string DeleteCity = $"api/{Version}/cities/Delete";
            }

            public static class Clients
            {
                public const string GetAllClients = $"api/{Version}/clients/GetAll";
                public const string GetClientById = $"api/{Version}/clients/GetById";
                public const string AddClient = $"api/{Version}/clients/Add";
                public const string UpdateClient = $"api/{Version}/clients/Update";
                public const string DeleteClient = $"api/{Version}/clients/Delete";
            }

            public static class Suppliers
            {
                public const string GetAllSuppliers = $"api/{Version}/suppliers/GetAll";
                public const string GetSupplierById = $"api/{Version}/suppliers/GetById";
                public const string AddSupplier = $"api/{Version}/suppliers/Add";
                public const string UpdateSupplier = $"api/{Version}/suppliers/Update";
                public const string DeleteSupplier = $"api/{Version}/suppliers/Delete";
            }

            public static class Countries
            {
                public const string GetAllCountries = $"api/{Version}/countries/GetAll";
                public const string GetCountryById = $"api/{Version}/countries/GetById";
                public const string AddCountry = $"api/{Version}/countries/Add";
                public const string UpdateCountry = $"api/{Version}/countries/Update";
                public const string DeleteCountry = $"api/{Version}/countries/Delete";
            }

            public static class Regions
            {
                public const string GetAllRegions = $"api/{Version}/regions/GetAll";
                public const string GetRegionById = $"api/{Version}/regions/GetById";
                public const string AddRegion = $"api/{Version}/regions/Add";
                public const string UpdateRegion = $"api/{Version}/regions/Update";
                public const string DeleteRegion = $"api/{Version}/regions/Delete";
            }

            public static class Units
            {
                public const string GetAllUnits = $"api/{Version}/units/GetAll";
                public const string GetUnitById = $"api/{Version}/units/GetById";
                public const string AddUnit = $"api/{Version}/units/Add";
                public const string UpdateUnit = $"api/{Version}/units/Update";
                public const string DeleteUnit = $"api/{Version}/units/Delete";
            }

            public static class ClientTypes
            {
                public const string GetAllClientTypes = $"api/{Version}/clienttypes/GetAll";
                public const string GetClientTypeById = $"api/{Version}/clienttypes/GetById";
                public const string AddClientType = $"api/{Version}/clienttypes/Add";
                public const string UpdateClientType = $"api/{Version}/clienttypes/Update";
                public const string DeleteClientType = $"api/{Version}/clienttypes/Delete";
            }

            public static class SupplierTypes
            {
                public const string GetAllSupplierTypes = $"api/{Version}/suppliertypes/GetAll";
                public const string GetSupplierTypeById = $"api/{Version}/suppliertypes/GetById";
                public const string AddSupplierType = $"api/{Version}/suppliertypes/Add";
                public const string UpdateSupplierType = $"api/{Version}/suppliertypes/Update";
                public const string DeleteSupplierType = $"api/{Version}/suppliertypes/Delete";
            }

            public static class ItemCategories
            {
                public const string GetAllItemCategories = $"api/{Version}/itemcategories/GetAll";
                public const string GetItemCategoryById = $"api/{Version}/itemcategories/GetById";
                public const string AddItemCategory = $"api/{Version}/itemcategories/Add";
                public const string UpdateItemCategory = $"api/{Version}/itemcategories/Update";
                public const string DeleteItemCategory = $"api/{Version}/itemcategories/Delete";
            }

            public static class ClientContacts
            {
                public const string GetAllClientContacts = $"api/{Version}/clientcontacts/GetAll";
                public const string GetClientContactById = $"api/{Version}/clientcontacts/GetById";
                public const string AddClientContact = $"api/{Version}/clientcontacts/Add";
                public const string UpdateClientContact = $"api/{Version}/clientcontacts/Update";
                public const string DeleteClientContact = $"api/{Version}/clientcontacts/Delete";
            }

            public static class SupplierContacts
            {
                public const string GetAllSupplierContacts = $"api/{Version}/suppliercontacts/GetAll";
                public const string GetSupplierContactById = $"api/{Version}/suppliercontacts/GetById";
                public const string AddSupplierContact = $"api/{Version}/suppliercontacts/Add";
                public const string UpdateSupplierContact = $"api/{Version}/suppliercontacts/Update";
                public const string DeleteSupplierContact = $"api/{Version}/suppliercontacts/Delete";
            }

            public static class SupplierItems
            {
                public const string GetAllSupplierItems = $"api/{Version}/supplieritems/GetAll";
                public const string GetSupplierItemById = $"api/{Version}/supplieritems/GetById";
                public const string AddSupplierItem = $"api/{Version}/supplieritems/Add";
                public const string UpdateSupplierItem = $"api/{Version}/supplieritems/Update";
                public const string DeleteSupplierItem = $"api/{Version}/supplieritems/Delete";
            }

            public static class ClientPriceLists
            {
                public const string GetAllClientPriceLists = $"api/{Version}/clientpricelists/GetAll";
                public const string GetClientPriceListById = $"api/{Version}/clientpricelists/GetById";
                public const string AddClientPriceList = $"api/{Version}/clientpricelists/Add";
                public const string UpdateClientPriceList = $"api/{Version}/clientpricelists/Update";
                public const string DeleteClientPriceList = $"api/{Version}/clientpricelists/Delete";
            }

            public static class ItemLists
            {
                public const string GetAllItemLists = $"api/{Version}/itemlists/GetAll";
                public const string GetItemListById = $"api/{Version}/itemlists/GetById";
                public const string AddItemList = $"api/{Version}/itemlists/Add";
                public const string UpdateItemList = $"api/{Version}/itemlists/Update";
                public const string DeleteItemList = $"api/{Version}/itemlists/Delete";
            }

            public static class ItemRegistries
            {
                public const string GetAllItemRegistries = $"api/{Version}/itemregistries/GetAll";
                public const string GetItemRegistryById = $"api/{Version}/itemregistries/GetById";
                public const string AddItemRegistry = $"api/{Version}/itemregistries/Add";
                public const string UpdateItemRegistry = $"api/{Version}/itemregistries/Update";
                public const string DeleteItemRegistry = $"api/{Version}/itemregistries/Delete";
            }
        }
    }
}
