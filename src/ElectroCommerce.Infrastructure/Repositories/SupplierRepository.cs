using Domain.Entities;
using Domain.Interface;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SupplierRepository: ISupplierRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public SupplierRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
        {
            return await _dbContext.Suppliers.ToListAsync();
        }

        public async Task SaveAllAsync(IEnumerable<Supplier> suppliers)
        {
            await _dbContext.Suppliers.AddRangeAsync(suppliers);
            await _dbContext.SaveChangesAsync();
        }
    }
}
