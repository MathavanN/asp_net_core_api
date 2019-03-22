using Supermarket.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Core.Repositories.Contracts
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAllCategoriesAsync();
        Task<Category> FindById(int id);
        Task<IEnumerable<Category>> FindByConditionCategoriesAsync(Expression<Func<Category, bool>> expression);
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(Category category);
    }
}
