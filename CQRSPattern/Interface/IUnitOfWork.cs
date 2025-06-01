namespace CQRSPattern.Interface
{
    public interface IUnitOfWork : IDisposable
    {


        IUserRepository Name { get; }
        int save();
    }
}
