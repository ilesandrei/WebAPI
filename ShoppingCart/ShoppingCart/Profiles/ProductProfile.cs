using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace ShoppingCart.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Entities.Manufacturer, ExternalModels.ManufacturerDTO>();
            CreateMap<ExternalModels.ManufacturerDTO, Entities.Manufacturer>();

            CreateMap<Entities.Product, ExternalModels.ProductDTO>();
            CreateMap<ExternalModels.ProductDTO, Entities.Product>();

            CreateMap<Entities.Category, ExternalModels.CategoryDTO>();
            CreateMap<ExternalModels.CategoryDTO, Entities.Category>();
        }
    }
}

