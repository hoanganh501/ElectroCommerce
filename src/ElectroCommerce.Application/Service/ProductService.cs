using AutoMapper;
using Domain.Entities;
using ElectroCommerce.Application.Interface;
using ElectroCommerce.Application.Request;
using ElectroCommerce.Application.Respsone;
using ElectroCommerce.Domain.DTO.Request;
using ElectroCommerce.Domain.Entities;
using ElectroCommerce.Domain.Interface;

namespace ElectroCommerce.Application.Service
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IProductVariantRepository _productVariantRepository;
        private readonly IMapper _mapper;

        public ProductService(
            IProductRepository productRepository, 
            ICategoryRepository categoryRepository,
            IBrandRepository brandRepository,
            IProductVariantRepository productVariantRepository,
            IMapper mapper) 
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
            _productVariantRepository = productVariantRepository;
            _mapper = mapper;
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
                Variants = request.Variants.Select(v =>
                {
                var distinctValueIds = v.AttributeValueIds.Distinct().ToList();

                    return new ProductVariant()
                    {
                        Price = v.Price,
                        Quantity = v.Quantity,
                        ProductVariantAttributeValues = distinctValueIds
                            .Select(valueId => new ProductVariantAttributeValue
                            {
                                VariantAttributeValueId = valueId
                            })
                            .ToList(),
                    };
                }).ToList(),
                Specifications = request.Specifications.Select(v => new ProductSpecification()
                {
                    Key = v.Key,
                    Value = v.Value
                }).ToList()
            };

            return await _productRepository.SaveAsync(newProduct);
        }

        public async Task<ProductDetailResponse> GetProductDetailAsync(Guid id, ProductDetailRequest? request)
        {
            _ = await _productRepository.GetProductById(id) ?? throw new Exception("Product not found");

            var filters = request?.Filters
                .Select(x => new ProductFilterDto
                {
                    Key = x.Name,
                    Value = x.Value
                })
                .ToList();

            var product = await _productRepository.GetProductDetail(id, filters);

            return _mapper.Map<ProductDetailResponse>(product);
        }
    }
}
