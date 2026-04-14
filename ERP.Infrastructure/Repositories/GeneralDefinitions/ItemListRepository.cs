using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Infrastructure.Repositories.GeneralDefinitions
{
    public class ItemListRepository : GenericRepository<ItemList>, IItemListRepository
    {
        private readonly AppDbContext _appDbContext;
        public ItemListRepository(AppDbContext appDbContext) : base(appDbContext)
        {
                _appDbContext = appDbContext;
        }
        public Task<List<ItemList>> GetItemListsByCategoryIdAsync(int categoryId)
        {
            return _appDbContext.ItemLists.Where(i => i.ItemCategoryId == categoryId).AsNoTracking().ToListAsync();
        }
    }
}
