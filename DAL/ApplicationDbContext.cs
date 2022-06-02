using Microsoft.EntityFrameworkCore;
using CarMarket.Domain.Entity;

namespace CarMarket.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Car> Car { get; set; }
    }
}
