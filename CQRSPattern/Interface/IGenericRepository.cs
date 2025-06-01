using System.Linq.Expressions;

namespace CQRSPattern.Interface
{
    public interface IGenericRepository<T> where T : class
    {

        Task<T> GetById(int id);
        Task AddUser(T entities);
        Task<IEnumerable<T>> GetAllAsync();


        // to get somehting without id using Generic
        // to use lambda expression we need Generic function
        Task<IEnumerable<T>> GetGeneric<T>(Expression<Func<T, bool>> filter = null) where T : class;

        void DeleteRange(IEnumerable<T> entities);
        void Update(T entity);

    }
}
