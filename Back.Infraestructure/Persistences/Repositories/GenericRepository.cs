using Back.Domain.Entities;
using Back.Infraestructure.Commons.Bases.Request;
using Back.Infraestructure.Helpers;
using Back.Infraestructure.Persistences.Contexts;
using Back.Infraestructure.Persistences.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Back.Infraestructure.Persistences.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly VentasVehiculosContext _context;
        private readonly DbSet<T> _entity;

        public GenericRepository(VentasVehiculosContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var getAll = await _entity.AsNoTracking().ToListAsync();

            return getAll;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var getById = await _entity.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));

            return getById!;
        }

        public async Task<bool> RegisterAsync(T entity)
        {
            entity.FechaRegistro = DateTime.Now;

            await _context.AddAsync(entity);

            var registroAfectado = await _context.SaveChangesAsync();

            return registroAfectado > 0;
        }

        public async Task<bool> EditAsync(T entity)
        {
            entity.FechaActualizacion = DateTime.Now;

            _context.Update(entity);
            _context.Entry(entity).Property(x => x.FechaRegistro).IsModified = false;

            var registroAfectado = await _context.SaveChangesAsync();

            return registroAfectado > 0;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            T entity = await GetByIdAsync(id);

            entity!.Estado = false;

            _context.Update(entity);

            var registroAfectado = await _context.SaveChangesAsync();

            return registroAfectado > 0;
        }

        public IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _entity;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query;
        }


        public IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest req, IQueryable<TDTO> queryable, bool pagination = false) where TDTO : class
        {
            IQueryable<TDTO> queryDto = req.Order == "desc" ? queryable.OrderBy($"{req.Sort} descending") : queryable.OrderBy($"{req.Sort} ascending");

            if (pagination) queryDto = queryDto.Paginate(req);

            return queryDto;
        }
    }
}
