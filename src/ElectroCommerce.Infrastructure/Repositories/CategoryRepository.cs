using Domain.Entities;
using ElectroCommerce.Domain.Interface;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ElectroCommerce.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category?> GetCategoryAsync(Guid id)
        {
            return await _dbContext.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _dbContext.Categories.AsNoTracking().ToListAsync();
        }
    }
}
