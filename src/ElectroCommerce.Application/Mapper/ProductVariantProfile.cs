using AutoMapper;
using Domain.Entities;
using ElectroCommerce.Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroCommerce.Application.Mapper
{
    public class ProductVariantProfile : Profile
    {
        public ProductVariantProfile()
        {
            CreateMap<ProductImage, ImageModel>();
            CreateMap<ProductSpecification, SpecificationModel>();
        }
    }
}
