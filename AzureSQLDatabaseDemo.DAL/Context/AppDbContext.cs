using AzureSQLDatabaseDemo.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureSQLDatabaseDemo.DAL.Context
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.orders);

            modelBuilder.Entity<Product>()
                .HasMany(c => c.orders);
        }
    }
}
