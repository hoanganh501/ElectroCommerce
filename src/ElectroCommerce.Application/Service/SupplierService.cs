using Application.Interface;
using Application.Respsone;
using AutoMapper;
using Domain.Entities;
using Domain.Interface;

namespace Application.Service
{
    public class SupplierService: ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }

        public async Task<IEnumerable<SupplierResponse>> GetAllSuppliersAsync()
        {
            var suppliers = await _supplierRepository.GetAllSuppliersAsync();
            return _mapper.Map<IEnumerable<SupplierResponse>>(suppliers);
        }
    }
}
