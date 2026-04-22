using Domain.Entities;

namespace Infrastructure.Persistence.Seed
{
    public class DefaultSupelier
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (!context.Suppliers.Any())
            {
                var suppliers = new List<Supplier>
                {
                    new Supplier { Name = "Samsung", Email = "contact@samsung.com" },
                    new Supplier { Name = "Apple", Email = "contact@apple.com" }
                };
                context.Suppliers.AddRange(suppliers);
                await context.SaveChangesAsync();
            }
        }
    }
}
