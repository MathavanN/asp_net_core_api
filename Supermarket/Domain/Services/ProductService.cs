using Supermarket.Domain.Services.Contracts;
using Supermarket.Entites.Models;
using Supermarket.Persistent.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ProductService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _repositoryWrapper.Product.ListAllProductsAsync();
        }
    }
}
