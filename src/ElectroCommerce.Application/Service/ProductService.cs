using Domain.Entities;
using ElectroCommerce.Application.Interface;
using ElectroCommerce.Application.Request;
using ElectroCommerce.Domain.Entities;
using ElectroCommerce.Domain.Interface;

namespace ElectroCommerce.Application.Service
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;
        public ProductService(
            IProductRepository productRepository, 
            ICategoryRepository categoryRepository,
            IBrandRepository brandRepository) 
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
        }

        public async Task<Guid> CreateProductAsync(CreateProductRequest request)
        {
            _ = await _categoryRepository.GetCategoryAsync(request.CategoryId) ?? throw new Exception("Category not found");
            _ = await _brandRepository.GetBrandAsync(request.BrandId) ?? throw new Exception("Brand not found");

            var newProduct = new Product()
            {
                Name = request.Name,
                BrandId = request.BrandId,
                Description = string.Empty,
                CategoryId = request.CategoryId,
                Variants = request.Variants.Select(v => new ProductVariant()
                {
                    Price = v.Price,
                    Quantity = v.Quantity,
                    Attributes = v.Attribute.Select(x => new VariantAttribute()
                    {
                        Name = x.Name,
                        Value = x.Value
                    }).ToList()
                }).ToList(),
                Specifications = request.Specifications.Select(v => new ProductSpecification()
                {
                    Key = v.Key,
                    Value = v.Value
                }).ToList()
            };

            return await _productRepository.SaveAsync(newProduct);
        }
    }
}
