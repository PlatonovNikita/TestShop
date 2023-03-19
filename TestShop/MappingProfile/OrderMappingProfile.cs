using AutoMapper;
using IXORA.PlatonovNikita.TestShop.Dto.OrderDto;
using IXORA.PlatonovNikita.TestShop.Model.Entities;

namespace IXORA.PlatonovNikita.TestShop.MappingProfile
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<CreateOrderLineData, OrderLine>();
            CreateMap<CreateOrderData, Order>();
            CreateMap<OrderLine, OrderLineData>()
                .ForMember(dest => dest.ProductId, 
                           options => options.MapFrom(x => x.ProductId))
                .ForMember(dest => dest.ProductType, 
                           options => options.MapFrom(x => x.Product.Type.NameOfType))
                .ForMember(dest => dest.ProductName, 
                           options => options.MapFrom(x => x.Product.Name))
                .ForMember(dest => dest.ProductPrice, 
                           options => options.MapFrom(x => x.ProductPrice))
                .ForMember(dest => dest.ProductQuantity, 
                           options => options.MapFrom(x => x.ProductQuantity));
            CreateMap<Order, OrderData>();
        }
    }

}
