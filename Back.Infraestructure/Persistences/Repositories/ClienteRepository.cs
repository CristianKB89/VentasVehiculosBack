using Back.Domain.Entities;
using Back.Infraestructure.Commons.Bases.Request;
using Back.Infraestructure.Commons.Bases.Response;
using Back.Infraestructure.Persistences.Contexts;
using Back.Infraestructure.Persistences.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back.Infraestructure.Persistences.Repositories
{
    public class ClienteRepository : GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(VentasVehiculosContext context) : base(context) { }

        public async Task<BaseEntityResponse<Cliente>> ListClientes(BaseFiltersRequest filters)
        {
            var response = new BaseEntityResponse<Cliente>();

            var clientes = GetEntityQuery();

            if (filters.NumFilter is not null && !string.IsNullOrEmpty(filters.TextFilter))
            {
                switch (filters.NumFilter)
                {
                    case 1:
                        clientes = clientes.Where(x => x.Nombre!.Contains(filters.TextFilter));
                        break;
                }
            }

            if (filters.StateFilter is not null)
            {
                clientes = clientes.Where(x => x.Estado!.Equals(filters.StateFilter));
            }

            if (!string.IsNullOrEmpty(filters.StartDate) && !string.IsNullOrEmpty(filters.EndDate))
            {
                clientes = clientes.Where(x => x.FechaRegistro >= Convert.ToDateTime(filters.StartDate) && x.FechaRegistro <= Convert.ToDateTime(filters.EndDate).AddDays(1));
            }

            if (filters.Sort is null)
                filters.Sort = "Id";

            response.TotalRegistros = await clientes.CountAsync();
            response.Items = await Ordering(filters, clientes, !(bool)filters.Download!).ToListAsync();

            return response;

        }
    }
}
