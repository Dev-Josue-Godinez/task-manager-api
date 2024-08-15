using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Models
{
    public class DBContext : DbContext
    {
        //private readonly DBContext _context;
        public DBContext(DbContextOptions options) : base(options) { }

        //public DBContext GetDBContext() { return _context; }

        public DbSet<Login> Logins { get; set; }
    }
}
