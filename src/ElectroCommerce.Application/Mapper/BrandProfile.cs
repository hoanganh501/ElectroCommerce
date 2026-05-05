using AutoMapper;
using Domain.Entities;
using ElectroCommerce.Application.Respsone;

namespace ElectroCommerce.Application.Mapper
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, BrandResponse>();
        }
    }
}
