using Domain.Entities;
using ElectroCommerce.Domain.DTO;
using ElectroCommerce.Domain.DTO.Request;
namespace ElectroCommerce.Domain.Interface
{
    public interface IProductRepository
    {
        Task<Guid> SaveAsync(Product product);
        Task<int> SaveChangesAsync();
        Task<Product?> GetProductById(Guid id);
        Task<ProductDto?> GetProductDetail(Guid id, List<ProductFilterDto>? filters);
        IQueryable<Product> GetQueryable();
     }
}
