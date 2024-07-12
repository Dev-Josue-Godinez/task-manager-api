using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options) { }

        public DbSet<Login> Logins { get; set; }
    }
}
