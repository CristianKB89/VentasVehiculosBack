using AutoMapper;
using Back.Application.Dtos.Request;
using Back.Application.Dtos.Response;
using Back.Domain.Entities;
using Back.Infraestructure.Commons.Bases.Response;

namespace Back.Application.Mappers
{
    public class ClienteMappingProfile : Profile
    {
        public ClienteMappingProfile()
        {
            CreateMap<Cliente, ClienteResponseDto>()
                .ForMember(x => x.ClienteID, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Estado, x => x.MapFrom(y => y.Estado.Equals(true) ? "Activo" : "Inactivo"))
                .ReverseMap();

            CreateMap<BaseEntityResponse<Cliente>, BaseEntityResponse<ClienteResponseDto>>()
                .ReverseMap();

            CreateMap<ClienteRequestDto, Cliente>();

            CreateMap<Cliente, ClienteSelectResponseDto>()
                .ForMember(x => x.ClienteId, x => x.MapFrom(y => y.Id))
                .ReverseMap();
        }
    }
}
