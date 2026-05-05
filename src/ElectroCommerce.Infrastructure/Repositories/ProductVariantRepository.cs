using ElectroCommerce.Domain.DTO;
using ElectroCommerce.Domain.Interface;
using Infrastructure.Persistence;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace ElectroCommerce.Infrastructure.Repositories
{
    public class ProductVariantRepository : IProductVariantRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductVariantRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProductVariantDto>> GetVariantsAsync(Guid productId, Dictionary<string, string>? filters)
        {
            var query = _dbContext.ProductVariants
                .Where(pv => pv.ProductId == productId)
                .AsQueryable();

            if (filters != null && filters.Any())
            {
                foreach (var filter in filters)
                {
                    var attrName = filter.Key.ToLower();
                    var attrValue = filter.Value.ToLower();

                    query = query.Where(pv =>
                        pv.ProductVariantAttributeValues.Any(av =>
                            av.VariantAttributeValue.Attribute.Name.ToLower() == attrName &&
                            av.VariantAttributeValue.Value.ToLower() == attrValue
                        )
                    );
                }
            }

            var result = await query
                .Select(pv => new ProductVariantDto
                {
                    Id = pv.Id,
                    Price = pv.Price,
                    Quantity = pv.Quantity,

                    Attributes = pv.ProductVariantAttributeValues
                        .Select(av => new AttributeDto
                        {
                            Name = av.VariantAttributeValue.Attribute.Name,
                            Value = av.VariantAttributeValue.Value
                        })
                        .ToList()
                })
                .ToListAsync();

            return result;
        }
    }
}
