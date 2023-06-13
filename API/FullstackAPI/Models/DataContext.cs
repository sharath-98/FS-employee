using Microsoft.EntityFrameworkCore;

namespace FullstackAPI.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }

    }
}
