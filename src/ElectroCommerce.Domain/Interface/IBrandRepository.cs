using Domain.Entities;

namespace ElectroCommerce.Domain.Interface
{
    public interface IBrandRepository
    {
        Task<Brand?> GetBrandAsync(Guid id);
    }
}
