using ElectroCommerce.Application.Respsone;

namespace ElectroCommerce.Application.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponse>> GetAllCategoriesAsync();
    }
}
