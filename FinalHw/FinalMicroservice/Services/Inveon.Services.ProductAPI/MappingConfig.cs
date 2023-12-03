using AutoMapper;
using Inveon.Services.ProductAPI.Dto;
using Inveon.Services.ProductAPI.Models;

namespace Inveon.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CategoryDto, Category>();
				config.CreateMap<Category, CategoryDto>();
				config.CreateMap<ProductDto, Product>().ForPath(d => d.Category.CategoryName, opt => opt.MapFrom(s => s.CategoryName));
                config.CreateMap<Product, ProductDto>().ForPath(d => d.CategoryName, opt => opt.MapFrom(s => s.Category.CategoryName));
            });

            return mappingConfig;
        }
    }

}
