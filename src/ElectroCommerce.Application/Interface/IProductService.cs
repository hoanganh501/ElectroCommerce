using ElectroCommerce.Application.Request;

namespace ElectroCommerce.Application.Interface
{
    public interface IProductService
    {
        Task<Guid> CreateProductAsync(CreateProductRequest product);
    }
}
