using Domain.Entities;

namespace Infrastructure.Persistence.Seed
{
    public static class DefaultCategory
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Smartphones" },
                    new Category { Name = "Tablets" },
                    new Category { Name = "Laptops" },
                    new Category { Name = "Desktops" },
                    new Category { Name = "Monitors" }
                };
                context.Categories.AddRange(categories);
                await context.SaveChangesAsync();

            }
        }
    }
}
