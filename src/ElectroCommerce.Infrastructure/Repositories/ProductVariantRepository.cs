using ElectroCommerce.Domain.Interface;
using Infrastructure.Persistence;

namespace ElectroCommerce.Infrastructure.Repositories
{
    public class ProductVariantRepository : IProductVariantRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductVariantRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
