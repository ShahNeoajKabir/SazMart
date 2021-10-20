using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SazMart.DAL.ModelClass.Entities;

namespace SazMart.DAL.Database
{
    public class DatabaseContext : IdentityDbContext<AppUser, AppRole, int, IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Brand> Brand { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<SubCategories> SubCategories { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Colors> Colors { get; set; }
        public DbSet<ProductColor> ProductColor { get; set; }
        public DbSet<Sizes> Size { get; set; }
        public DbSet<ProductSize> ProductSize { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Brand>()
                .HasKey(p => p.Id);

            builder.Entity<Colors>()
                .HasKey(p => p.ColorId);

            builder.Entity<Categories>()
                .HasKey(p => p.Id);


            builder.Entity<SubCategories>(entity =>
            {
                entity.HasKey(k => k.Id);
                entity.HasOne(o => o.Categories)
                .WithMany(m => m.SubCategories)
                .HasForeignKey(f => f.CategoriesId)
                .OnDelete(DeleteBehavior.Cascade);
            });


            builder.Entity<Country>()
                .HasKey(k => k.Id);

            builder.Entity<City>()
                .HasKey(k => k.Id);

            builder.Entity<Tag>()
                .HasKey(k => k.Id);

            builder.Entity<AppUser>(entity =>
            {
                entity.HasOne(p => p.City)
                .WithMany(m => m.AppUser)
                .HasForeignKey(f => f.CityId)
                .OnDelete(DeleteBehavior.Cascade);


                entity.HasOne(p => p.Country)
                .WithMany(m => m.AppUser)
                .HasForeignKey(f => f.CountryId)
                .OnDelete(DeleteBehavior.Cascade);
            });


            builder.Entity<AppUserRole>(entity =>
            {
                entity.HasOne(o => o.AppUser)
                .WithMany(m => m.AppUserRole)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);


                entity.HasOne(o => o.AppRole)
                .WithMany(m => m.AppUserRole)
                .HasForeignKey(f => f.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.ProductId);
                entity.HasOne(o => o.Brand)
                .WithMany(m => m.Product)
                .HasForeignKey(f => f.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(o => o.SubCategories)
               .WithMany(m => m.Product)
               .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<ProductColor>(entity =>
            {
                entity.HasKey(p => p.ProductColorId);
                entity.HasOne(o => o.Product)
                .WithMany(m => m.ProductColor)
                .HasForeignKey(f => f.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(o => o.Colors)
                .WithMany(m => m.ProductColor)
                .HasForeignKey(f => f.ColorId)
                .OnDelete(DeleteBehavior.Cascade);


            });

            builder.Entity<ProductSize>(entity =>
            {
                entity.HasKey(p => p.ProductSizeId);
                entity.HasOne(o => o.Product)
                .WithMany(m => m.ProductSize)
                .HasForeignKey(f => f.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(o => o.Sizes)
                .WithMany(m => m.ProductSize)
                .HasForeignKey(f => f.SizeId)
                .OnDelete(DeleteBehavior.Cascade);


            });
        }
    }




}
