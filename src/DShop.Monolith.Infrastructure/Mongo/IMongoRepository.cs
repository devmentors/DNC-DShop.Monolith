using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DShop.Monolith.Core.Domain;
using DShop.Monolith.Core.Types;

namespace DShop.Monolith.Infrastructure.Mongo
{
    public interface IMongoRepository<TEntity> where TEntity : IEntity
    {
         Task<TEntity> GetAsync(Guid id);
         Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
         Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
         Task<IPagedResult<TEntity>> BrowseAsync<TQuery>(Expression<Func<TEntity, bool>> predicate,
				TQuery query) where TQuery : PagedQuery;
         Task CreateAsync(TEntity entity);
         Task UpdateAsync(TEntity entity);
         Task DeleteAsync(Guid id); 
         Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
    }
}