using AutoMapper;
using MachShop.Products.Common.DTO;
using MachShop.Products.Domain.Models;

namespace MachShop.Products.Common.Configuration
{
    internal static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDto>();
            }).CreateMapper();
    }
}
