
using Microsoft.EntityFrameworkCore;
using CQRSPattern.Data;
using CQRSPattern.DTO;
using CQRSPattern.Interface;
using CQRSPattern.Model;

namespace CQRSPattern.Repository
{
    public class ApplicationRepository<T> : GenericRepository<T>, IApplicationRepository<T> where T : class
    {
        public ApplicationRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
