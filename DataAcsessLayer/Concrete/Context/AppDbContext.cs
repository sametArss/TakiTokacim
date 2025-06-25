using EntitiyLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsessLayer.Concrete.Context
{
    public class AppDbContext : IdentityDbContext<User>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<City>Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<UserAdress> UserAdresses  { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders  { get; set; }

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

            modelBuilder.Entity<Payment>()
    .HasOne(ua => ua.PaymentType)
    .WithMany(d => d.Payments)
    .HasForeignKey(ua => ua.TypeId)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comments>()
    .HasOne(ua => ua.User)
    .WithMany(d => d.Comments)
    .HasForeignKey(ua => ua.UserId)
    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comments>()
 .HasOne(ua => ua.Product)
 .WithMany(d => d.Comments)
 .HasForeignKey(ua => ua.ProductId)
 .OnDelete(DeleteBehavior.Restrict);

            // Order → Payment
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Payment)
                .WithMany()  // Payment üzerinde Orders koleksiyonu tanımlı değil
                .HasForeignKey(o => o.PaymentId)
                .OnDelete(DeleteBehavior.Restrict); // Cascade'i kaldırıyoruz

            // Order → UserAdress
            modelBuilder.Entity<Order>()
                .HasOne(o => o.UserAdress)
                .WithMany()
                .HasForeignKey(o => o.AdressId)
                .OnDelete(DeleteBehavior.Restrict);

            // Order → User
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Order → Cart
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Cart)
                .WithMany()
                .HasForeignKey(o => o.CartId)
                .OnDelete(DeleteBehavior.Restrict);

            // UserId artık string olduğu için foreign key tanımları uyumlu.
        }
    }
}

