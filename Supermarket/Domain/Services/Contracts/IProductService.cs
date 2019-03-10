using Supermarket.Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.Domain.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ListAsync();
    }
}
