using CQRSPattern.Data;
using CQRSPattern.Interface;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace CQRSPattern.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
                                                                //where TEntity : class
                                                                //where TDto : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _db;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

       

        public async Task AddUser(T entities)
        {
            await _db.AddAsync(entities);
        
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _db.ToListAsync();
        }
        public async Task<T> GetById(int id)
        {

            return await _db.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetGeneric<T>(Expression<Func<T, bool>> filter = null) where T : class
        {
            
            IQueryable<T> query = _context.Set<T>();
            if (filter != null)
            {
                query = query.Where(filter);

            }
            return await query.ToListAsync();
        }

        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        
        public void DeleteRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }
    }
}
