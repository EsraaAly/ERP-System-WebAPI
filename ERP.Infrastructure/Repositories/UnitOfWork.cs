
namespace ERP.Infrastructure.Repositories
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CommitAsync() => await _context.SaveChangesAsync();


        //public async void Dispose() => await _context.DisposeAsync();
    }
}
