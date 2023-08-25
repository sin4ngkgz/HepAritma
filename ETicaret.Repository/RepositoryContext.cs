using ETicaret.Model;
using ETicaret.Model.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Repository
{
    public class RepositoryContext : DbContext 
    {
        public RepositoryContext(DbContextOptions options) : base(options) 
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<V_ActiveUsers>().HasNoKey();
            modelBuilder.Entity<User>().Property(d => d.RegistryDate).HasDefaultValue();
        }


        public DbSet<Address> Addresses { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartProduct> CartProducts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryMainMenu> CategoryMainMenus { get; set; }

        public DbSet<CategoryPropertyGroup> CategoryPropertyGroups { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<District> Districts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<ProductPhoto> ProductPhotos { get; set; }

        public DbSet<ProductProperty> ProductProperties { get; set; }

        public DbSet<Property> Properties { get; set; }

        public DbSet<PropertyGroup> PropertyGroups { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

       


        public DbSet<V_ActiveUsers> ActiveUsers { get; set; }

        public DbSet<V_CategoryList> CategoryList { get; set; }

        public DbSet<V_AddressList> AddressList { get; set; }
    }
}
