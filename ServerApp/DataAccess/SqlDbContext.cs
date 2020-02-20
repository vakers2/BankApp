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
        public DbSet<Citizenship> Citizenship { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Disability> Disability { get; set; }
        public DbSet<FamilyPosition> FamilyPosition { get; set; }
        public DbSet<Deposit> Deposit { get; set; }
        public DbSet<Credit> Credit { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<CreditCard> Cards { get; set; }
    }
}
