using Domain.Entities;

namespace ElectroCommerce.Domain.Interface
{
    public interface ICategoryRepository
    {
        Task<Category?> GetCategoryAsync(Guid id);
        Task<IEnumerable<Category>> GetAllAsync();
    }
}
