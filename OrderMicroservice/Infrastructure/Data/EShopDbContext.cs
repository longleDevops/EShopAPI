using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderAPI.ApplicationCore.Entities;

namespace ProductAPI.Infrastructure.Data
{
    public class EShopDbContext : DbContext
    {
        public EShopDbContext(DbContextOptions<EShopDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get;set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }

        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(ConfigureOrder);
            modelBuilder.Entity<OrderDetails>(ConfigureOrderDetails);
            modelBuilder.Entity<OrderStatus>(ConfigureOrderStatus);

            modelBuilder.Entity<ShoppingCart>(ConfigureShoppingCart);
            modelBuilder.Entity<ShoppingCartItem>(ConfigureShoppingCartItem);
        }

        private void ConfigureOrder(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(o => o.Id);
        }

        private void ConfigureOrderDetails(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.ToTable("OrderDetails");
            builder.HasKey(o => o.Id);
        }

        private void ConfigureOrderStatus(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.ToTable("OrderStatus");
            builder.HasKey(o => o.Id);
        }
        
        private void ConfigureShoppingCart(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.ToTable("ShoppingCart");
            builder.HasKey(s => s.Id);
        }

        private void ConfigureShoppingCartItem(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder.ToTable("ShoppingCartItem");
            builder.HasKey(s => s.Id);
        }
    }
}

