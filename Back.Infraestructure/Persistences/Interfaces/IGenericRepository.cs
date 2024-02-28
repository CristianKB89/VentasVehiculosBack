using Back.Domain.Entities;
using Back.Infraestructure.Commons.Bases.Request;
using System.Linq.Expressions;

namespace Back.Infraestructure.Persistences.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> RegisterAsync(T entity);
        Task<bool> EditAsync(T entity);
        Task<bool> RemoveAsync(int id);

        IQueryable<T> GetEntityQuery(Expression<Func<T, bool>>? filter = null);

        IQueryable<TDTO> Ordering<TDTO>(BasePaginationRequest req, IQueryable<TDTO> queryable, bool pagination = false) where TDTO : class;
    }
}
