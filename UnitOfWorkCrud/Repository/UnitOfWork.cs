using UnitOfWorkCrud.Data;
using UnitOfWorkCrud.Interface;
using Microsoft.EntityFrameworkCore.Storage;

namespace UnitOfWorkCrud.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction _transaction;
        private readonly ILogger _logger;
        public Dictionary<Type, object> Repositories = new Dictionary<Type, object>();
       

        public UnitOfWork(ApplicationDbContext context
                                ,ILogger logger)
        {
            _context = context;
           
            _logger = logger;
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

        public IGenericRepository<T> AsyncRepositories<T>()
            where T : class
        {
            if (Repositories.Keys.Contains(typeof(T)) == true)
            {
                return Repositories[typeof(T)] as IGenericRepository<T>;
            }
            IGenericRepository<T> repo = new ApplicationRepository<T>(_context);
            Repositories.Add(typeof(T), repo);
            return repo;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        public async Task BeginTransaction()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
            _logger.LogInformation("Transaction started.");
        }

        public async Task CommitTransaction()
        {
             _transaction.Commit();
            _logger
                .LogInformation("Transaction committed successfully.");
        }

        public async Task RollBackTransaction()
        {
            _transaction.Rollback();
            _logger.LogCritical("Transaction rolled back.");
        }

        public async Task SavePointAsync(string savePointName)
        {
           _transaction.CreateSavepoint(savePointName);
            _logger.LogInformation($"Save point '{savePointName}' created.");

        }

        public async Task RollBackToSavePointAsync(string savePointName)
        {
           _transaction.RollbackToSavepoint(savePointName);
            _logger.LogCritical($"Rolled back to save point '{savePointName}'.");
        }
    }
}
