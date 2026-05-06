using ElectroCommerce.Application.Request;
using ElectroCommerce.Application.Respsone;

namespace ElectroCommerce.Application.Interface
{
    public interface IProductService
    {
        Task<Guid> CreateProductAsync(CreateProductRequest product);
        Task<ProductDetailResponse> GetProductDetailAsync(Guid id, ProductDetailRequest? request);
        Task<ProductPaginationResponse> SearchWithPaginationAsync(SearchProductRequest request);
    }
}
