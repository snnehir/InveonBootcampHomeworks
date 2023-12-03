using AutoMapper;
using Inveon.Services.OrderAPI.Models.Dto;
using Inveon.Services.OrderAPI.Models;

namespace Inveon.Services.OrderAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<OrderDetailDto, OrderDetails>();
                config.CreateMap<OrderDetails, OrderDetailDto>();
				config.CreateMap<OrderHeaderDto, OrderHeader>();
				config.CreateMap<OrderHeader, OrderHeaderDto>();
			});

            return mappingConfig;
        }
    }

}
