
using Microsoft.EntityFrameworkCore;
using CQRSPattern.Data;
using CQRSPattern.DTO;
using CQRSPattern.Interface;
using CQRSPattern.Model;

namespace CQRSPattern.Repository
{
    public class UserRepository : GenericRepository<UserModel>, IUserRepository
    {
       
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        //public async Task AddUser(UserDto userDto)
        //{
        //    var user = _mapper.Map<UserModel>(userDto);
        //    //await _context.Set<UserModel>().AddAsync(user);
        //    //await _context.SaveChangesAsync();
        //}

        
    }
}
