using ESShopDAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ESShopDAL.EFCore
{
    public class ESShopContext : DbContext
    {
        public ESShopContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductLine> ProductLines { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable(nameof(Product));
            modelBuilder.Entity<ProductLine>().ToTable(nameof(ProductLine));
            modelBuilder.Entity<Order>().ToTable(nameof(Order));
        }
    }
}
