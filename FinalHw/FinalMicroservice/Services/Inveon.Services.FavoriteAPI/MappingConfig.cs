using AutoMapper;
using Inveon.Services.FavoriteAPI.Models;
using Inveon.Services.FavoriteAPI.Models.Dto;

namespace Inveon.Services.FavoriteAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>().ReverseMap();
                config.CreateMap<FavoriteProductDto, FavoriteProduct>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
