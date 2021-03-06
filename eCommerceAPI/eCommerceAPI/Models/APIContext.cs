﻿using eCommerceAPI.Models;
using eCommerceAPI.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections;
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
                 .WithOne(u => u.User)
                 .HasForeignKey(o=>o.UserId)
                 ;

            modelBuilder.Entity<Categories>()
                .HasMany(p => p.Products)
                .WithOne(c => c.Category)
                .HasForeignKey(p => p.CategoryId);
               

            modelBuilder.Entity<Orders>()
                .HasMany(od => od.OrderDetails)
                .WithOne(o => o.Order)
                .HasForeignKey(od=>od.OrderId);

            modelBuilder.Entity<Products>().Property(p => p.ProductSKU).ValueGeneratedOnAdd();


            /* var valueComparer = new ValueComparer<ICollection<Dictionary<string, int>>>(
                  (c1, c2) => c1.SequenceEqual(c2),
                   c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                   c => (ICollection<Dictionary<string, int>>)c.ToHashSet());*/

            modelBuilder.Entity<Products>()
                .Property(p => p.Size)
                .HasConversion(s => JsonConvert.SerializeObject(s),
                s => JsonConvert.DeserializeObject<List<ProductQuantity>>(s));
               


            

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
