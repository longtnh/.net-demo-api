using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWebAPI.Models;
using DemoWebAPI.Dtos;

namespace DemoWebAPI.MapperProfile
{
    public class ProductsMapperProfile : Profile
    {
        public ProductsMapperProfile()
        {
            CreateMap<Product, ProductReadDto>();
        }
    }
}
