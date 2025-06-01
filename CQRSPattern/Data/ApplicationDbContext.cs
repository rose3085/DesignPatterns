using Microsoft.EntityFrameworkCore;
using CQRSPattern.Model;

namespace CQRSPattern.Data
{
    public class ApplicationDbContext : DbContext
    {



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }


        public DbSet<UserModel> User { get; set; }
    }
}
