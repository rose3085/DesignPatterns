using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UnitOfWorkCrud.Data;
using UnitOfWorkCrud.DTO;
using UnitOfWorkCrud.Interface;
using UnitOfWorkCrud.Model;

namespace UnitOfWorkCrud.Repository
{
    public class ApplicationRepository<T> : GenericRepository<T>, IApplicationRepository<T>
            where T : class
    {
        public ApplicationRepository(ApplicationDbContext context)
            : base(context) { }
    }
}
