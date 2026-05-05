using ElectroCommerce.Application.Respsone;

namespace ElectroCommerce.Application.Interface
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandResponse>> GetAllAsync();
    }
}
