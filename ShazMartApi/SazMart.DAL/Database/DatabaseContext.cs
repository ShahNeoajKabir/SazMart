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


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Brand>()
                .HasKey(p => p.Id);



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
                entity.HasKey(p => p.Id);
                entity.HasOne(o => o.Brand)
                .WithMany(m => m.Product)
                .HasForeignKey(f => f.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(o => o.SubCategories)
               .WithMany(m => m.Product)
               .OnDelete(DeleteBehavior.NoAction);
            });

        }
    }




}
