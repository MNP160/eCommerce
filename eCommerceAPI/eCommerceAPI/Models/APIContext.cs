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
       


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cathegory>().ToTable("Cathegories");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Users>().ToTable("Users");
            
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
