using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ecommerce.Models.DB
{
    public partial class EcommDBContext : DbContext
    {
        public EcommDBContext()
        { 

        }

        public EcommDBContext(DbContextOptions<EcommDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<OrderMaster> OrderMasters { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EcommDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");
               

                entity.Property(e => e.Logo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ProductId).HasColumnName("Product_id");

                entity.Property(e => e.UserId).HasColumnName("User_id");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Image)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.OrderId).HasColumnName("Order_id");

                entity.Property(e => e.ProductId).HasColumnName("Product_id");
            });

            modelBuilder.Entity<OrderMaster>(entity =>
            {
                entity.ToTable("OrderMaster");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.OrderAmount).HasColumnName("Order_amount");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("Order_date");

                entity.Property(e => e.UserId).HasColumnName("User_id");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.CategoryId).HasColumnName("Category Id");

                entity.Property(e => e.Image)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
