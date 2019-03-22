using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Supermarket.Core.Repositories.Contracts
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        //IEnumerable<TEntity> FindAll();
        //IEnumerable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression);
        //void Create(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        //void Save();

        Task<IEnumerable<TEntity>> ListAllAsync();
        Task<IEnumerable<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> expression);
        Task AddAsync(TEntity entity);
        Task SaveAsync();
    }
}
