using Application.Respsone;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class SupplierProfile : Profile
    {
        public SupplierProfile()
        {
            CreateMap<Supplier, SupplierResponse>();
        }
    }
}
