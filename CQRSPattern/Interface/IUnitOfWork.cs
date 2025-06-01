namespace CQRSPattern.Interface
{
    public interface IUnitOfWork : IDisposable
    {


        IGenericRepository<T> AsyncRepositories<T>()
            where T : class;
        int save();
    }
}
