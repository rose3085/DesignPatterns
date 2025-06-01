using CQRSPattern.DTO;
using CQRSPattern.Model;

namespace CQRSPattern.Interface
{
    public interface IApplicationRepository<T> : IGenericRepository<T> where T : class
    {
    }
}
