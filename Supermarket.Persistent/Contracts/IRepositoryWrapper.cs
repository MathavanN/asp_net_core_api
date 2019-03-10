using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket.Persistent.Contracts
{
    public interface IRepositoryWrapper
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
    }
}
