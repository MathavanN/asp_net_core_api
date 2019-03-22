using Supermarket.Core.Models;
using Supermarket.Domain.Communication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.Domain.Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
        Task<CategoryResponse> SaveAsync(Category category);
        Task<CategoryResponse> UpdateAsync(int id, Category category);
        Task<CategoryResponse> DeleteAsync(int id);
    }
}
