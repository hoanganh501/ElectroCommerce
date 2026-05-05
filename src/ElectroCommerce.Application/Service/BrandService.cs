using AutoMapper;
using ElectroCommerce.Application.Interface;
using ElectroCommerce.Application.Respsone;
using ElectroCommerce.Domain.Interface;

namespace ElectroCommerce.Application.Service
{
    public class BrandService : IBrandService
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;

        public BrandService(IMapper mapper, IBrandRepository brandRepository)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        }

        public async Task<IEnumerable<BrandResponse>> GetAllAsync()
        {
            var brand = await _brandRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BrandResponse>>(brand);
        }
    }
}
