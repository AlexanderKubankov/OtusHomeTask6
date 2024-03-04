using HomeTask6.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeTask6.Infrastructure
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Profile> Profiles { get; set; }
    }
}
