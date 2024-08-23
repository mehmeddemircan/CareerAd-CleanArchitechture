using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore;
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
    public class EfBaseRepository<TEntity,TContext> : IAsyncRepository<TEntity> 
        where TEntity : BaseEntity
        where TContext  : DbContext , new()
    {

        protected TContext Context { get; }

        public EfBaseRepository(TContext context)
        {
            Context = context;
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

     

        public async Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                                           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy =
                                                               null,
                                                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>?
                                                               include = null,
                                                           int index = 0, int size = 10, bool enableTracking = true,
                                                           CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null)
                return await orderBy(queryable).ToPaginateAsync(index, size, 0, cancellationToken);
            return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
        }

        

        public IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>();
        }


   

      
        public async Task<TEntity?> GetDetailsAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {

            IQueryable<TEntity> query = Context.Set<TEntity>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.FirstOrDefaultAsync(predicate);

        }

        public async Task<TEntity> DeleteAsync(TEntity entity, bool permanent = false)
        {


            Context.Set<TEntity>().Remove(entity);
            var data = await Context.SaveChangesAsync();


            return entity;
        }

        public async Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entities, bool permanent = false)
        {

            Context.Set<TEntity>().RemoveRange(entities);
            await Context.SaveChangesAsync();

            return entities;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.CreatedTime = DateTime.UtcNow;
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                entity.CreatedTime = DateTime.UtcNow;
            }

            await Context.AddRangeAsync(entities);
            await Context.SaveChangesAsync();
            return entities;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            entity.UpdatedTime = DateTime.UtcNow;
            Context.Update(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                entity.UpdatedTime = DateTime.UtcNow;
            }

            Context.UpdateRange(entities);
            await Context.SaveChangesAsync();
            return entities;
        }

       
        



    }
}
