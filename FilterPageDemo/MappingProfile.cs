using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterPageDemo
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Example mappings
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
