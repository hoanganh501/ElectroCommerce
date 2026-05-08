using Application.Respsone;
using ElectroCommerce.Application.Request;

namespace Application.Interface
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierResponse>> GetAllSuppliersAsync();
        Task ImportSuplierAsyns(ImportSuplierRequest request);
    }
}
