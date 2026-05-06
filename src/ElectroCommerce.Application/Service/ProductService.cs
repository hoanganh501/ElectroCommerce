using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using ElectroCommerce.Application.Extension;
using ElectroCommerce.Application.Interface;
using ElectroCommerce.Application.Model;
using ElectroCommerce.Application.Request;
using ElectroCommerce.Application.Respsone;
using ElectroCommerce.Domain.DTO;
using ElectroCommerce.Domain.DTO.Request;
using ElectroCommerce.Domain.Entities;
using ElectroCommerce.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace ElectroCommerce.Application.Service
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public ProductService(
            IProductRepository productRepository, 
            ICategoryRepository categoryRepository,
            IBrandRepository brandRepository,
            IMapper mapper) 
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _brandRepository = brandRepository;
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

        public async Task<ProductPaginationResponse> SearchWithPaginationAsync(SearchProductRequest request)
        {
            var queryProductVariant = SortProduct(request);

            var total = await queryProductVariant.CountAsync();

            var variant = await queryProductVariant
                .Skip((request.PageIndex) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            var items = variant.Select(x => new VariantResponse
            {
                ProductId = x.Product.Id,
                VariantId = x.Id,
                Name = x.Product.Name,
                Price = x.Price,
                Images = x.Images
                    .Select(img => new ImageModel
                    {
                        Url = img.Url,
                        Type = img.Type.GetDescription()
                    }).ToList(),
                Attributes = x.ProductVariantAttributeValues
                    .Select(pvav => new AttributeModel
                    {
                        Name = pvav.VariantAttributeValue.Attribute.Name,
                        Value = pvav.VariantAttributeValue.Value
                    }).ToList(),
            }).ToList();

            return new ProductPaginationResponse
            {
                Items = items,
                Total = total,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
            };      
        }

        private IQueryable<ProductVariant> SortProduct(SearchProductRequest request)
        {
            var query = _productRepository.GetQueryable();

            if (request.BrandIds != null)
            {
                query = query.Where(x => request.BrandIds.Contains(x.BrandId));
            }

            if (request.CategoryIds != null)
            {
                query = query.Where(x => request.CategoryIds.Contains(x.CategoryId));
            }

            var variantQuery = query.SelectMany(p => p.Variants);

            variantQuery = variantQuery
                .Include(v => v.Images)
                .Include(v => v.ProductVariantAttributeValues)
                    .ThenInclude(pvav => pvav.VariantAttributeValue)
                        .ThenInclude(x => x.Attribute)
                .Include(v => v.Product)
                .Where(x =>
            EF.Functions.Like(x.Product.Name, $"%{request.Search}%")
            || x.Product.Variants.Any(v =>
                v.ProductVariantAttributeValues.Any(pvav => 
                    EF.Functions.Like(pvav.VariantAttributeValue.Value, $"%{request.Search}%")
                ))
            );

            variantQuery = request.SortBy?.ToLower() switch
            {
                "price" => request.IsDesc
                    ? variantQuery.OrderByDescending(x => x.Price)
                    : variantQuery.OrderBy(x => x.Price),

                "name" => request.IsDesc
                    ? variantQuery.OrderByDescending(x => x.Product.Name)
                    : variantQuery.OrderBy(x => x.Product.Name),

                "created" => request.IsDesc
                    ? variantQuery.OrderByDescending(x => x.Product.CreatedAt)
                    : variantQuery.OrderBy(x => x.Product.CreatedAt),

                _ => variantQuery.OrderBy(x => x.Product.Name)
            };

            return variantQuery;
        }
    }
}
