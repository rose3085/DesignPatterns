using UnitOfWorkCrud.DTO;
using UnitOfWorkCrud.Model;

namespace UnitOfWorkCrud.Interface
{
    public interface IApplicationRepository<T> : IGenericRepository<T>
       where T : class
    { }
}
