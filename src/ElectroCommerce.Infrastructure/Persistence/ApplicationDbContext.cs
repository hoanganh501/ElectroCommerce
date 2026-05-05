using Domain.Entities;
using ElectroCommerce.Domain.Configuration;
using ElectroCommerce.Domain.Entities;
using ElectroCommerce.Infrastructure.Persistence.Seed;
using Infrastructure.Persistence.Seed;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Order> Orders { get;set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<ProductSpecification> ProductSpecifications { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<VariantAttribute> VariantAttributes { get; set; }
        public DbSet<ProductVariantAttributeValue> ProductVariantAttributeValues { get; set; }
        public DbSet<VariantAttributeValue> VariantAttributeValues { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ProductVariantAttributeValueConfiguration).Assembly);
        }

        public static async Task SeedAsync(ApplicationDbContext context)
        {
            await DefaultCategory.SeedAsync(context);
            await DefaultBrand.SeedAsync(context);
            await DefaultSupelier.SeedAsync(context);
            await DefaultVariantAttribute.SeedAsync(context);
        }
    }
}
