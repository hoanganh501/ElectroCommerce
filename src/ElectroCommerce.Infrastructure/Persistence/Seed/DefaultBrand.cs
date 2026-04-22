using Domain.Entities;

namespace Infrastructure.Persistence.Seed
{
    public static class DefaultBrand
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (!context.Brands.Any())
            {
                var brands = new List<Brand>
                {
                    new Brand { Name = "Apple" },
                    new Brand { Name = "Samsung" },
                    new Brand { Name = "Dell" },
                    new Brand { Name = "HP" },
                    new Brand { Name = "Lenovo" }
                };
                context.Brands.AddRange(brands);
                await context.SaveChangesAsync();
            }
        }
    }
}
