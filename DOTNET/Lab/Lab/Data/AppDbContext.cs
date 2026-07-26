using Lab.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> option):DbContext(option)
    {
        public DbSet<Lab.Models.User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }

    }
}
