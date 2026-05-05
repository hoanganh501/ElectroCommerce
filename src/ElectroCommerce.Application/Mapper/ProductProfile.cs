using Application.Respsone;
using AutoMapper;
using Domain.Entities;
using ElectroCommerce.Application.Model;
using ElectroCommerce.Application.Respsone;
using ElectroCommerce.Domain.DTO;

namespace ElectroCommerce.Application.Mapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, ProductDetailResponse>();
            CreateMap<AttributeDto, AttributeModel>();
            CreateMap<ProductVariantDto, ProductVariantModel>();
            CreateMap<SpecificationDto, SpecificationModel>();
            CreateMap<ImageDto, ImageModel>();
        }
    }
}
