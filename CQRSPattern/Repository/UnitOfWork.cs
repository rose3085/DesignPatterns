using CQRSPattern.Data;
using CQRSPattern.Interface;

namespace CQRSPattern.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IUserRepository Name { get; }

        public UnitOfWork(ApplicationDbContext context,
                            IUserRepository userRepository)
        {
            _context = context;
            Name = userRepository;
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


    }
}
