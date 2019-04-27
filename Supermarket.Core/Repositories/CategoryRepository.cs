using Supermarket.Core.Context;
using Supermarket.Core.Models;
using Supermarket.Core.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Supermarket.Core.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task AddCategoryAsync(Category category)
        {
            await AddAsync(category);
            await SaveAsync();
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            Remove(category);
            await SaveAsync();
        }

        public async Task<IEnumerable<Category>> FindByConditionCategoriesAsync(Expression<Func<Category, bool>> expression)
        {
            return await FindByConditionAsync(expression);
        }

        public async Task<Category> FindByIdAsync(int id)
        {
            var category = await FindByConditionAsync(c => c.Id == id);
            return category.FirstOrDefault();
        }

        public async Task<IEnumerable<Category>> ListAllCategoriesAsync()
        {
            return await ListAllAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            Update(category);
            await SaveAsync();
        }
    }
}
