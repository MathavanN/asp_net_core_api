using Supermarket.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.Domain.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
    }
}
