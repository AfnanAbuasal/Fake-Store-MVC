using FakeStore.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=IMPLUTOGAL;Database=FakeStore_MVC;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { ID = 1, Name = "Electronics" },
                new Category { ID = 2, Name = "Home & Kitchen" },
                new Category { ID = 3, Name = "Beauty & Health" },
                new Category { ID = 4, Name = "Toys & Games" },
                new Category { ID = 5, Name = "Shoes" }
                );
        }
    }
}
