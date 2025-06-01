using CQRSPattern.Data;
using CQRSPattern.Interface;

namespace CQRSPattern.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        
        public Dictionary<Type, object> Repositories = new Dictionary<Type, object>();
        public UnitOfWork(ApplicationDbContext context
                           )
        {
            _context = context;
           
        }


        public int save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        public IGenericRepository<T> AsyncRepositories<T>() where T : class
        {
            if (Repositories.Keys.Contains(typeof(T)))
            {
                return Repositories[typeof(T)] as IGenericRepository<T>;
            }

            IGenericRepository<T> repo = new ApplicationRepository<T>(_context);
            Repositories.Add(typeof(T), repo);
            return repo;
        }
    }
}
