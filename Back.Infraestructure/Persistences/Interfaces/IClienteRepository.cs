using Back.Domain.Entities;
using Back.Infraestructure.Commons.Bases.Request;
using Back.Infraestructure.Commons.Bases.Response;

namespace Back.Infraestructure.Persistences.Interfaces
{
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
        Task<BaseEntityResponse<Cliente>> ListClientes(BaseFiltersRequest filters);
    }
}
