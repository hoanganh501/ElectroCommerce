using AutoMapper;
using Domain.Entities;
using ElectroCommerce.Application.Respsone;

namespace ElectroCommerce.Application.Mapper
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryResponse>();
        }
    }
}
