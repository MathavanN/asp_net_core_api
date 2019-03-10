using Supermarket.Entites.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Persistent.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAllProductsAsync();
    }
}
