using AutoMapper;
using ApplicationCore.Entites;
using SagaMotors_API.Shop_Auto_Endpoints;
using SagaMotors_API.Shop_Cliente_Endpoints;
using SagaMotors_API.Shop_ClieAuto_Endpoints;
using SagaMotors_API.Shop_SistemaAuto_Endpoints;
using SagaMotors_API.Shop_AutoSistema_Endpoints;

namespace SagaMotors_API
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Shop_Auto, Shop_Auto_Dto>();
            CreateMap<Shop_Cliente, Shop_Cliente_Dto>();
            CreateMap<Shop_ClieAuto, Shop_ClieAuto_Dto>();
            CreateMap<Shop_SistemasAutomotrices, Shop_SistemaAuto_Dto>();
            CreateMap<Shop_AutoSistema, Shop_AutoSistema_Dto>();
        }
    }
}
