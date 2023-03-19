using AutoMapper;
using IXORA.PlatonovNikita.TestShop.Dto.ProductDto;
using IXORA.PlatonovNikita.TestShop.Model.Entities;

namespace IXORA.PlatonovNikita.TestShop.MappingProfile
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductData>()
                .ForMember(dest => dest.Id, 
                           options => options.MapFrom(product => product.Id))
                .ForMember(dest => dest.Name, 
                           options => options.MapFrom(product => product.Name))
                .ForMember(dest => dest.Quantity, 
                           options => options.MapFrom(product => product.Quantity))
                .ForMember(dest => dest.Price, 
                           options => options.MapFrom(product => product.Price))
                .ForMember(dest => dest.ProductTypeId, 
                           options => options.MapFrom(product => product.ProductTypeId))
                .ForMember(dest => dest.Type, 
                           options => options.MapFrom(product => product.Type.NameOfType));

            CreateMap<AddProductData, Product>();

            CreateMap<AddProductTypeData, ProductType>();
        }
    }
}
