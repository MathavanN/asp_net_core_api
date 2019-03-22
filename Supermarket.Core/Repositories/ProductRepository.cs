using Supermarket.Core.Context;
using Supermarket.Core.Models;
using Supermarket.Core.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Core.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public async Task<IEnumerable<Product>> ListAllProductsAsync()
        {
            return await ListAllAsync();
        }
    }
}
