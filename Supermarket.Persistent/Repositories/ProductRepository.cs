using Supermarket.Entites.Models;
using Supermarket.Persistent.Context;
using Supermarket.Persistent.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Persistent.Repositories
{
    class ProductRepository : RepositoryBase<Product>, IProductRepository
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
