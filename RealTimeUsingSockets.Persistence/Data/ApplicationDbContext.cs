using Microsoft.EntityFrameworkCore;
using RealTimeUsingSockets.Domain.Models;

namespace RealTimeUsingSockets.Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
