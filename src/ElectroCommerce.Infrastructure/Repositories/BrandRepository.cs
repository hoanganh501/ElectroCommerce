using Domain.Entities;
using ElectroCommerce.Domain.Interface;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ElectroCommerce.Infrastructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public BrandRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Brand?> GetBrandAsync(Guid id)
        {
            return await _dbContext.Brands.FindAsync(id);
        }

        public async Task<IEnumerable<Brand>> GetAllAsync()
        {
            return await _dbContext.Brands.AsNoTracking().ToListAsync();
        }
    }
}
