using EntitiyLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsessLayer.Concrete.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<City>Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<UserAdress> UserAdresses  { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
    .Property(p => p.ProductPrice)
    .HasColumnType("decimal(18,2)");

            // Fluent API ile ilişki tanımlama (zorunlu değil ama temiz olur)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<District>()
             .HasOne(p => p.City)
             .WithMany(c => c.Districts)
             .HasForeignKey(p => p.CityId);

            modelBuilder.Entity<UserAdress>()
             .HasOne(p => p.User)
             .WithMany(c => c.UserAdresses)
             .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<UserAdress>()
            .HasOne(p => p.City)
            .WithMany(c => c.UserAdresses)
            .HasForeignKey(p => p.CityId);

            modelBuilder.Entity<UserAdress>()
     .HasOne(ua => ua.District)
     .WithMany(d => d.UserAdresses)
     .HasForeignKey(ua => ua.DistrictId)
     .OnDelete(DeleteBehavior.Restrict);


        }
    }
}

