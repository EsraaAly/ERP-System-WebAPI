namespace ERP.Application.Common.Interfaces.IPersistence
{
    public interface IUnitOfWork
    {


        public Task CommitAsync();
        //public void Dispose();

    }
}
