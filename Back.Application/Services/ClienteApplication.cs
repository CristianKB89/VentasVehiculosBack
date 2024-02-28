using AutoMapper;
using Back.Application.Commons.Base;
using Back.Application.Dtos.Request;
using Back.Application.Dtos.Response;
using Back.Application.Interfaces;
using Back.Application.Validators.Clientes;
using Back.Domain.Entities;
using Back.Infraestructure.Commons.Bases.Request;
using Back.Infraestructure.Commons.Bases.Response;
using Back.Infraestructure.Persistences.Interfaces;
using Utilities.Static;

namespace Back.Application.Services
{
    public class ClienteApplication : IClienteApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ClientesValidator _validationClient;
        private readonly IMapper _mapper;

        public ClienteApplication(IUnitOfWork unitOfWork, ClientesValidator validationClient, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationClient = validationClient;
            _mapper = mapper;
        }

        public async Task<BaseResponse<BaseEntityResponse<ClienteResponseDto>>> ListClientes(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<ClienteResponseDto>>();

            var clientes = await _unitOfWork.Cliente.ListClientes(filters);

            if (clientes is not null)
            {
                response.IsSucces = true;
                response.Data = _mapper.Map<BaseEntityResponse<ClienteResponseDto>>(clientes);
                response.Message = MensajeRespuesta.MESSAGE_QUERY;
            }
            else
            {
                response.IsSucces = false;
                response.Message = MensajeRespuesta.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }
        public async Task<BaseResponse<IEnumerable<ClienteSelectResponseDto>>> ListSelectClientes()
        {
            var response = new BaseResponse<IEnumerable<ClienteSelectResponseDto>>();

            var clientes = await _unitOfWork.Cliente.GetAllAsync();

            if (clientes is not null)
            {
                response.IsSucces = true;
                response.Data = _mapper.Map<IEnumerable<ClienteSelectResponseDto>>(clientes);
                response.Message = MensajeRespuesta.MESSAGE_QUERY;
            }
            else
            {
                response.IsSucces = false;
                response.Message = MensajeRespuesta.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<ClienteResponseDto>> ClienteById(int clienteId)
        {
            var response = new BaseResponse<ClienteResponseDto>();

            var clientes = await _unitOfWork.Cliente.GetByIdAsync(clienteId);

            if (clientes is not null)
            {
                response.IsSucces = true;
                response.Data = _mapper.Map<ClienteResponseDto>(clientes);
                response.Message = MensajeRespuesta.MESSAGE_QUERY;
            }
            else
            {
                response.IsSucces = false;
                response.Message = MensajeRespuesta.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> RegisterCliente(ClienteRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var validationResult = await _validationClient.ValidateAsync(requestDto);

            if (!validationResult.IsValid)
            {
                response.IsSucces = false;
                response.Message = MensajeRespuesta.MESSAGE_VALIDATE;
                response.Errors = validationResult.Errors;
                return response;
            }

            var cliente = _mapper.Map<Cliente>(requestDto);
            response.Data = await _unitOfWork.Cliente.RegisterAsync(cliente);

            if (response.Data)
            {
                response.IsSucces = true;
                response.Message = MensajeRespuesta.MESSAGE_SAVE;
            }
            else
            {
                response.IsSucces = false;
                response.Message = MensajeRespuesta.MESSAGE_FAILED;
            }
            return response;
        }

        public async Task<BaseResponse<bool>> EditCliente(int clienteId, ClienteRequestDto requestDto)
        {
            var response = new BaseResponse<bool>();
            var clienteEdit = await ClienteById(clienteId);

            if (clienteEdit.Data is null)
            {
                response.IsSucces = false;
                response.Message = MensajeRespuesta.MESSAGE_QUERY_EMPTY;
            }

            var cliente = _mapper.Map<Cliente>(requestDto);

            cliente.Id = clienteId;

            response.Data = await _unitOfWork.Cliente.EditAsync(cliente);

            if (response.Data)
            {
                response.IsSucces = true;
                response.Message = MensajeRespuesta.MESSAGE_UPDATE;
            }
            else
            {
                response.IsSucces = false;
                response.Message = MensajeRespuesta.MESSAGE_FAILED;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> RemoveCliente(int clienteId)
        {
            var response = new BaseResponse<bool>();

            var cliente = await ClienteById(clienteId);

            if (cliente.Data is null)
            {
                response.IsSucces = false;
                response.Message = MensajeRespuesta.MESSAGE_QUERY_EMPTY;
            }

            response.Data = await _unitOfWork.Cliente.RemoveAsync(clienteId);

            if (response.Data)
            {
                response.IsSucces = true;
                response.Message = MensajeRespuesta.MESSAGE_DELETE;
            }
            else
            {
                response.IsSucces = false;
                response.Message = MensajeRespuesta.MESSAGE_FAILED;
            }

            return response;
        }
    }
}
