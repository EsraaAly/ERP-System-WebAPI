using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Common.Interfaces.IPersistence.GeneralDefinitions
{
    public interface IItemListRepository:IGenericRepository<ItemList>
    {
        public Task<List<ItemList>> GetItemListsByCategoryIdAsync(int categoryId);
    }
}
