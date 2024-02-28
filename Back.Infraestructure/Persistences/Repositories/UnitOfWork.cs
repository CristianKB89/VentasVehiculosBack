using Back.Infraestructure.Persistences.Contexts;
using Back.Infraestructure.Persistences.Interfaces;

namespace Back.Infraestructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly VentasVehiculosContext _context;
        public IClienteRepository Cliente { get; private set; }

        public UnitOfWork(VentasVehiculosContext context)
        {
            _context = context;
            Cliente = new ClienteRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
