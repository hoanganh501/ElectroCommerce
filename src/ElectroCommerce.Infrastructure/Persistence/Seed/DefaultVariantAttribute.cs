using Domain.Entities;
using ElectroCommerce.Domain.Entities;
using Infrastructure.Persistence;

namespace ElectroCommerce.Infrastructure.Persistence.Seed
{
    public class DefaultVariantAttribute
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (!context.VariantAttributes.Any())
            {
                var variantAttributes = new List<VariantAttribute>
                {
                    new VariantAttribute
                    {
                        Name = "Color",
                        AttributeValues = new List<VariantAttributeValue>
                        {
                            new VariantAttributeValue { Value = "Red" },
                            new VariantAttributeValue { Value = "Blue" },
                            new VariantAttributeValue { Value = "Green" }
                        }
                    },
                    new VariantAttribute
                    {
                        Name = "Ram",
                        AttributeValues = new List<VariantAttributeValue>
                        {
                            new VariantAttributeValue { Value = "4GB" },
                            new VariantAttributeValue { Value = "8GB" },
                            new VariantAttributeValue { Value = "16GB" }
                        }
                    }
                };
                context.VariantAttributes.AddRange(variantAttributes);
                await context.SaveChangesAsync();
            }
        }
    }
}
