using eCommerceAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farmersAPi.Models
{
    public class APIContext : DbContext
    {
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {

        }

        public DbSet<Categories> Category { get; set; }
        public DbSet<Products> Product { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Users>()
                 .HasMany(o => o.Orders)
                 .WithOne(u => u.User);

            modelBuilder.Entity<Categories>()
                .HasMany(p => p.Products)
                .WithOne(c => c.Category)
                .HasForeignKey(p => p.CategoryId);
               

            modelBuilder.Entity<Orders>()
                .HasMany(od => od.OrderDetails)
                .WithOne(o => o.Order)
                .HasForeignKey(od=>od.OrderId);

            modelBuilder.Entity<Products>().Property(p => p.ProductSKU).ValueGeneratedOnAdd();


           




        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
