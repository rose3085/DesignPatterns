namespace UnitOfWorkCrud.Interface
{
    public interface IUnitOfWork : IDisposable
    {


        IGenericRepository<T> AsyncRepositories<T>()
            where T : class;
        int save();
        Task BeginTransaction();
        Task CommitTransaction();
        Task RollBackTransaction();

        Task SavePointAsync(string savePointName);
        Task RollBackToSavePointAsync(string savePointName);
    }
}
