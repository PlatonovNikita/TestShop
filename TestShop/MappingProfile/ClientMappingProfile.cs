using AutoMapper;
using IXORA.PlatonovNikita.TestShop.Dto.ClientDto;
using IXORA.PlatonovNikita.TestShop.Model.Entities;

namespace IXORA.PlatonovNikita.TestShop.MappingProfile
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<AddClientData, Client>();
        }
    }
}
