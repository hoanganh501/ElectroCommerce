using Domain.Entities;

namespace ElectroCommerce.Domain.Interface
{
    public interface IProductRepository
    {
        Task<Guid> SaveAsync(Product product);
        Task<int> SaveChangesAsync();
    }
}
