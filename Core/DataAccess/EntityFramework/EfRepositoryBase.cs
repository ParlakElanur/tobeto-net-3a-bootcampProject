using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Core.DataAccess.EntityFramework
{
    public class EfRepositoryBase<TEntity, TEntityId, TContext> :  IAsyncRepository<TEntity, TEntityId>, ISyncRepository<TEntity, TEntityId>
        where TEntity : BaseEntity<TEntityId>
        where TContext : DbContext

    {
        protected readonly TContext Context;
        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }
        public IQueryable<TEntity> Query() => Context.Set<TEntity>();
        
        //Asenkron methods
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            Context.Update(entity);
            await Context.SaveChangesAsync();
            return entity;

        }
        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            entity.DeletedDate= DateTime.UtcNow;
            Context.Remove(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> queryAble = Query();
            if (include != null)
                queryAble = include(queryAble);

            return await queryAble.FirstOrDefaultAsync(predicate);
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> queryAble = Query();
            if (include != null)
                queryAble = include(queryAble);
            if (predicate != null)
                queryAble = queryAble.Where(predicate);
            return await queryAble.ToListAsync();
        }

        //Senkron methods
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> queryAble = Query();
            if (include != null)
                queryAble = include(queryAble);
            if (predicate != null)
                queryAble = queryAble.Where(predicate);
            return queryAble.ToList();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> queryAble = Query();
            if (include != null)
                queryAble = include(queryAble);

            return queryAble.FirstOrDefault(predicate);
        }

        public TEntity Add(TEntity entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            Context.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            entity.DeletedDate = DateTime.UtcNow;
            Context.Remove(entity);
            Context.SaveChanges();
            return entity;
        }
    }
}
