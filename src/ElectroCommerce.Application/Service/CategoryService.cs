using AutoMapper;
using ElectroCommerce.Application.Interface;
using ElectroCommerce.Application.Respsone;
using ElectroCommerce.Domain.Interface;

namespace ElectroCommerce.Application.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryResponse>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryResponse>>(categories);
        }
    }
}
