using Application.Respsone;

namespace Application.Interface
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierResponse>> GetAllSuppliersAsync();
    }
}
