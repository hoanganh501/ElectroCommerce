using ElectroCommerce.Domain.DTO;

namespace ElectroCommerce.Domain.Interface
{
    public interface IProductVariantRepository
    {
        Task<List<ProductVariantDto>> GetVariantsAsync(Guid productId, Dictionary<string, string>? filters);
    }
}
