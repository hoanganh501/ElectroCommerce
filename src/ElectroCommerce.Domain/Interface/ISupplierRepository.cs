using Domain.Entities;

namespace Domain.Interface
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Supplier>> GetAllSuppliersAsync();
        Task SaveAllAsync(IEnumerable<Supplier> suppliers);
    }
}
