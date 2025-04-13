using Assignment_1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Assignment_1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseNpgsql("User Id=postgres.nynhhhaxocqebzxiqdoh;Password=zaq123ZAQ!@#;Server=aws-0-ca-central-1.pooler.supabase.com;Port=5432;Database=postgres");
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<OrdersViewModel> Orders { get; set; }
        public DbSet<Products_Orders> OrderProducts { get; set; }
        public DbSet<Products_Categories> ProductsCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products_Orders>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<Categories>().HasData(
                new Categories { CategoryId = 1, Name = "Electronics", Description = "Electronic items" },
                new Categories { CategoryId = 2, Name = "Clothing", Description = "Apparel and accessories" }
            );

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey });

            
            modelBuilder.Entity<Products>()
                .HasOne(p => p.Categories)  
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired();

            
            modelBuilder.Entity<Products_Categories>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            modelBuilder.Entity<Products_Categories>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductsCategories)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<Products_Categories>()
                .HasOne(pc => pc.Categories)  
                .WithMany(c => c.ProductsCategories)
                .HasForeignKey(pc => pc.CategoryId);

           
            modelBuilder.Entity<Products>().HasData(
                new Products
                {
                    ProductId = 1, Name = "Laptop", Description = "Gaming laptop", Price = 1500, QuantityInStock = 10,
                    LowStockThreshold = 2, CategoryId = 1 
                },
                new Products
                {
                    ProductId = 2, Name = "T-shirt", Description = "Cotton t-shirt", Price = 20, QuantityInStock = 50,
                    LowStockThreshold = 10, CategoryId = 2 
                }
            );
        }
    }
}