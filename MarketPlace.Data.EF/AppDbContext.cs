using MarketPlace.Data.EF.Configurations;
using MarketPlace.Data.EF.Extentions;
using MarketPlace.Data.Entities;
using MarketPlace.Data.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MarketPlace.Data.EF
{
    public class AppDbContext : IdentityDbContext<CusUser, CusUserRole, int>
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<ActionInFunction> ActionInFunctions { get; set; }
        public DbSet<CustomAttribute> CustomAttributes { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<ChatSession> ChatSessions { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<DoAction> DoActions { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Permission> permissions { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostInCategory> PostInCategories { get; set; }
        public DbSet<PostInTag> PostInTags { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<CusRole> CusRoles { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<CusUser> CusUsers { get; set; }
        public DbSet<CusUserRole> CusUserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.AddConfiguration(new TagConfiguration());
            base.OnModelCreating(builder);
        }
        public override int SaveChanges()
        {
            var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
            foreach(EntityEntry item in modified)
            {
                var changeOrAddedItem = item.Entity as IDateTracking;
                if (changeOrAddedItem != null)
                {
                    if (item.State == EntityState.Added)
                    {
                        changeOrAddedItem.DateCreated = DateTime.Now;

                    }
                    changeOrAddedItem.DateModified = DateTime.Now;
                }    
            }    
            return base.SaveChanges();
        }
    }
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new AppDbContext(builder.Options);
        }
    }
}
