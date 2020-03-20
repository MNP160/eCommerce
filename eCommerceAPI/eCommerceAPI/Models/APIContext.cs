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
        public DbSet<Toxins> Toxins { get; set; }
        public DbSet<UserToxins> UserToxins { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cathegory>().ToTable("Cathegories");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Users>().Property(x => x.Account).HasConversion<string>();
            modelBuilder.Entity<Users>().Property(x => x.State).HasConversion<string>();

            modelBuilder.Entity<Toxins>().ToTable("Toxins");
            modelBuilder.Entity<UserToxins>().ToTable("USerToxins");

            modelBuilder.Entity<Toxins>().Property(x => x.Type).HasConversion<string>();
            modelBuilder.Entity<UserToxins>().Property(x => x.Type).HasConversion<string>();
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
