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

        public DbSet<Cathegory> Cathegory { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cathegory>().ToTable("Cathegories");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Orders>().ToTable("Orders");
            modelBuilder.Entity<OrderItems>().ToTable("OrderItems");


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
