using Domain.Entities;
using Domain.Enum;
using ElectroCommerce.Domain.DTO;
using ElectroCommerce.Domain.DTO.Request;
using ElectroCommerce.Domain.Interface;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ElectroCommerce.Infrastructure.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Guid> SaveAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product.Id;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Product?> GetProductById(Guid id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<ProductDto?> GetProductDetail(Guid id, List<ProductFilterDto>? filters)
        {
            var filterLookup = filters?
                .GroupBy(x => x.Key)
                .ToDictionary(
                    x => x.Key,
                    x => x.Select(v => v.Value).ToHashSet()
                );

            var variantsQuery = _dbContext.ProductVariants.AsNoTracking().AsQueryable();

            if (filterLookup != null && filterLookup.Any())
            {
                foreach (var filter in filterLookup)
                {
                    var key = filter.Key;
                    var values = filter.Value;

                    variantsQuery = variantsQuery.Where(pv =>
                        pv.ProductVariantAttributeValues.Any(av =>
                            av.VariantAttributeValue.Attribute.Name == key &&
                            values.Contains(av.VariantAttributeValue.Value)
                        )
                    );
                }
            }

            var result = await _dbContext.Products
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Brand = p.Brand.Name,
                    Category = p.Category.Name,
                    Specifications = p.Specifications.Select(sp => new SpecificationDto
                    {
                        Name = sp.Key,
                        Value = sp.Value
                    }).ToList(),
                    Variants = variantsQuery
                        .Where(pv => pv.ProductId == p.Id)
                        .Select(pv => new ProductVariantDto
                        {
                            Id = pv.Id,
                            Price = pv.Price,
                            Quantity = pv.Quantity,
                            Images = pv.Images
                                .Where(x => x.Type != ImageType.Thumbnail)
                                .Select(img => new ImageDto
                                {
                                    Url = img.Url,
                                    Type = img.Type
                                }).ToList(),
                            Attributes = pv.ProductVariantAttributeValues
                                .Select(av => new AttributeDto
                                {
                                    Name = av.VariantAttributeValue.Attribute.Name,
                                    Value = av.VariantAttributeValue.Value
                                }).ToList(),
                            
                        }).ToList()
                }).FirstOrDefaultAsync();
            return result;
        }
    }
}
