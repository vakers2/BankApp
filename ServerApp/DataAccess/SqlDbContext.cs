using Microsoft.EntityFrameworkCore;
using ServerApp.Models;

namespace ServerApp.DataAccess
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options)
           : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Citizenship> Citizenships { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Disability> Disabilities { get; set; }
        public DbSet<FamilyPosition> FamilyPositions { get; set; }
    }
}
