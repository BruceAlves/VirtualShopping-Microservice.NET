using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VirtualShopping.Product.Models;

namespace VirtualShopping.Product.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Models.Product> Products { get; set; }

        // Fluent API

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Category
            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);
            modelBuilder.Entity<Category>().Property(c => c.Name).HasMaxLength(100).IsRequired();

            //Product
            modelBuilder.Entity<Models.Product>().Property(p => p.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Models.Product>().Property(p => p.Description).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<Models.Product>().Property(p => p.ImageURL).HasMaxLength(255).IsRequired();
            modelBuilder.Entity<Models.Product>().Property(p => p.Price).HasPrecision(12, 2).IsRequired();
            modelBuilder.Entity<Category>().HasMany(c => c.Products).WithOne(p => p.Category).OnDelete(DeleteBehavior.Cascade);

            // Seed Data
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    Name = "Material Escolar"
                },
                new Category
                {
                    CategoryId = 2, // ID alterado para ser único
                    Name = "Acessórios"
                }
            );
        }

    }
}
