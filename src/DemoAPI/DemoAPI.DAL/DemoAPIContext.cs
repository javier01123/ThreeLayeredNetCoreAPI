using DemoAPI.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.DAL
{
    public class DemoAPIContext : DbContext
    {
        public DemoAPIContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ExceptionLog> ExceptionLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DemoAPIContext).Assembly);
        }
    }
}
