using Microsoft.EntityFrameworkCore;
using Supermarket.Persistent.Context;
using Supermarket.Persistent.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Persistent.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly RepositoryContext _repositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext) => _repositoryContext = repositoryContext;

        public async Task AddAsync(T entity) => await _repositoryContext.Set<T>().AddAsync(entity);

        public void Remove(T entity) => _repositoryContext.Set<T>().Remove(entity);

        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression) => await _repositoryContext.Set<T>().Where(expression).ToListAsync();

        public async Task<IEnumerable<T>> ListAllAsync() => await _repositoryContext.Set<T>().ToListAsync();

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();

        public void Update(T entity) => _repositoryContext.Set<T>().Update(entity);
    }
}
