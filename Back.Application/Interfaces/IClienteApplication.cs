using Back.Application.Commons.Base;
using Back.Application.Dtos.Request;
using Back.Application.Dtos.Response;
using Back.Infraestructure.Commons.Bases.Request;
using Back.Infraestructure.Commons.Bases.Response;

namespace Back.Application.Interfaces
{
    public interface IClienteApplication
    {
        Task<BaseResponse<BaseEntityResponse<ClienteResponseDto>>> ListClientes(BaseFiltersRequest filters);
        Task<BaseResponse<IEnumerable<ClienteSelectResponseDto>>> ListSelectClientes();
        Task<BaseResponse<ClienteResponseDto>> ClienteById(int clienteId);
        Task<BaseResponse<bool>> RegisterCliente(ClienteRequestDto requestDto);
        Task<BaseResponse<bool>> EditCliente(int clienteId, ClienteRequestDto requestDto);
        Task<BaseResponse<bool>> RemoveCliente(int clienteId);
    }
}
