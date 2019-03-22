using Supermarket.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.Core.Repositories.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAllProductsAsync();
    }
}
