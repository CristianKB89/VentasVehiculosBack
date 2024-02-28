using Back.Application.Dtos.Request;
using Back.Application.Interfaces;
using Back.Infraestructure.Commons.Bases.Request;
using Microsoft.AspNetCore.Mvc;

namespace Back.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteApplication _clienteApplication;

        public ClienteController(IClienteApplication clienteApplication)
        {
            _clienteApplication = clienteApplication;
        }

        [HttpPost]
        public async Task<IActionResult> ListClientes([FromBody] BaseFiltersRequest filters)
        {
            var response = await _clienteApplication.ListClientes(filters);

            return Ok(response);
        }

        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectClientes()
        {
            var response = await _clienteApplication.ListSelectClientes();

            return Ok(response);
        }

        [HttpGet("{clienteId:int}")]
        public async Task<IActionResult> ClienteById(int clienteId)
        {
            var response = await _clienteApplication.ClienteById(clienteId);

            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterCliente([FromBody] ClienteRequestDto requestDto)
        {
            var response = await _clienteApplication.RegisterCliente(requestDto);

            return Ok(response);
        }

        [HttpPut("Edit/{clienteId:int}")]
        public async Task<IActionResult> EditCliente(int clienteId, [FromBody] ClienteRequestDto requestDto)
        {
            var response = await _clienteApplication.EditCliente(clienteId, requestDto);

            return Ok(response);
        }

        [HttpPut("Remove/{clienteId:int}")]
        public async Task<IActionResult> RemoveCliente(int clienteId)
        {
            var response = await _clienteApplication.RemoveCliente(clienteId);

            return Ok(response);
        }
    }
}
