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
    public interface IAsyncRepository<TEntity> : IQuery<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity?> GetDetailsAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);

        Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                        int index = 0, int size = 10, bool enableTracking = true,
                                        CancellationToken cancellationToken = default);






        Task<TEntity> AddAsync(TEntity entity);

        Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entity);

        Task<TEntity> DeleteAsync(TEntity entity, bool permanent = false);

        Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entity, bool permanent = false);

     


    }
}
