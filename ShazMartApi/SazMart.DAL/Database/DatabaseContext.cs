using Microsoft.EntityFrameworkCore;
using SazMart.DAL.ModelClass.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SazMart.DAL.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<ProductColor> ProductColors { get; set; }
        public virtual DbSet<ProductSize> ProductSizes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Color> Colors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(p => p.CreatedDateTime).IsRequired();
                entity.Property(p => p.CreatedBy).IsRequired();
                entity.Property(p => p.Status).IsRequired();
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(p => p.CreatedDateTime).IsRequired();
                entity.Property(p => p.CreatedBy).IsRequired();
                entity.Property(p => p.Status).IsRequired();
            });
            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(p => p.CreatedDateTime).IsRequired();
                entity.Property(p => p.CreatedBy).IsRequired();
                entity.Property(p => p.Status).IsRequired();
            });
            modelBuilder.Entity<Size>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(p => p.CreatedDateTime).IsRequired();
                entity.Property(p => p.CreatedBy).IsRequired();
                entity.Property(p => p.Status).IsRequired();
            });
            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(p => p.CreatedDateTime).IsRequired();
                entity.Property(p => p.CreatedBy).IsRequired();
                entity.Property(p => p.Status).IsRequired();

                entity.HasOne(p => p.Product)
                .WithMany(p => p.Tags)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<ProductSize>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.CreatedDateTime).IsRequired();
                entity.Property(p => p.CreatedBy).IsRequired();
                entity.Property(p => p.Status).IsRequired();

                entity.HasOne(p => p.Product)
                .WithMany(p => p.ProductSizes)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(p => p.Size)
                .WithMany(p => p.ProductSizes)
                .HasForeignKey(p => p.SizeId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(p => p.CreatedDateTime).IsRequired();
                entity.Property(p => p.CreatedBy).IsRequired();
                entity.Property(p => p.Status).IsRequired();

                entity.HasOne(p => p.Product)
                .WithMany(p => p.Tags)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<ProductColor>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.CreatedDateTime).IsRequired();
                entity.Property(p => p.CreatedBy).IsRequired();
                entity.Property(p => p.Status).IsRequired();

                entity.HasOne(p => p.Product)
                .WithMany(p => p.ProductColors)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(p => p.Color)
                .WithMany(p => p.ProductColors)
                .HasForeignKey(p => p.ColorId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired();
                entity.Property(p => p.Mrp).IsRequired();
                entity.Property(p => p.ProductCode).IsRequired();
                entity.Property(p => p.CreatedDateTime).IsRequired();
                entity.Property(p => p.CreatedBy).IsRequired();
                entity.Property(p => p.Status).IsRequired();

                entity.HasOne(p => p.Brand)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(p => p.Categorie)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoriId)
                .OnDelete(DeleteBehavior.Cascade);
            });


        }
    }
}
