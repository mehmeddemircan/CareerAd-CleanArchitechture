using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using QuickReserve.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public interface IAsyncRepository<T> : IQuery<T> where T : BaseEntity
    {
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);

        Task<T?> GetDetailsAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        Task<IPaginate<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                        int index = 0, int size = 10, bool enableTracking = true,
                                        CancellationToken cancellationToken = default);






        Task<T> AddAsync(T entity);

        Task<T> DeleteAsync(T entity);
        Task<T> UpdateAsync(T entity);

        Task<ICollection<T>> DeleteRangeAsync(ICollection<T> entities, bool permanent = false);


    }
}
